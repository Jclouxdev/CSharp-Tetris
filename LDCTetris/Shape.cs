using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDCTetris
{
    class Shape
    {
        public int Width;
        public int Height;
        public string Color;
        public int[,] Dots;

        private int[,] backupDots;

        public void turn()
        {
            // save the dots values into bakup dots
            // so we can reuse them to rolling back
            backupDots = Dots;

            Dots = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temporary = Width;
            Width = Height;
            Height = temporary;
        }

        public void rollBack()
        {
            Dots = backupDots;

            var temporary = Width;
            Width = Height;
            Height = temporary;
        }
    }
}
