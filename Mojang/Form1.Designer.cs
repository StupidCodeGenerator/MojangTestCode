namespace Mojang
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.buttonChi = new System.Windows.Forms.Button();
            this.buttonPeng = new System.Windows.Forms.Button();
            this.buttonGang = new System.Windows.Forms.Button();
            this.buttonHu = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(530, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 166);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 166);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(12, 190);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(512, 166);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(530, 190);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(512, 166);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // buttonChi
            // 
            this.buttonChi.Location = new System.Drawing.Point(912, 368);
            this.buttonChi.Name = "buttonChi";
            this.buttonChi.Size = new System.Drawing.Size(62, 38);
            this.buttonChi.TabIndex = 4;
            this.buttonChi.Text = "吃";
            this.buttonChi.UseVisualStyleBackColor = true;
            // 
            // buttonPeng
            // 
            this.buttonPeng.Location = new System.Drawing.Point(844, 368);
            this.buttonPeng.Name = "buttonPeng";
            this.buttonPeng.Size = new System.Drawing.Size(62, 38);
            this.buttonPeng.TabIndex = 5;
            this.buttonPeng.Text = "碰";
            this.buttonPeng.UseVisualStyleBackColor = true;
            // 
            // buttonGang
            // 
            this.buttonGang.Location = new System.Drawing.Point(776, 368);
            this.buttonGang.Name = "buttonGang";
            this.buttonGang.Size = new System.Drawing.Size(62, 38);
            this.buttonGang.TabIndex = 6;
            this.buttonGang.Text = "杠";
            this.buttonGang.UseVisualStyleBackColor = true;
            // 
            // buttonHu
            // 
            this.buttonHu.Location = new System.Drawing.Point(708, 368);
            this.buttonHu.Name = "buttonHu";
            this.buttonHu.Size = new System.Drawing.Size(62, 38);
            this.buttonHu.TabIndex = 7;
            this.buttonHu.Text = "胡";
            this.buttonHu.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 368);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(512, 119);
            this.richTextBoxLog.TabIndex = 8;
            this.richTextBoxLog.Text = "";
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(874, 449);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(168, 38);
            this.buttonNextStep.TabIndex = 9;
            this.buttonNextStep.Text = "NextStep";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(640, 368);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(62, 38);
            this.buttonPlay.TabIndex = 10;
            this.buttonPlay.Text = "出牌";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // buttonPass
            // 
            this.buttonPass.Location = new System.Drawing.Point(980, 368);
            this.buttonPass.Name = "buttonPass";
            this.buttonPass.Size = new System.Drawing.Size(62, 38);
            this.buttonPass.TabIndex = 11;
            this.buttonPass.Text = "过";
            this.buttonPass.UseVisualStyleBackColor = true;
            this.buttonPass.Click += new System.EventHandler(this.buttonPass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 499);
            this.Controls.Add(this.buttonPass);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.buttonHu);
            this.Controls.Add(this.buttonGang);
            this.Controls.Add(this.buttonPeng);
            this.Controls.Add(this.buttonChi);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button buttonChi;
        private System.Windows.Forms.Button buttonPeng;
        private System.Windows.Forms.Button buttonGang;
        private System.Windows.Forms.Button buttonHu;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        public System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPass;
    }
}

