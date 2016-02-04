using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mojang {
    /// <summary>
    /// 这是一个父类。游戏逻辑中出现了两种Agent。一种是AI，一种是人类。
    /// </summary>
    public class Agent {
        public List<MOJANG> cards;
        public bool isDealer; // 庄家最先说话，并且在一开始多抓一张牌
        public int agentIndex;
        public Behavior lastBehavior; // 用来记录此Agent刚刚过去的行为。
        public Agent(int agentIndex) {
            cards = new List<MOJANG>();
            this.agentIndex = agentIndex;
        }
        
        public void PaintCards(Graphics g) {
            for (int i = 0; i < cards.Count; i++) {
                Form1.DrawMojang(g, i * 33, 0, cards[i]);
            }
        }

        /// <summary>
        /// 一般来说，Agent的行动是这样的：
        /// 首先是考虑有没有不抓牌的行为，比如碰。
        /// 如果有，那么询问AI或者人类是否碰
        /// 如果没有，抓牌以后询问AI是否胡，
        /// 如果没有，询问AI打那一张牌。
        /// 这里如果确保不出问题应该绘制一张流程图。
        /// </summary>
        public virtual void NextStep(Manager manager) { 

        }
    }
}
