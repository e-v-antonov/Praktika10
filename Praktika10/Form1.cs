using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika10
{
    public partial class Form1 : Form
    {

        public const int cellSize = 20;
        public const int widthField = 10;
        public const int heightField = 20;
        public int[,] figure = new int[2, 4];
        public int[,] field = new int[10, 20]; //ширина и высота
        Graphics gr;
        
        public Form1()
        {
            InitializeComponent();
            ChoiceFigure();
        }

        public void ChoiceFigure()
        {
            Random selectFigure = new Random();

            switch(selectFigure.Next(7))
            {
                case 0:
                    figure = new int[,] {                        
                                            {2, 3, 4, 5}, 
                                            {4, 4, 4, 4}
                                        };     //первые значения - положение по Y, вторые  - по X
                    break;
                case 1:
                    figure = new int[,] {
                                            {2, 3, 2, 3},
                                            {4, 4, 5, 5}
                                        }; 
                    break;
                case 2:
                    figure = new int[,] {
                                            {2, 3, 4, 4}, 
                                            {4, 4, 4, 5}
                                        };
                    break;
                case 3:
                    figure = new int[,] {
                                            {2, 3, 4, 4}, 
                                            {4, 4, 4, 3}
                                        };
                    break;
                case 4:
                    figure = new int[,] {
                                            {3, 3, 4, 4}, 
                                            {3, 4, 4, 5}
                                        };
                    break;
                case 5:
                    figure = new int[,] {
                                            {3, 3, 4, 4}, 
                                            {5, 4, 4, 3}
                                        };
                    break;
                case 6:
                    figure = new int[,] {
                                            {3, 4, 4, 4}, 
                                            {5, 3, 4, 5}
                                        };
                    break;
            }
        }

        //public void FillField()
        //{
        //    for (int i = 0; i < widthFieldField; i++)
        //        for (int j = 0; j < heightFieldField; j++)
        //            if (field[i, j] == 1) //если клетка поля существует          
        //                gr.FillRectangle(Brushes.Green, i * cellSize, j * cellSize, cellSize, cellSize);

        //    for (int i = 0; i < 4; i++) //рисуем падающую фигуру
        //        gr.FillRectangle(Brushes.Red, figure[1, i] * cellSize, figure[0, i] * cellSize, cellSize, cellSize);
        //}

        
        public bool FindError()
        {
            //for (int i = 0; i < 4; i++)
            //    if (field[figure[1, i], figure[0, i]] == 1)
            //        return true;
            for (int i = 0; i < 4; i++)
                if (/*figure[1, i] >= widthField || figure[0, i] >= heightField || figure[1, i] <= 0 || figure[0, i] <= 0 ||*/ field[figure[1, i], figure[0, i]] == 1)
                    return true;
            return false;

            //return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int checkRow = 0;

            if (field[4, 3] == 1)   // Если клетка поля, на которой появляются фигурки заполнены, завершить программу.
            {
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!");
            }

            for (int i = 0; i < 4; i++)
                figure[0, i]++; // Сместить фигурку вниз

            if (FindError() == true)
            {
                for (int i = 0; i < 4; i++)
                    field[figure[1, i], --figure[0, i]]++;
                ChoiceFigure();
            } // Если нашлась ошибка, перенести фигурку на 1 клетку вверх, сохранить её в массив field и создать новую фигурку

            for (int i = heightField - 2; i > 2; i--)
            {
                checkRow = 0;

                for (int j = 0; j < 10; j++)
                {
                    if (field[j, i] == 1)
                        checkRow++;

                    if (checkRow == 10)
                        for (int k = i; k > 1; k--)
                            for (int l = 1; l < widthField- 1; l++)
                                field[l, k] = field[l, k - 1];
                }   // Проверка на заполненность рядом, если нашлись ряды, в которых все клетки заполнены, сместить все ряды, которые находятся выше убранной линии, на 1 вниз
                panel1.Refresh();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < widthField; i++)
                for (int j = 0; j < heightField; j++)
                    if (field[i, j] == 1) //если клетка поля существует          
                        e.Graphics.FillRectangle(Brushes.Green, i * cellSize, j * cellSize, cellSize, cellSize);

            for (int i = 0; i < 4; i++) //рисуем падающую фигуру
                e.Graphics.FillRectangle(Brushes.Red, figure[1, i] * cellSize, figure[0, i] * cellSize, cellSize, cellSize);
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
                        figure[0, i] = yMax - (xMax - figure[1, i]) - 1;
                        figure[1, i] = xMax - (3 - (yMax - temp)) + 1;
                    } 

                    if (FindError() == true)
                        Array.Copy(figureCopy, figure, figure.Length);
                break;
            }
        }
    }
}
