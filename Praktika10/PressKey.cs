using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika10
{
    class PressKey: Field
    {
        Error error = new Error();

        public void PressKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    for (int i = 0; i < 4; i++)
                        figure[1, i]--; // Сначала сдвигаем координаты всех кусочков фигуры на 1 влево по оси OX 

                    if (error.FindError() == true) // Если после этого нашлась ошибка
                        for (int i = 0; i < 4; i++)
                            figure[1, i]++; // Возвращаем фигурку обратно на 1 вправо
                    break;

                case Keys.D:
                    for (int i = 0; i < 4; i++)
                        figure[1, i]++;

                    if (error.FindError() == true)
                        for (int i = 0; i < 4; i++)
                            figure[1, i]--;
                    break;

                case Keys.W:
                    int xMax = 0, yMax = 0;
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

                    if (error.FindError() == true)
                        Array.Copy(figureCopy, figure, figure.Length);
                    break;

                case Keys.S:
                    Program.form1.timer1.Interval = 50;
                    break;
            }
        }
    }
}
