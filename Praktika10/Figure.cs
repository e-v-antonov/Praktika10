using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika10
{
    class Figure
    {
        public Random selectFigure = new Random();
        public static int[,] figure = new int[2, 4];
        public static int numberColorFigure;
        public Random selectColorFigure = new Random();

        public void ChoiceFigure()
        {
            switch (selectFigure.Next(7))
            {
                case 0:
                    figure = new int[,] {
                                            {0, 0, 0, 0},
                                            {6, 7, 8, 9}
                                        };     //первые значения - положение по Y, вторые  - по X
                    break;
                case 1:
                    figure = new int[,] {
                                            {0, 1, 0, 1},
                                            {7, 7, 8, 8}
                                        };
                    break;
                case 2:
                    figure = new int[,] {
                                            {1, 1, 0, 1},
                                            {6, 7, 8, 8}
                                        };
                    break;
                case 3:
                    figure = new int[,] {
                                            {0, 1, 1, 1},
                                            {6, 6, 7, 8}
                                        };
                    break;
                case 4:
                    figure = new int[,] {
                                            {0, 0, 1, 1},
                                            {7, 8, 8, 9}
                                        };
                    break;
                case 5:
                    figure = new int[,] {
                                            {0, 0, 1, 1},
                                            {9, 8, 8, 7}
                                        };
                    break;
                case 6:
                    figure = new int[,] {
                                            {0, 1, 1, 1},
                                            {7, 6, 7, 8}
                                        };
                    break;
            }

            numberColorFigure = selectColorFigure.Next(10);
        }
    }
}
