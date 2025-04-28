using Memory_Games.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game_Project
{
    public partial class frmMemoryGame : Form
    {
        public frmMemoryGame()
        {
            InitializeComponent();
        }

        #region ToolStrip
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitel.ForeColor = Color.Black;
            this.BackColor = Color.Red;
        }
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1Score.ForeColor = Color.Black;
            lbl2Remaining.ForeColor = Color.Black;
            lblScore.ForeColor = Color.GreenYellow;
            lblRemainingTime.ForeColor = Color.GreenYellow;
            this.BackColor = Color.White;
        }
        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitel.ForeColor= Color.White;
            lbl1Score.ForeColor= Color.White;
            lbl2Remaining.ForeColor= Color.White;
            this.BackColor = Color.Black;
        }
        private void defultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitel.ForeColor=Color.Red;
            lblScore.ForeColor= Color.Yellow;
            lbl1Score.ForeColor= Color.White;
            lbl2Remaining.ForeColor= Color.White; 
            lblRemainingTime.ForeColor= Color.Yellow;
            this.BackColor = Color.Silver;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lblRemainingTime.Text = "100";
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lblRemainingTime.Text = "50";
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lblRemainingTime.Text = "30";
        }

        #endregion

        enClicks ClickTurn = enClicks.FirstClick;
        stGameStatus GameStatus;
        Random random = new Random();
        
        

        enum enClicks
        {
            FirstClick,
            SecondClick
        }

        struct stGameStatus
        {
            public bool GameOver;
            public short PlayCount;
            public PictureBox PbBox1;
            public PictureBox PbBox2;

        }

        
        private void FillImageTag()
        {
           
            for (int i = 1; i < 13; i++)
            {
               PictureBox pb = this.Controls["pb"+i] as PictureBox;
                if(pb != null)
                {
                    pb.Tag = random.Next(1, 13);
                }
            }
        }

        public void ChangeImage(PictureBox pictureBox)
        {
            

            if (pictureBox.InitialImage==Resources.cover)
            {
                switch(ClickTurn)
                {
                    case enClicks.FirstClick:
                        pictureBox.Image = GetImageBytag(pictureBox.Tag.ToString());
                        GameStatus.PbBox1 = pictureBox;
                        ClickTurn = enClicks.SecondClick;
                        GameStatus.PlayCount++;
                    break;

                    case enClicks.SecondClick:
                        pictureBox.Image = GetImageBytag(pictureBox.Tag.ToString());
                        GameStatus.PbBox2 = pictureBox;
                        ClickTurn = enClicks.FirstClick;
                        GameStatus.PlayCount++;
                        timer1.Start(); 
                    break;

                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image GetImageBytag(string tag)
        {
           
            switch (tag)
            {
                case "1":
                    return Resources._1;
                case "2":
                    return Resources._2;
                case "3":
                    return Resources._3;
                case "4":
                    return Resources._4;
                case "5":
                    return Resources._5;
                case "6":
                    return Resources._6;
                case "7":
                    return Resources._7;
                case "8":
                    return Resources._8;
                case "9":
                    return Resources._9;
                case "10":
                    return Resources._10;
                case "11":
                    return Resources._11;
                case "12":
                    return Resources._12;
                // أضف هنا الحالات الأخرى
                default:
                    return Resources.cover;
            }
        }

        private void pb_Click(object sender, EventArgs e)
        {
            ChangeImage((PictureBox)sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (GameStatus.PbBox1.Tag.ToString() != GameStatus.PbBox2.Tag.ToString())
            {
                //System.Threading.Thread.Sleep(500);
                GameStatus.PbBox1.Image = Resources.cover;
                GameStatus.PbBox1.Tag = "cover";
                GameStatus.PbBox2.Image = Resources.cover;
                GameStatus.PbBox2.Tag = "cover";
            }
            else
            {
                GameStatus.PbBox1.Visible = false;
                GameStatus.PbBox2.Visible = false;
            }

            ClickTurn = enClicks.FirstClick;
        }

        private void frmMemoryGame_Load(object sender, EventArgs e)
        {
            FillImageTag();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
           //FillImageTag();
        }
    }
}
