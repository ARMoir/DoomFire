using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DoomFire
{
    public partial class DoomFire : Form
    {
        public static class Globals
        {
            public static int CJS_TICKER_FPS = 27;

            public static int FIRE_WIDTH = 256;

            public static int FIRE_HEIGHT = 128;

            public static Random random = new Random();

            public static Bitmap bitmap;

            public static Color[] firePal = new Color[37];

            public static int[] firePixels = new int[Globals.FIRE_WIDTH * Globals.FIRE_HEIGHT];

            public static int[] fireRGB = {
                0x07, 0x07, 0x07, 0x1F, 0x07, 0x07, 0x2F, 0x0F, 0x07, 0x47, 0x0F, 0x07, 0x57, 0x17, 0x07, 0x67,
                0x1F, 0x07, 0x77, 0x1F, 0x07, 0x8F, 0x27, 0x07, 0x9F, 0x2F, 0x07, 0xAF, 0x3F, 0x07, 0xBF, 0x47,
                0x07, 0xC7, 0x47, 0x07, 0xDF, 0x4F, 0x07, 0xDF, 0x57, 0x07, 0xDF, 0x57, 0x07, 0xD7, 0x5F, 0x07,
                0xD7, 0x5F, 0x07, 0xD7, 0x67, 0x0F, 0xCF, 0x6F, 0x0F, 0xCF, 0x77, 0x0F, 0xCF, 0x7F, 0x0F, 0xCF,
                0x87, 0x17, 0xC7, 0x87, 0x17, 0xC7, 0x8F, 0x17, 0xC7, 0x97, 0x1F, 0xBF, 0x9F, 0x1F, 0xBF, 0x9F,
                0x1F, 0xBF, 0xA7, 0x27, 0xBF, 0xA7, 0x27, 0xBF, 0xAF, 0x2F, 0xB7, 0xAF, 0x2F, 0xB7, 0xB7, 0x2F,
                0xB7, 0xB7, 0x37, 0xCF, 0xCF, 0x6F, 0xDF, 0xDF, 0x9F, 0xEF, 0xEF, 0xC7, 0xFF, 0xFF, 0xFF };
        }

        public DoomFire()
        {
            InitializeComponent();

            Ticker.Interval = Globals.CJS_TICKER_FPS;

            Globals.bitmap = new Bitmap(Convert.ToInt32(Globals.FIRE_WIDTH), Convert.ToInt32(Globals.FIRE_HEIGHT), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (var i = 0; i < 37; i++)
            {

                Globals.firePal[i] = Color.FromArgb((Globals.fireRGB[i * 3 + 0]), (Globals.fireRGB[i * 3 + 1]), (Globals.fireRGB[i * 3 + 2]));

            }

            for (var i = 0; i < Globals.FIRE_WIDTH * Globals.FIRE_HEIGHT; i++)
            {

                Globals.firePixels[i] = 0;

            }

            for (var i = 0; i < Globals.FIRE_WIDTH; i++)
            {

                Globals.firePixels[(Globals.FIRE_HEIGHT - 1) * Globals.FIRE_WIDTH + i] = 36;

            }

        }

        public int DrawPixel(int x, int y, int pixel)
        {

            Globals.bitmap.SetPixel(x, y, Globals.firePal[pixel]);

            return pixel;

        }

        public int SpreadFire(int pixel, int curSrc, int counter, int srcOffset, int rand, int width)
        {

            if (pixel != 0)
            {

                int randIdx = Globals.random.Next(0, 255);

                int tmpSrc;

                rand = (rand + 2) & 255;

                tmpSrc = curSrc + (((counter - (randIdx & 3)) + 1) & (width - 1));

                Globals.firePixels[tmpSrc - Globals.FIRE_WIDTH] = pixel - (randIdx & 1);

            }
            else
            {

                Globals.firePixels[srcOffset - Globals.FIRE_WIDTH] = 0;

            }

            return rand;
        }

        public void DoFire()
        {

            int counter = 0;

            int rand = Globals.random.Next(0, 255);

            int curSrc = Globals.FIRE_WIDTH;

            while (counter < Globals.FIRE_WIDTH) 

            {

                int srcOffset = (curSrc + counter);

                int pixel = Globals.firePixels[srcOffset];

                int step = 2;

                rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, Globals.FIRE_WIDTH);

                curSrc += Globals.FIRE_WIDTH;

                srcOffset += Globals.FIRE_WIDTH;

                while (step < Globals.FIRE_HEIGHT) 

                {

                    pixel = Globals.firePixels[srcOffset];

                    step += 2;

                    rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, Globals.FIRE_WIDTH);

                    pixel = Globals.firePixels[srcOffset + Globals.FIRE_WIDTH];

                    curSrc += Globals.FIRE_WIDTH;

                    srcOffset += Globals.FIRE_WIDTH;

                    rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, Globals.FIRE_WIDTH);

                    curSrc += Globals.FIRE_WIDTH;

                    srcOffset += Globals.FIRE_WIDTH;

                } 

                counter++;

                curSrc -= ((Globals.FIRE_WIDTH * Globals.FIRE_HEIGHT) - Globals.FIRE_WIDTH);

            } 
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {

            DoFire();

            for (var h = 0; h < Globals.FIRE_HEIGHT; h++)
            {

                for (var w = 0; w < Globals.FIRE_WIDTH; w++)
                {

                    var p = Globals.firePixels[h * Globals.FIRE_WIDTH + w];

                    DrawPixel(w, h, p);

                }

            }

            Stage.SizeMode = PictureBoxSizeMode.StretchImage;

            Stage.Image = Globals.bitmap;

        }
    }
}
