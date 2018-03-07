using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace gridanalysis
{
    class PictureDrawer
    {
        private double[,] data;
        private string file;

        public PictureDrawer(double[,] over, string nname)
        {
            data = over;
            file = @"C:\Ginger\" + nname + ".png";

            GeneratePicture();
        }

        public PictureDrawer(int[,] over, string nname)
        {
            data = new double[over.GetLength(0), over.GetLength(1)];
            for (int i = 0; i < over.GetLength(0); i++)
                for (int j = 0; j < over.GetLength(1); j++)
                    data[i, j] = Convert.ToDouble(over[i, j]);

            file = @"C:\Ginger\" + nname + ".png";

            GeneratePicture();
        }

        private void GeneratePicture()
        {
            Bitmap bitmap = new Bitmap(1501, 401);
            Color[,] color = new Color[data.GetLength(0), data.GetLength(1)];

            double max = 0;
            double min = 10000;//ugly somehow

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > max)
                        max = data[i, j];
                    if (data[i, j] < min && data[i, j] != -1)
                        min = data[i, j];
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if(data[i,j]==-1)
                    {
                        color[i, j] = Color.FromArgb(0, 0, 255);
                    }
                    else
                    {
                        color[i, j] = GetColor(max, min, data[i, j]);
                    }
                }
            }

            SavePicture(bitmap);
        }

        Color GetColor(double rangeStart /*Complete Red*/, double rangeEnd /*Complete Green*/, double actualValue)
        {
            double max = rangeEnd - rangeStart; // make the scale start from 0
            double value = actualValue - rangeStart; // adjust the value accordingly

            double red = (255 * value) / max; // calculate green (the closer the value is to max, the greener it gets)
            double green = 255 - red; // set red as inverse of green

            return Color.FromArgb((Byte)red, (Byte)green, (Byte)0);
        }

        public void SavePicture(Bitmap bit)
        {
            bit.Save(file, ImageFormat.Png);
        }
    }
}
