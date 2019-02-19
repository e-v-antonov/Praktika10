using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika10
{
    class Movement: Field
    {
        public bool newGame = false;
        public int points = 0;
        Error error = new Error();

        public void MovementTimer()
        {
            int checkRow = 0;

            if (field[8, 1] == 1)   // Если клетка поля, на которой появляются фигурки заполнены, завершить программу.
            {
                Program.form1.timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!");
                newGame = false;
                Program.form1.btnStart.Enabled = true;
                Program.form1.btnPause.Enabled = false;
                Program.form1.btnContinue.Enabled = false;
                return;
            }

            for (int i = 0; i < 4; i++)
                figure[0, i]++; // Сместить фигурку вниз            

            if (error.FindError() == true)
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
                        Program.form1.label1.Text = points.ToString();
                    }
                }   // Проверка на заполненность рядом, если нашлись ряды, в которых все клетки заполнены, сместить все ряды, которые находятся выше убранной линии, на 1 вниз

                FillField();
            }
        }
    }
}
