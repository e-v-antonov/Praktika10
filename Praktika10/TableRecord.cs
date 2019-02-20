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
    public partial class TableRecord : Form
    {
        public static SqlConnection sql = new SqlConnection("Data Source = LAPTOP-49BSPC54\\БДАНТОНОВЕВ; Initial Catalog = Tetris; Persist Security Info = True; " +
               "User ID = sa; Password = \"12345\"; MultipleActiveResultSets=True");

        public SqlCommand command = new SqlCommand("select [dbo].[User_Login].[login] as 'Игрок', [dbo].[Result].[points] as 'Количество очков' from [dbo].[Relation] join [dbo].[User_Login] on [dbo].[User_Login].[id_user] = [dbo].[Relation].[user_id] join [dbo].[Result] on [dbo].[Result].[id_result] = [dbo].[Relation].[result_id]");

        public TableRecord()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            command.Connection = sql;
            sql.Open();
            DataTable data = new DataTable();
            data.Load(command.ExecuteReader());
            dataGridView1.DataSource = data;
            sql.Close();
        }

        private void TableRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
