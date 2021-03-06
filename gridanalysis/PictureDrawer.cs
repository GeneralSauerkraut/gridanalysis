﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace gridanalysis
{
    static class PictureDrawer
    {

        public static void Draw(double[,] over, string nname)
        {
            double[,] data = over;
            string file = @"C:\Ginger\" + nname + ".png";

            GeneratePicture(data,file);
        }

        public static void Draw(int[,] over, string nname)
        {
            double[,] data = new double[over.GetLength(0), over.GetLength(1)];
            for (int i = 0; i < over.GetLength(0); i++)
                for (int j = 0; j < over.GetLength(1); j++)
                    data[i, j] = Convert.ToDouble(over[i, j]);

            string file = @"C:\Ginger\" + nname + ".png";

            GeneratePicture(data,file);
        }

        private static void GeneratePicture(double[,] data, string name)
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
                    if (data[i, j] < min && data[i, j] >= 0)
                        min = data[i, j];
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if(data[i,j]<0)
                    {
                        color[i, j] = Color.FromArgb(0, 0, 255);
                    }
                    else
                    {
                        color[i, j] = GetColor(max, min, data[i, j]);
                    }

                    bitmap.SetPixel(j, i, color[i, j]);
                }
            }

            SavePicture(bitmap,name);
        }

        private static Color GetColor(double rangeStart /*Complete Red*/, double rangeEnd /*Complete Green*/, double actualValue)
        {
            double max = rangeEnd - rangeStart; // make the scale start from 0
            double value = actualValue - rangeStart; // adjust the value accordingly

            double red = (255 * value) / max; // calculate green (the closer the value is to max, the greener it gets)
            double green = 255 - red; // set red as inverse of green

            return Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), 0);
        }

        public static void SavePicture(Bitmap bit, string file)
        {
            bit.Save(file, ImageFormat.Png);
        }
    }
}
