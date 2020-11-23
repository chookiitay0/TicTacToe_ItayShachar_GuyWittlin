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


        public string PictureToString()
        {
            
        }

        public bool IsImagesMatch(Image image1, Image image2)
        {
            try
            {
                //create instance or System.Drawing.ImageConverter to convert
                //each image to a byte array
                ImageConverter converter = new ImageConverter();
                //create 2 byte arrays, one for each image
                byte[] imgBytes1 = new byte[1];
                byte[] imgBytes2 = new byte[1];

                //convert images to byte array
                imgBytes1 = (byte[])converter.ConvertTo(image1, imgBytes2.GetType());
                imgBytes2 = (byte[])converter.ConvertTo(image2, imgBytes1.GetType());

                //now compute a hash for each image from the byte arrays
                System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed();
                byte[] imgHash1 = sha.ComputeHash(imgBytes1);
                byte[] imgHash2 = sha.ComputeHash(imgBytes2);

                //now let's compare the hashes
                for (int i = 0; i < imgHash1.Length && i < imgHash2.Length; i++)
                {
                    //whoops, found a non-match, exit the loop
                    //with a false value
                    if (!(imgHash1[i] == imgHash2[i]))
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            //we made it this far so the images must match
            return true;
        }

        public string[,] FormToMatrix()
        {
            //המטריצה המוחזרת
            string[,] picturesMatrix = new string[3, 3];
            int row, col;
            PictureBox curPicture;

            //עוברים על כלל הפקדים בטופס - נעזרים בלולאת foreach
            foreach (Control ctrl in this.Controls)
                if (ctrl is PictureBox)
                {
                    curPicture = ctrl as PictureBox;

                    //מציאת מספר השורה והעמודה מתוך שם הפקד
                    row = int.Parse(curPicture.Name[curPicture.Name.Length - 2].ToString());
                    col = int.Parse(curPicture.Name[curPicture.Name.Length - 1].ToString());
                    picturesMatrix[row, col] = curPicture.Text;
                }
            return picturesMatrix;
        }

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
                sign.Enabled = false;
            }
            else
            {
                sign.Image = Resources.circle;
                m_IsFirstPlayer = true;
                sign.Enabled = false;

            }
        }
    }
}
