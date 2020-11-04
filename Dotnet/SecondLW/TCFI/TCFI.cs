using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCFI
{
    public partial class TCFI : Form
    {
        public TCFI()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openImage.FileName);
            }
        }
        private void OpenJPGInStripMenu_Click(object sender , EventArgs e)
        {
            if (openJPG.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openJPG.FileName);
            }
        }
        private void OpenBMPInStripMenu_Click(object sender, EventArgs e)
        {
            if (openBMP.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openBMP.FileName);
            }
        }

        private void OpenPNGInStripMenu_Click(object sender, EventArgs e)
        {
            if (openPNG.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openPNG.FileName);
            }
        }

        #region CreateAndPaintRectangleOnPictureBox
        private Point RectStartPoint;

        // Start Rectangle
        //
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            Invalidate();
        }

        private Rectangle Rect = new Rectangle();

        // Draw Rectangle
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

            label9.Text = RectStartPoint.X.ToString();
            label10.Text = RectStartPoint.Y.ToString();
            label11.Text = tempEndPoint.X.ToString();
            label12.Text = tempEndPoint.Y.ToString();

            pictureBox1.Invalidate();


        }

        /// <summary>
        /// Draw Area on PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Brush selectionBrush = new SolidBrush(Color.FromArgb(200, 200, 200, 220));

            if (pictureBox1.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rect.Contains(e.Location))
                {
                    Debug.WriteLine("Right click");
                }
            }
        }
        #endregion

        private void GetInformationAboutPicture(object sender , EventArgs e)
        {
            if (openImage.FileName == null || openImage.FileName == "")
                return;

            Bitmap image = new Bitmap(openImage.FileName);

            GetColorsCount(ref image);
            GetPixelsCount(ref image);
            GetSizeOfImage(ref image);
        }

        private void GetColorsCount(ref Bitmap image)
        {
            List<Color> allColorsInImage = new List<Color>(image.Width * image.Height);
            ushort colorNumber = 1;

            for (uint y = 0; y < image.Height; y++)
            {
                for (uint x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel((int)x, (int)y);
                    if (!allColorsInImage.Contains(color))
                    {
                        allColorsInImage.Add(color);
                        listBox1.Items.Add($"{colorNumber}: R:{color.R} G:{color.G} B:{color.B}");
                        colorNumber++;
                    }
                }
            }
            textBox1.Text = Convert.ToString(allColorsInImage.Count());
        }
        private void GetPixelsCount(ref Bitmap image)
        {
            textBox2.Text = (image.Width * image.Height).ToString();
        }
        private void GetSizeOfImage(ref Bitmap image)
        {
            textBox3.Text = image.Size.Width.ToString();
            textBox4.Text = image.Size.Height.ToString();
        }

        private void ClearPictureBox(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            pictureBox1.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            listBox1.Items.Clear();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

            }
        }
    }


    public abstract class RenderPage
    {
        protected byte counter;

        protected static byte counterr;
        public abstract void SetCounterVariable();
    }


}
