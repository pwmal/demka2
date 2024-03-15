using Npgsql;
using System.Data;

namespace demka2
{
    public class DBCON
    {
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();
        public static NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=demka2;Username=postgres;Password=1234;");

        public static void sqlToDb(string command)
        {
            try
            {
                connection.Open();
                //NpgsqlCommand cmd = new NpgsqlCommand(command, connection);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command, connection);
                ds = new DataSet();
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
            
        }

        public static void sqlToDbWithChanges (string command) 
        {
            try
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch 
            { 
                connection.Close();
            }
        }

        //public static List<tovar> getAllTovars()
        //{
        //    List<tovar> lst = new List<tovar>();

        //    sqlToDb("SELECT * FROM tovar");

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        tovar temp = new tovar();
        //        temp.id = Convert.ToInt32(dt.Rows[i][0]);
        //        temp.name_t = dt.Rows[i][1].ToString();
        //        temp.price = Convert.ToDouble(dt.Rows[i][2]);
        //        temp.articul = dt.Rows[i][3].ToString();
        //        temp.photo = dt.Rows[i][4].ToString();
        //        temp.quantity = Convert.ToInt32(dt.Rows[i][5]);

        //        lst.Add(temp);
        //    }

        //    return lst;
        //}

        public static List<tovar> getSelectedTovars(string str)
        {
            List<tovar> lst = new List<tovar>();

            sqlToDb(str);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tovar temp = new tovar();
                temp.id = Convert.ToInt32(dt.Rows[i][0]);
                temp.name_t = dt.Rows[i][1].ToString();
                temp.price = Convert.ToDouble(dt.Rows[i][2]);
                temp.articul = dt.Rows[i][3].ToString();
                temp.photo = dt.Rows[i][4].ToString();
                temp.quantity = Convert.ToInt32(dt.Rows[i][5]);

                lst.Add(temp);
            }

            return lst;
        }
    }
}
