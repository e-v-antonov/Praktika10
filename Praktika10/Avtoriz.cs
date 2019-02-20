using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika10
{
    public partial class Avtoriz : Form
    {
        public static SqlConnection connect = new SqlConnection("Data Source = LAPTOP-49BSPC54\\БДАНТОНОВЕВ; Initial Catalog = Tetris; Persist Security Info = True; " +
               "User ID = sa; Password = \"12345\"");
        public static string user;
        public static bool simpleGame = false;

        public Avtoriz()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand("select dbo.User_Login.id_user from dbo.User_Login where (dbo.User_Login.login = '" + tbLogin.Text + "') and (dbo.User_Login.password = '" + tbPassword.Text + "')", connect);
                int loginCount = Convert.ToInt32(command.ExecuteScalar().ToString());

                if (loginCount > 0)
                {
                    user = tbLogin.Text;
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка аутентификации");
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка аутентификации");
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnRegistr_Click(object sender, EventArgs e)
        {
            try
            {                
                SqlCommand command = new SqlCommand("insert into [dbo].[User_Login] ([login], [password]) values ('" +  tbLogin.Text + "', '" + tbPassword.Text + "')", connect);
                connect.Open();
                command.ExecuteNonQuery();
                user = tbLogin.Text;
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации!", "Ошибка регистрации");
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnSimpleGame_Click(object sender, EventArgs e)
        {
            simpleGame = true;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
