using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mojang {

    public partial class Form1 : Form {

        public static Dictionary<Card, Rectangle> MOJANG_RECT_DIC = new Dictionary<Card, Rectangle>() {
            {Card.b1, new Rectangle(0, 0,   33, 42)},
            {Card.b2, new Rectangle(33, 0,  33, 42)},
            {Card.b3, new Rectangle(66, 0,  33, 42)},
            {Card.b4, new Rectangle(100, 0, 33, 42)},
            {Card.b5, new Rectangle(133, 0, 33, 42)},
            {Card.b6, new Rectangle(166, 0, 33, 42)},
            {Card.b7, new Rectangle(200, 0, 33, 42)},
            {Card.b8, new Rectangle(233, 0, 33, 42)},
            {Card.b9, new Rectangle(266, 0, 33, 42)},
            {Card.t1, new Rectangle(0,   42,   33, 42)},
            {Card.t2, new Rectangle(33,  42,  33, 42)},
            {Card.t3, new Rectangle(66,  42,  33, 42)},
            {Card.t4, new Rectangle(100, 42, 33, 42)},
            {Card.t5, new Rectangle(133, 42, 33, 42)},
            {Card.t6, new Rectangle(166, 42, 33, 42)},
            {Card.t7, new Rectangle(200, 42, 33, 42)},
            {Card.t8, new Rectangle(233, 42, 33, 42)},
            {Card.t9, new Rectangle(266, 42, 33, 42)},
            {Card.w1, new Rectangle(0,   84,   33, 42)},
            {Card.w2, new Rectangle(33,  84,  33, 42)},
            {Card.w3, new Rectangle(66,  84,  33, 42)},
            {Card.w4, new Rectangle(100, 84, 33, 42)},
            {Card.w5, new Rectangle(133, 84, 33, 42)},
            {Card.w6, new Rectangle(166, 84, 33, 42)},
            {Card.w7, new Rectangle(200, 84, 33, 42)},
            {Card.w8, new Rectangle(233, 84, 33, 42)},
            {Card.w9, new Rectangle(266, 84, 33, 42)},

            {Card.dong, new Rectangle(0,   126, 33, 42)},
            {Card.nan, new Rectangle(33,   126, 33, 42)},
            {Card.xi, new Rectangle(66,    126, 33, 42)},
            {Card.bei, new Rectangle(100,  126, 33, 42)},
            {Card.zhong, new Rectangle(133,126, 33, 42)},
            {Card.fa, new Rectangle(166,   126, 33, 42)},
            {Card.bai, new Rectangle(200,  126, 33, 42)},
        };

        public static Bitmap imageRes = null;

        public Manager manager = null;

        public static Form1 instance = null;

        public Form1() {
            instance = this;
            InitializeComponent();

            imageRes = new Bitmap("th.jpg");

            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
            pictureBox3.Paint += new PaintEventHandler(pictureBox3_Paint);
            pictureBox4.Paint += new PaintEventHandler(pictureBox4_Paint);

            pictureBox4.MouseClick += new MouseEventHandler(pictureBox4_MouseClick);

            manager = new Manager();
            manager.StartNewRound();
        }


        public void ShowEnd(string discription) {
            MessageBox.Show(discription);
        }

        void pictureBox4_Paint(object sender, PaintEventArgs e) {
            manager.agents[3].Paint(e.Graphics);
        }

        void pictureBox3_Paint(object sender, PaintEventArgs e) {
            manager.agents[2].Paint(e.Graphics);
        }

        void pictureBox2_Paint(object sender, PaintEventArgs e) {
            manager.agents[1].Paint(e.Graphics);
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e) {
            manager.agents[0].Paint(e.Graphics);
        }

        public static void DrawMojang(Graphics g, int x, int y, Card mojang) {
            g.DrawImage(imageRes, x, y, MOJANG_RECT_DIC[mojang], GraphicsUnit.Pixel);
        }

        public void SetLog(string log) {
            richTextBoxLog.AppendText(log + "\r\n");
            richTextBoxLog.ScrollToCaret();
        }

        private void buttonNextStep_Click(object sender, EventArgs e) {
            manager.NextStep();
        }

        // Human Agent index is 3
        private void buttonPass_Click(object sender, EventArgs e) {
            switch (manager.currentState) { 
                case ManagerState.ASK_AN_GANG:
                    manager.AskForAnGangCallback(null, 3);
                    break;
                case ManagerState.ASK_CHI:
                    manager.AskForChiCallback(null, 3);
                    break;
                case ManagerState.ASK_DIAN_PAO:
                    manager.AskForDianPaoCallback(false, 3);
                    break;
                case ManagerState.ASK_PENG:
                    manager.AskForPengCallback(null, 3);
                    break;
                case ManagerState.ASK_ZI_MO:
                    manager.AskForZiMoCallback(false, 3);
                    break;
            }
        }

        void pictureBox4_MouseClick(object sender, MouseEventArgs e) {
            Agent_Human human = manager.agents[3] as Agent_Human;
            human.OnClick(e.X, e.Y);
            this.Refresh();
        }
    }
}
