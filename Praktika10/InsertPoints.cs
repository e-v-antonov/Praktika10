using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika10
{
    class InsertPoints: Avtoriz
    {
        public static SqlConnection connect = new SqlConnection("Data Source = LAPTOP-49BSPC54\\БДАНТОНОВЕВ; Initial Catalog = Tetris; Persist Security Info = True; " +
              "User ID = sa; Password = \"12345\"");
        //Avtoriz avtoriz = new Avtoriz();

        public void Insert(int ochki)
        {
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand("select count(*) from dbo.Result where (dbo.Result.points = " + ochki + ")", connect);
                int loginCount = Convert.ToInt32(command.ExecuteScalar().ToString());
                connect.Close();

                if (loginCount == 0)
                {
                    try
                    {
                        SqlCommand comanda = new SqlCommand("insert into [dbo].[Result] ([points]) values (" + ochki + ")", connect);
                        connect.Open();
                        comanda.ExecuteNonQuery();
                        connect.Close();
                    }
                    catch
                    { }
                }

                connect.Open();
                command = new SqlCommand("select dbo.User_Login.id_user from dbo.User_Login where (dbo.User_Login.login = '" + user + "')", connect);
                int userID = Convert.ToInt32(command.ExecuteScalar().ToString());
                command = new SqlCommand("select dbo.Result.id_result from dbo.Result where (dbo.Result.points = " + ochki + ")", connect);
                int pointID = Convert.ToInt32(command.ExecuteScalar().ToString());
                SqlCommand zaprosInsert = new SqlCommand("insert into dbo.Relation (user_id, result_id) values (" + userID + ", " + pointID + ")", connect);
                zaprosInsert.ExecuteNonQuery();
                connect.Close();
            }
            catch
            { }


        }
    }
}
