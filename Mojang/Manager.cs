using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojang {
    public class Manager {
        public List<Agent> agents = null;
        public void StartNewRound() {
            agents = new List<Agent>();
            for (int i = 0; i < 4; i++) {
                agents.Add(new Agent());
            }
            List<MOJANG> shuffledDeck = GetShuffledDeck();
            // For each agent pick 13 cards from the deck and remove them from the deck
            for (int i = 0; i < agents.Count; i++) {
                for (int j = 0; j < 13; j++) {
                    agents[i].cards.Add(shuffledDeck[0]);
                    shuffledDeck.RemoveAt(0);
                }
                if (agents[i].isDealer) {
                    agents[i].cards.Add(shuffledDeck[0]);
                    shuffledDeck.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// 行为回调：
        /// Manager会通知某个Agent行动，Agent行动以后通过回调函数的方式通知manager行动结束
        /// </summary>
        /// <param name="behavior"></param>
        public void BehaviorCallBack(Behavior behavior, int agentIndex) {
            if (behavior.behaviorType == BehaviorType.TEST) { 
                
            }
        }

        public List<MOJANG> GetShuffledDeck() {
            List<MOJANG> deck = GetDeck();
            for (int i = 0; i < deck.Count; i++) {
                int randomIndex = Utils.GetRandomInt(deck.Count);
                MOJANG temp = deck[randomIndex];
                deck[randomIndex] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        public List<MOJANG> GetDeck() {
            List<MOJANG> output = new List<MOJANG>();
            for (int i = 0; i < 136; i++) {
                output.Add(IntToMojang(i));
            }
            return output;
        }

        public MOJANG IntToMojang(int i) {
            return (MOJANG)(i / 4);
        }
    }
}
