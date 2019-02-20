using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace Praktika10
{
    public partial class Diagram : Form
    {
        private static string connectionstring = "Data Source = LAPTOP-49BSPC54\\БДАНТОНОВЕВ; Initial Catalog = Tetris; Persist Security Info = True; User ID = sa; Password = \"12345\"";
        private static string zapros;  
        List<int> data = new List<int>();
        string header = "Отношение количества очков к общему количеству";
        int n = 0; // кол-во кусков пирога
        int[] dat;  //значения окружности
        double[] p; //процентное содержание
        string[] title; //названия
        int kol_vo;
        int sizeArray = 0;


        public Diagram()
        {
            InitializeComponent();

            zapros = "select  [dbo].[Result].[points] from [dbo].[Relation] join [dbo].[User_Login] on [dbo].[User_Login].[id_user] = [dbo].[Relation].[user_id] join [dbo].[Result] on [dbo].[Result].[id_result] = [dbo].[Relation].[result_id] where ([dbo].[User_Login].[login] = '" + Avtoriz.user + "')";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(zapros, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            data.Add(reader.GetInt32(0));
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            data.Sort();

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i - 1] != data[i])
                    sizeArray++;
            }
            sizeArray++;

            dat = new int[sizeArray];
            title = new string[sizeArray];
            p = new double[sizeArray];
            

            int k = 0;
            foreach (var val in data.Distinct())
            {
                title[k] = val.ToString(); ;
                dat[k] = data.Where(x => x == val).Count();
                k++;
            }
            n = dat.Length;

            Paint += new PaintEventHandler(CDiagram);

            double sum = 0;

            for (int j = 0; j < n; j++)
                sum += dat[j];
            for (int j = 0; j < n; j++)
                p[j] = (double)(dat[j] / sum);
        }

        private void CDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font headerFont = new Font("Tahoma", 12, FontStyle.Bold);
            int x = (ClientSize.Width - (int)g.MeasureString(header, headerFont).Width) / 2;
            g.DrawString(header, headerFont, Brushes.Green, x, 10);

            Font legendFont = new Font("Tahoma", 9);
            int diametr = ClientSize.Height - 70, //диаметр диаграммы
                x0 = 30,    //координаты левого верхнего угла
                y0 = (ClientSize.Height - diametr) / 2 + 10,
                legendx = 60 + diametr,    //область легенды
                legendy = y0 + (diametr - n * 20 + 10) / 2,
                swe,    //длина дуги сектора
                sta = -90;  //начальная точка сектора
            Brush fBrush = new SolidBrush(Color.White);

            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                swe = (int)(360 * p[i]);
                switch (i)
                {
                    case 0:
                        fBrush = Brushes.YellowGreen;
                        break;
                    case 1:
                        fBrush = Brushes.Chocolate;
                        break;
                    case 2:
                        fBrush = Brushes.Gold;
                        break;
                    case 3:
                        fBrush = Brushes.Pink;
                        break;
                    case 4:
                        fBrush = Brushes.Violet;
                        break;
                    case 5:
                        fBrush = Brushes.Orange;
                        break;
                    case 6:
                        fBrush = Brushes.OrangeRed;
                        break;
                    case 7:
                        fBrush = Brushes.RoyalBlue;
                        break;
                    case 8:
                        fBrush = Brushes.SteelBlue;
                        break;
                    case 9:
                        fBrush = Brushes.LightCyan;
                        break;
                    default:
                        fBrush = new SolidBrush(Color.FromArgb(GenerateDigit(rng), GenerateDigit(rng), GenerateDigit(rng)));
                        break;
                }

                if (i == n - 1)
                    swe = 270 - sta; //вся область закрыта

                g.FillPie(fBrush, x0, y0, diametr, diametr, sta, swe);
                g.DrawPie(Pens.Black, x0, y0, diametr, diametr, sta, swe);

                g.FillRectangle(fBrush, legendx, legendy + i * 20, 20, 10);
                g.DrawRectangle(Pens.Black, legendx, legendy + i * 20, 20, 10);
                g.DrawString(title[i] + " - " + p[i].ToString("P"), legendFont, Brushes.Black, legendx + 24, legendy + i * 20 - 3);

                sta += swe;

            }
        }

        static int GenerateDigit(Random rng)
        {
            return rng.Next(255);
        }

        private void Diagram_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Diagram_Load(object sender, EventArgs e)
        {

        }
    }
}
