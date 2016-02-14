/*
 * Manager 流程：
 * 
 * 1. 开局，给所有人发13张牌，currentAgentIndex设置为0
 * 2. currentAgentIndex对应的Agent，抓一张牌
 * 3. 询问currentAgent是否胡，如果是，游戏结束
 * 4. 询问currentAgent是否杠，如果是，回到步骤2
 * 5. 让currentAgent打出一张牌。
 * 6. 询问所有其他的Agent是否胡这张牌。如果有人胡，游戏结束
 * 7. 询问所有其他的Agent是否碰这张牌。如果有人碰，将currentAgent设置为碰的人，然后跳过他的抓牌步骤，定位到步骤5.
 * 8. 询问下家Agent是否吃这张牌，如果是，则将currentAgent设置为吃的人，跳过抓牌步骤，定位到步骤5.
 * 9. 将currentAgent设置为下家，返回到步骤2.
 * 
 * 以上看来，Dealer每一个工作周期可以被抽象分成一个“抓牌圈”和一个“打牌圈”。
 * “抓牌圈”包括抓牌，自摸判定，暗杠判定。
 * “打牌圈”包括打牌，点炮判定，点杠判定，碰判定，吃判定。
 * 
 * 另外，原则上要把暗杠和明杠分开，因为他们有不同的机制，明杠实际上是一种碰。
 * 自摸和点炮也要分开，这样状态分的比较清楚，代码比较流畅 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojang {
    /// <summary>
    /// nil表示空
    /// </summary>
    public enum Card {
        b1, b2, b3, b4, b5, b6, b7, b8, b9,
        t1, t2, t3, t4, t5, t6, t7, t8, t9,
        w1, w2, w3, w4, w5, w6, w7, w8, w9,
        dong, nan, xi, bei, zhong, fa, bai,
        nil
    }

    public enum ManagerState {
        ASK_PICK,      // 抓牌
        ASK_ZI_MO,     // 自摸
        ASK_AN_GANG,   // 暗杠
        ASK_PLAY,      // 打牌
        ASK_DIAN_PAO,  // 点炮
        ASK_PENG,      // 碰（包括明杠）
        ASK_CHI        // 吃
    }

    public class Manager {
        public ManagerState currentState;
        public List<Agent> agents = null;
        /// <summary>
        /// 表示当前行动的Agent
        /// </summary>
        public int currentAgentIndex;
        /// <summary>
        /// 表示当前打出targetCard（也就是刚打完牌）的Agent
        /// 这个和currentAgent不能混淆
        /// </summary>
        public int targetAgentIndex;
        public List<Card> deck;
        public Card targetCard;
        public void StartNewRound() {
            Form1.instance.SetLog("Start New Round ...");
            currentAgentIndex = 0;
            targetCard = Card.nil;
            agents = new List<Agent>();
            // If you want to add a human player, change the code below...
            for (int i = 0; i < 4; i++) {
                agents.Add(new Agent_AI(i, this));
            }
            //agents.Add(new Agent_Human(3, this));
            deck = GetShuffledDeck();
            // For each agent pick 13 cards from the deck and remove them from the deck
            for (int i = 0; i < agents.Count; i++) {
                for (int j = 0; j < 13; j++) {
                    agents[i].holdingCards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
                if (agents[i].isDealer) {
                    agents[i].holdingCards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            foreach (Agent a in agents) {
                a.holdingCards.Sort();
            }
            NextStep();
        }

        /// <summary>
        /// 牌局下一步
        /// 
        /// 在这个阶段，当前Agent已经抓过牌了。
        /// 如果没抓过牌那是Manager的问题不是Agent的问题
        /// 
        /// *这里只考虑询问，不考虑响应*
        /// 
        /// 另外，考虑再三，为了调试方便，还是采用了步进调试方式。
        /// 待步进调试方式写好后，增加自动机
        /// 
        /// </summary>
        public void NextStep() {
            Form1.instance.buttonNextStep.Enabled = false;
            Agent currentAgent = agents[currentAgentIndex];
            switch (currentState) {
                case ManagerState.ASK_PICK:
                    // 如果deck的容量为0，表示所有的牌都抓没了，牌局结束
                    if (deck.Count == 0) {
                        End("流局");
                    } else {
                        Form1.instance.SetLog("NextStep : 请求 agent[" + currentAgentIndex + "] 抓牌");
                        agents[currentAgentIndex].PickCard(deck[0]);
                        deck.RemoveAt(0);
                        // 抓牌后立刻进入下一个状态，没有任何分支
                        currentState = ManagerState.ASK_ZI_MO;
                        Form1.instance.buttonNextStep.Enabled = true;
                        targetAgentIndex = currentAgentIndex; // 抓牌决定目标玩家
                    }
                    break;
                case ManagerState.ASK_ZI_MO:
                    Form1.instance.SetLog("NextStep : 询问 agent[" + currentAgentIndex + "] 是否自摸");
                    currentAgent.AskForZiMo();
                    break;
                case ManagerState.ASK_AN_GANG:
                    Form1.instance.SetLog("NextStep : 询问 agent[" + currentAgentIndex + "] 是否暗杠");
                    currentAgent.AskForAnGang();
                    break;
                case ManagerState.ASK_PLAY:
                    Form1.instance.SetLog("NextStep : 要求 agent[" + currentAgentIndex + "] 打牌");
                    currentAgent.AskForPlay();
                    break;
                case ManagerState.ASK_DIAN_PAO:
                    if (targetCard != Card.nil) {
                        // 在上一个Agent打出牌以后，就将currentAgentIndex+1了，
                        // 是在Callback中操作的。所有这里如果出现了相等，就表明已经轮询了一圈
                        // 为了回避开自己，在进入碰的状态之前，currentAgentIndex +1
                        if (targetAgentIndex == currentAgentIndex) {
                            currentAgentIndex = GetNextIndex(targetAgentIndex);
                            currentState = ManagerState.ASK_PENG;
                            NextStep();
                        } else {
                            Form1.instance.SetLog("NextStep : 询问 agent[" + currentAgentIndex + "] 是否胡");
                            currentAgent.AskForHu(this.targetCard);
                        }
                    }
                    break;
                case ManagerState.ASK_PENG:
                    if (targetCard != Card.nil) {
                        // 在进入碰的状态之前，currengAgentIndex = GetNextIndex(targetAgentIndex)，
                        if (targetAgentIndex == currentAgentIndex) {
                            currentState = ManagerState.ASK_CHI;
                            NextStep();
                        } else {
                            Form1.instance.SetLog("NextStep : 询问 agent[" + currentAgentIndex + "] 是否碰");
                            currentAgent.AskForPeng(this.targetCard);
                        }
                    }
                    break;
                case ManagerState.ASK_CHI:
                    if (targetCard != Card.nil) {
                        int nextIndex = GetNextIndex(currentAgentIndex);
                        Form1.instance.SetLog("NextStep : 询问 agent[" + nextIndex + "] 是否吃");
                        agents[nextIndex].AskForChi(targetCard);
                    }
                    break;
            }
        }

        public int GetNextIndex(int currentIndex) {
            if (currentIndex == 3) {
                return 0;
            } else {
                return currentIndex + 1;
            }
        }

        /// <summary>
        /// 结束牌局
        /// </summary>
        public void End(string discription) {
            Form1.instance.ShowEnd(discription);
            StartNewRound();
        }

        public List<Card> GetShuffledDeck() {
            List<Card> deck = GetDeck();
            for (int i = 0; i < deck.Count; i++) {
                int randomIndex = Utils.GetRandomInt(deck.Count);
                Card temp = deck[randomIndex];
                deck[randomIndex] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        public List<Card> GetDeck() {
            List<Card> output = new List<Card>();
            for (int i = 0; i < 136; i++) {
                output.Add(IntToMojang(i));
            }
            return output;
        }

        public Card IntToMojang(int i) {
            return (Card)(i / 4);
        }

        // --- CALL BACKS ---
        /// <summary>
        /// 传入true表示胡，传入false表示不胡
        /// </summary>
        public void AskForDianPaoCallback(bool isHu, int agentIndex) {
            if (isHu) {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]被点炮");
                End("点炮");
            } else {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]没有胡");
                currentAgentIndex = GetNextIndex(agentIndex);
                Form1.instance.buttonNextStep.Enabled = true;
                Form1.instance.Refresh();
            }
        }

        public void AskForZiMoCallback(bool isHu, int agentIndex) {
            if (isHu) {
                End("自摸(" + agentIndex + ")");
            } else {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]自摸失败");
                currentState = ManagerState.ASK_AN_GANG;
                Form1.instance.Refresh();
                Form1.instance.buttonNextStep.Enabled = true;
            }
        }

        public void AskForAnGangCallback(List<Card> gangCards, int agentIndex) {
            if (gangCards == null) {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]暗杠失败");
                currentState = ManagerState.ASK_PLAY;
                Form1.instance.buttonNextStep.Enabled = true;
            } else {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]暗杠成功");
                currentState = ManagerState.ASK_PICK;
                Form1.instance.Refresh();
                Form1.instance.buttonNextStep.Enabled = true;
            }
        }

        /// <summary>
        /// 传入非空集合表示Agent想要碰。
        /// Dealer需要判断碰是否合法（和当前的targetCard进行比对）
        /// </summary>
        public void AskForPengCallback(List<Card> pengCards, int agentIndex) {
            if (pengCards == null) {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]没有碰");
                currentAgentIndex = GetNextIndex(agentIndex);
                Form1.instance.buttonNextStep.Enabled = true;
            } else {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]决定碰");
                currentState = ManagerState.ASK_PLAY;
                Form1.instance.Refresh();
                Form1.instance.buttonNextStep.Enabled = true;
            }
        }

        /// <summary>
        /// 传入非空集合表示Agent想要吃，
        /// 需要判断吃是否合法（和当前targetCard进行比对，并且需要和currentAgentIndex进行比对）
        /// 没有吃，下家抓牌。否则下家打牌
        /// </summary>
        public void AskForChiCallback(List<Card> chiCards, int agentIndex) {
            if (chiCards == null) {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]没有吃");
                currentState = ManagerState.ASK_PICK;
                currentAgentIndex = GetNextIndex(currentAgentIndex);
                Form1.instance.buttonNextStep.Enabled = true;
            } else {
                Form1.instance.SetLog("Callback : agents[" + agentIndex + "]吃");
                currentState = ManagerState.ASK_PLAY;
                currentAgentIndex = GetNextIndex(currentAgentIndex);
                Form1.instance.buttonNextStep.Enabled = true;
            }
        }

        /// <summary>
        /// 不可传入空值，表示Agent打某张牌
        /// </summary>
        public void AskForPlayCallback(Card playCard, int agentIndex) {
            Form1.instance.SetLog("Callback : agents[" + agentIndex + "]打出了[" + playCard.ToString() + "]");
            currentState = ManagerState.ASK_DIAN_PAO;
            targetCard = playCard;
            agents[currentAgentIndex].holdingCards.Remove(playCard);
            agents[currentAgentIndex].playedCards.Add(playCard);
            agents[currentAgentIndex].holdingCards.Sort();
            currentAgentIndex = GetNextIndex(agentIndex);
            Form1.instance.Refresh();
            Form1.instance.buttonNextStep.Enabled = true;
        }
    }
}
