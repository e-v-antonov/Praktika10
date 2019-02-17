using System;
using System.Drawing;
using System.Windows.Forms;

namespace Praktika10
{
    public partial class Form1 : Form
    {

        public const int cellSize = 20;
        public const int widthField = 16;
        public const int heightField = 25;
        public int[,] figure = new int[2, 4];
        public int[,] field = new int[widthField, heightField]; //ширина и высота
        public Bitmap bit = new Bitmap(cellSize * widthField, cellSize * heightField);
        public Graphics gr;
        public int points = 0;
        public Brush[] colorFigure = {Brushes.White, Brushes.Orange, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Honeydew,
            Brushes.Violet, Brushes.Tomato, Brushes.SteelBlue, Brushes.PapayaWhip};
        public int numberColorFigure;
        public int[,] colorField = new int[widthField, heightField];
        public int numberColorField;
        public Random selectFigure = new Random();
        public Random selectColorFigure = new Random();

        public Form1()
        {
            InitializeComponent();
            gr = Graphics.FromImage(bit);
            ChoiceFigure();
        }

        public void ChoiceFigure()
        {          
            switch(selectFigure.Next(7))
            {
                case 0:
                    figure = new int[,] {
                                            {0, 0, 0, 0}, //{0, 1, 2, 3}, 
                                            {6, 7, 8, 9} //{7, 7, 7, 7}
                                        };     //первые значения - положение по Y, вторые  - по X
                    break;
                case 1:
                    figure = new int[,] {
                                            {0, 1, 0, 1},
                                            {8, 8, 9, 9}
                                        }; 
                    break;
                case 2:
                    figure = new int[,] {
                                            {1, 1, 0, 1},   //{0, 1, 2, 2}, 
                                            {6, 7, 8, 8}    //{6, 7, 8, 9}                                                                                     
                                        };
                    break;
                case 3:
                    figure = new int[,] {
                                            {0, 1, 1, 1},     //{0, 1, 2, 2}, 
                                            {6, 6, 7, 8}     //{8, 8, 8, 7}
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

        public void FillField()
        {
            gr.Clear(Color.Black);

            for (int i = 0; i < widthField; i++)
                for (int j = 0; j < heightField; j++)
                    if (field[i, j] == 1) //если клетка поля существует  
                    {
                        //if (j != 0)
                        {
                            numberColorField = colorField[i, j];
                            gr.FillRectangle(colorFigure[numberColorField], i * cellSize, j * cellSize, (cellSize - 1) * field[i, j], (cellSize - 1) * field[i, j]);
                        }
                    }
            
            for (int i = 0; i < 4; i++) //рисуем падающую фигуру
                gr.FillRectangle(colorFigure[numberColorFigure], figure[1, i] * cellSize, figure[0, i] * cellSize, cellSize - 1, cellSize - 1);

            pBox1.Image = bit;
        }

        public bool FindError()
        {
            for (int i = 0; i < 4; i++)
                if ((figure[1, i] >= widthField) || (figure[0, i] >= heightField) || (figure[1, i] < 0) || (figure[0, i] < 0) || (field[figure[1, i], figure[0, i]] == 1))
                    return true;

            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int checkRow = 0;

            if (field[8, 1] == 1)   // Если клетка поля, на которой появляются фигурки заполнены, завершить программу.
            {
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!");
                return;
            }

            for (int i = 0; i < 4; i++)
                figure[0, i]++; // Сместить фигурку вниз            

            if (FindError() == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    field[figure[1, i], --figure[0, i]]++;
                    colorField[figure[1, i], figure[0, i]] = numberColorFigure;
                }

                ChoiceFigure();
            } // Если нашлась ошибка, перенести фигурку на 1 клетку вверх, сохранить её в массив field и создать новую фигурку

            for (int i = heightField - 1; i > 2; i--)   //можно сделать режим когда 1 строка не пропадает (вместо -1 надо -2)
            {
                checkRow = 0;

                for (int j = 0; j < widthField; j++)
                {
                    if (field[j, i] == 1)
                        checkRow++;

                    if (checkRow == widthField)
                    {
                        for (int z = i; z > 1; z--)
                            for (int w = 0; w < widthField; w++)
                            {
                                field[w, z] = field[w, z - 1];
                                colorField[w, z] = colorField[w, z - 1];
                            }

                        points += 100;
                        label1.Text = points.ToString();
                    }
                }   // Проверка на заполненность рядом, если нашлись ряды, в которых все клетки заполнены, сместить все ряды, которые находятся выше убранной линии, на 1 вниз

                FillField();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    for (int i = 0; i < 4; i++)
                        figure[1, i]--; // Сначала сдвигаем координаты всех кусочков фигуры на 1 влево по оси OX 

                    if (FindError() == true) // Если после этого нашлась ошибка
                        for (int i = 0; i < 4; i++)
                            figure[1, i]++; // Возвращаем фигурку обратно на 1 вправо
                break;

                case Keys.D:
                    for (int i = 0; i < 4; i++)
                        figure[1, i]++;

                    if (FindError() == true)
                        for (int i = 0; i < 4; i++)
                            figure[1, i]--;
                break;

                case Keys.W:
                    int xMax = 0, yMax= 0;
                    int[,] figureCopy = new int[2, 4];

                    Array.Copy(figure, figureCopy, figure.Length); // Создадим копию фигурки,
                    // Найдем максимальные координаты значения фигуры по X и по Y
                    for (int i = 0; i < 4; i++)
                    {
                        if (figure[0, i] > yMax)
                            yMax = figure[0, i];

                        if (figure[1, i] > xMax)
                            xMax = figure[1, i];
                    }
                    // Перевернем фигуру
                    for (int i = 0; i < 4; i++)
                    {
                        int temp = figure[0, i];
                        figure[0, i] = yMax - (xMax - figure[1, i]);
                        figure[1, i] = xMax - (3 - (yMax - temp)) + 2;
                    } 

                    if (FindError() == true)
                        Array.Copy(figureCopy, figure, figure.Length);
                break;

                case Keys.S:
                    timer1.Interval = 50;
                break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                timer1.Interval = 250;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
