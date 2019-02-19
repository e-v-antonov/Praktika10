using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Praktika10
{
    class Field: Figure
    {
        
        public static int widthField = 16;
        public static int heightField = 25;
        public const int cellSize = 20;
        public static int[,] field = new int[widthField, heightField]; //ширина и высота
        public int numberColorField;
        public int[,] colorField = new int[widthField, heightField];
        public Brush[] colorFigure = {Brushes.White, Brushes.Orange, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Honeydew,
            Brushes.Violet, Brushes.Tomato, Brushes.SteelBlue, Brushes.PapayaWhip};
        public static Bitmap bit = new Bitmap(320, 500);
        public static Graphics gr = Graphics.FromImage(bit);

        public void FillField()
        {
            //gr = Graphics.FromImage(bit);
            gr.Clear(Color.Black);

            for (int i = 0; i < widthField; i++)
                for (int j = 0; j < heightField; j++)
                    if (field[i, j] == 1) //если клетка поля существует  
                    {
                        numberColorField = colorField[i, j];
                        gr.FillRectangle(colorFigure[numberColorField], i * cellSize, j * cellSize, (cellSize - 1) * field[i, j], (cellSize - 1) * field[i, j]);
                    }

            for (int i = 0; i < 4; i++) //рисуем падающую фигуру
                gr.FillRectangle(colorFigure[numberColorFigure], figure[1, i] * cellSize, figure[0, i] * cellSize, cellSize - 1, cellSize - 1);

            Program.form1.pBox1.Image = bit;
        }

        public void ResetArray()
        {
            for (int i = 0; i < 16; i++)
                for (int j = 0; j < 25; j++)
                {
                    field[i, j] = 0;
                    colorField[i, j] = 0;
                }
        }
    }
}
