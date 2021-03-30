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
        public static Bitmap BITMAP { get; set; }
        public static Random RANDOM { get; set; } = new Random();
        public static int CJS_TICKER_FPS { get; set; } = 27;
        public static int FIRE_WIDTH { get; set; } = 256;
        public static int FIRE_HEIGHT { get; set; } = 128;
        public static Color[] FIRE_PAL { get; set; } = new Color[37];
        public static int[] FIRE_PIXELS { get; set; } = new int[FIRE_WIDTH * FIRE_HEIGHT];
        public static int[] FIRE_RGB { get; set; } = {
                0x07, 0x07, 0x07, 0x1F, 0x07, 0x07, 0x2F, 0x0F, 0x07, 0x47, 0x0F, 0x07, 0x57, 0x17, 0x07, 0x67,
                0x1F, 0x07, 0x77, 0x1F, 0x07, 0x8F, 0x27, 0x07, 0x9F, 0x2F, 0x07, 0xAF, 0x3F, 0x07, 0xBF, 0x47,
                0x07, 0xC7, 0x47, 0x07, 0xDF, 0x4F, 0x07, 0xDF, 0x57, 0x07, 0xDF, 0x57, 0x07, 0xD7, 0x5F, 0x07,
                0xD7, 0x5F, 0x07, 0xD7, 0x67, 0x0F, 0xCF, 0x6F, 0x0F, 0xCF, 0x77, 0x0F, 0xCF, 0x7F, 0x0F, 0xCF,
                0x87, 0x17, 0xC7, 0x87, 0x17, 0xC7, 0x8F, 0x17, 0xC7, 0x97, 0x1F, 0xBF, 0x9F, 0x1F, 0xBF, 0x9F,
                0x1F, 0xBF, 0xA7, 0x27, 0xBF, 0xA7, 0x27, 0xBF, 0xAF, 0x2F, 0xB7, 0xAF, 0x2F, 0xB7, 0xB7, 0x2F,
                0xB7, 0xB7, 0x37, 0xCF, 0xCF, 0x6F, 0xDF, 0xDF, 0x9F, 0xEF, 0xEF, 0xC7, 0xFF, 0xFF, 0xFF };

        public DoomFire()
        {
            InitializeComponent();

            TICKER.Interval = CJS_TICKER_FPS;
            BITMAP = new Bitmap(Convert.ToInt32(FIRE_WIDTH), Convert.ToInt32(FIRE_HEIGHT), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (var i = 0; i < 37; i++)
            {
                FIRE_PAL[i] = Color.FromArgb((FIRE_RGB[i * 3 + 0]), (FIRE_RGB[i * 3 + 1]), (FIRE_RGB[i * 3 + 2]));
            }

            for (var i = 0; i < FIRE_WIDTH * FIRE_HEIGHT; i++)
            {
                FIRE_PIXELS[i] = 0;
            }

            for (var i = 0; i < FIRE_WIDTH; i++)
            {
                FIRE_PIXELS[(FIRE_HEIGHT - 1) * FIRE_WIDTH + i] = 36;
            }
        }

        public int DrawPixel(int x, int y, int pixel)
        {
            BITMAP.SetPixel(x, y, FIRE_PAL[pixel]);
            return pixel;
        }

        public int SpreadFire(int pixel, int curSrc, int counter, int srcOffset, int rand, int width)
        {

            if (pixel != 0)
            {
                int randIdx = RANDOM.Next(0, 255);
                int tmpSrc;
                rand = ((rand + 2) & 255);
                tmpSrc = (curSrc + (((counter - (randIdx & 3)) + 1) & (width - 1)));
                FIRE_PIXELS[tmpSrc - FIRE_WIDTH] = pixel - (randIdx & 1);
            }
            else
            {
                FIRE_PIXELS[srcOffset - FIRE_WIDTH] = 0;
            }

            return rand;
        }

        public void DoFire()
        {

            int counter = 0;
            int rand = RANDOM.Next(0, 255);
            int curSrc = FIRE_WIDTH;

            do
            {
                int srcOffset = (curSrc + counter);
                int pixel = FIRE_PIXELS[srcOffset];
                int step = 2;
                rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, FIRE_WIDTH);
                curSrc += FIRE_WIDTH;
                srcOffset += FIRE_WIDTH;

                do
                {
                    pixel = FIRE_PIXELS[srcOffset];
                    step += 2;
                    rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, FIRE_WIDTH);
                    pixel = FIRE_PIXELS[srcOffset + FIRE_WIDTH];
                    curSrc += FIRE_WIDTH;
                    srcOffset += FIRE_WIDTH;
                    rand = SpreadFire(pixel, curSrc, counter, srcOffset, rand, FIRE_WIDTH);
                    curSrc += FIRE_WIDTH;
                    srcOffset += FIRE_WIDTH;

                } while (step < FIRE_HEIGHT);

                counter++;
                curSrc -= ((FIRE_WIDTH * FIRE_HEIGHT) - FIRE_WIDTH);

            } while (counter < FIRE_WIDTH);
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            DoFire();

            for (var h = 0; h < FIRE_HEIGHT; h++)
            {
                for (var w = 0; w < FIRE_WIDTH; w++)
                {
                    var p = FIRE_PIXELS[h * FIRE_WIDTH + w];
                    DrawPixel(w, h, p);
                }
            }

            STAGE.SizeMode = PictureBoxSizeMode.StretchImage;
            STAGE.Image = BITMAP;
        }
    }
}
