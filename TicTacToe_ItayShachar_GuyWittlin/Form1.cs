using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_ItayShachar_GuyWittlin.Properties;


namespace TicTacToe_ItayShachar_GuyWittlin
{
    public partial class Form1 : Form
    {
        private bool m_IsFirstPlayer = true;

        private Image[] m_Images = new Image[2];




        public Form1()
        {
            InitializeComponent();

            SetImagesArray();
        }

        public void SetImagesArray()
        {
            m_Images[0] = Resources.x;
            m_Images[1] = Resources.circle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sign_Click(object sender, EventArgs e)
        {
            PictureBox sign = sender as PictureBox;

            if (m_IsFirstPlayer)
            {
                sign.Image = Resources.x;
                m_IsFirstPlayer = false;
                sign.Enabled = true;
            }
            else
            {
                sign.Image = Resources.circle;
            }
        }
    }
}
