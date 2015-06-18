using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Main.BUS
{
    public class Connection
    {
        private static string connectionString = null;
        private static string databaseName = "QUANLYQUANHEKHACHHANG";
        public static string getConnectionString()
        {
            if (connectionString == null)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                path = Directory.GetParent(path).ToString();
                path = Directory.GetParent(path).ToString();
                path = Directory.GetParent(path).ToString();
                path += "\\Database\\" + databaseName;



                connectionString = (@"Data Source=localhost; AttachDbFilename=" + path + ".mdf" + ";Integrated Security=true;User Instance=true;");
                System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(connectionString);
                string query = String.Format("IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'{0}') BEGIN CREATE DATABASE {1}  ON (FILENAME = '{2}'), (FILENAME = '{3}') FOR ATTACH; END", databaseName, databaseName, path + ".mdf", path + "_log.ldf");

                try
                {
                    //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, connect);
                    connect.Open();
                    //cmd.ExecuteNonQuery();
                    connect.Close();

                    //connectionString = (@"Server=localhost; AttachDbFilename=" + path + ".mdf" + ";Database = " + databaseName + ";Trusted_Connection=Yes");
                    //connectionString = (@"Data Source=localhost; Database=" + databaseName + ";Integrated Security=True;Connect Timeout=30;User Instance=True");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                    Application.Exit();
                }
            }

            return connectionString;
            
        }
    }
}
