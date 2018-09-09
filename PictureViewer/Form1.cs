using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form_1061_1 : Form
    {
        int deg;
        Image gbrAsli;

        public Form_1061_1()
        {
            InitializeComponent();

            pictureBox_1061_1.MouseWheel += scrollHandler_1061;
            panel_1061_1.MouseWheel += scrollHandler_1061;
        }

        private void scrollHandler_1061(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomInStripButton_1061_2_Click(this, null);
            }

            if (e.Delta < 0)
            {
                zoomOutStripButton_1061_3_Click(this, null);
            }
        }

        private void openToolStripButton_1061_1_Click(object sender, EventArgs e)
        {

            if (openFileDialog_1061_1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_1061_1.Image = Image.FromFile(openFileDialog_1061_1.FileName);
                gbrAsli = pictureBox_1061_1.Image;
            }
        }

        private void zoomInStripButton_1061_2_Click(object sender, EventArgs e)
        {
            pictureBox_1061_1.Width = pictureBox_1061_1.Width + 50;
            pictureBox_1061_1.Height = pictureBox_1061_1.Height + 50;
        }

        private void zoomOutStripButton_1061_3_Click(object sender, EventArgs e)
        {
            pictureBox_1061_1.Width = pictureBox_1061_1.Width - 50;
            pictureBox_1061_1.Height = pictureBox_1061_1.Height - 50;
        }

        private void rotateRightStripButton_1061_4_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1061_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (deg > 270)
            {
                pictureBox_1061_1.Image = gbrAsli;
                deg = 0;
                return;
            }

            pictureBox_1061_1.Image = flipImage;
            deg += 90;
        }

        private void rotateLeftStripButton_1061_5_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1061_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (deg < 180)
            {
                pictureBox_1061_1.Image = gbrAsli;
                deg = 0;
                return;
            }

            pictureBox_1061_1.Image = flipImage;
            deg -= 90;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton_1061_6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void toolStripButton_1061_7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rotateRightStripButton_1061_4_Click(this, null);
        }

        private void Form_1061_1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Form_1061_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Right)
            {
                rotateRightStripButton_1061_4_Click(this, null);
            }

            if (e.Control == true && e.KeyCode == Keys.Left)
            {
                rotateLeftStripButton_1061_5_Click(this, null);
            }

            if (e.KeyCode == Keys.Oemplus)
            {
                zoomInStripButton_1061_2_Click(this, null);
            }

            if (e.KeyCode == Keys.OemMinus)
            {
                zoomOutStripButton_1061_3_Click(this, null);
            }
        }

        private void saveToolStripButton_1061_1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save Picture";
            sf.Filter = "Images (*.png)|*.png";

            if (sf.ShowDialog() ==  DialogResult.OK)
            {
                pictureBox_1061_1.Image.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void printToolStripButton_1061_1_Click(object sender, EventArgs e)
        {
            printDialog_1061_1.Document = printDocument_1061_1;

            if(printDialog_1061_1.ShowDialog() == DialogResult.OK)
            {
                printDialog_1061_1.Document.Print();
            }
        }
    }
}
