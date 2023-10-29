using System.Data.SqlClient;
namespace BlazorAppCRUD.DAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection() 
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VK305MS\SQLEXPRESS;Initial Catalog=User;Integrated Security=True");
            return con;
        }
    }
}