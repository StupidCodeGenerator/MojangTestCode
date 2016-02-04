using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mojang {
    public enum MOJANG {
        b1, b2, b3, b4, b5, b6, b7, b8, b9,
        t1, t2, t3, t4, t5, t6, t7, t8, t9,
        w1, w2, w3, w4, w5, w6, w7, w8, w9,
        dong, nan, xi, bei, zhong, fa, bai
    }
    public partial class Form1 : Form {

        public static Dictionary<MOJANG, Rectangle> MOJANG_RECT_DIC = new Dictionary<MOJANG, Rectangle>() {
            {MOJANG.b1, new Rectangle(0, 0,   33, 42)},
            {MOJANG.b2, new Rectangle(33, 0,  33, 42)},
            {MOJANG.b3, new Rectangle(66, 0,  33, 42)},
            {MOJANG.b4, new Rectangle(100, 0, 33, 42)},
            {MOJANG.b5, new Rectangle(133, 0, 33, 42)},
            {MOJANG.b6, new Rectangle(166, 0, 33, 42)},
            {MOJANG.b7, new Rectangle(200, 0, 33, 42)},
            {MOJANG.b8, new Rectangle(233, 0, 33, 42)},
            {MOJANG.b9, new Rectangle(266, 0, 33, 42)},
            {MOJANG.t1, new Rectangle(0,   42,   33, 42)},
            {MOJANG.t2, new Rectangle(33,  42,  33, 42)},
            {MOJANG.t3, new Rectangle(66,  42,  33, 42)},
            {MOJANG.t4, new Rectangle(100, 42, 33, 42)},
            {MOJANG.t5, new Rectangle(133, 42, 33, 42)},
            {MOJANG.t6, new Rectangle(166, 42, 33, 42)},
            {MOJANG.t7, new Rectangle(200, 42, 33, 42)},
            {MOJANG.t8, new Rectangle(233, 42, 33, 42)},
            {MOJANG.t9, new Rectangle(266, 42, 33, 42)},
            {MOJANG.w1, new Rectangle(0,   84,   33, 42)},
            {MOJANG.w2, new Rectangle(33,  84,  33, 42)},
            {MOJANG.w3, new Rectangle(66,  84,  33, 42)},
            {MOJANG.w4, new Rectangle(100, 84, 33, 42)},
            {MOJANG.w5, new Rectangle(133, 84, 33, 42)},
            {MOJANG.w6, new Rectangle(166, 84, 33, 42)},
            {MOJANG.w7, new Rectangle(200, 84, 33, 42)},
            {MOJANG.w8, new Rectangle(233, 84, 33, 42)},
            {MOJANG.w9, new Rectangle(266, 84, 33, 42)},

            {MOJANG.dong, new Rectangle(0,   126, 33, 42)},
            {MOJANG.nan, new Rectangle(33,   126, 33, 42)},
            {MOJANG.xi, new Rectangle(66,    126, 33, 42)},
            {MOJANG.bei, new Rectangle(100,  126, 33, 42)},
            {MOJANG.zhong, new Rectangle(133,126, 33, 42)},
            {MOJANG.fa, new Rectangle(166,   126, 33, 42)},
            {MOJANG.bai, new Rectangle(200,  126, 33, 42)},
        };

        public static Bitmap imageRes = null;

        public Manager manager = null;

        public Form1() {
            InitializeComponent();

            imageRes = new Bitmap("th.jpg");

            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
            pictureBox3.Paint += new PaintEventHandler(pictureBox3_Paint);
            pictureBox4.Paint += new PaintEventHandler(pictureBox4_Paint);

            manager = new Manager();
            manager.StartNewRound();
        }

        void pictureBox4_Paint(object sender, PaintEventArgs e) {
            manager.agents[3].PaintCards(e.Graphics);
        }

        void pictureBox3_Paint(object sender, PaintEventArgs e) {
            manager.agents[2].PaintCards(e.Graphics);
        }

        void pictureBox2_Paint(object sender, PaintEventArgs e) {
            manager.agents[1].PaintCards(e.Graphics);
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e) {
            manager.agents[0].PaintCards(e.Graphics);
        }

        public static void DrawMojang(Graphics g, int x, int y, MOJANG mojang) {
            g.DrawImage(imageRes, x, y, MOJANG_RECT_DIC[mojang], GraphicsUnit.Pixel);
        }
    }
}
