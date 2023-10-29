using System.Data.SqlClient;
using BlazorAppCRUD.Model;

namespace BlazorAppCRUD.DAL
{
    public static class DALLogin
    {
        public static void Add(EntLogin entLogin)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Login (Username, Password) VALUES (@Username, @Password)", con);
                cmd.Parameters.AddWithValue("@Email", entLogin.Username);
                cmd.Parameters.AddWithValue("@Password", entLogin.Password);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        // public static void Update(EntLogin entLogin){
        //     using(SqlConnection con = DBHelper.GetConnection()){
        //         SqlCommand cmd = new SqlCommand("UPDATE Login SET Username = @Username, Password = @Password WHERE Id = @Id", con);
        //         cmd.Parameters.AddWithValue("@Id", entLogin.Id);
        //         cmd.Parameters.AddWithValue("@Username", entLogin.Username);
        //         cmd.Parameters.AddWithValue("@Password", entLogin.Password);
        //         con.Open();
        //         cmd.ExecuteNonQuery();
        //     }
        // }
        // public static void Delete(int Id){
        //     using(SqlConnection con = DBHelper.GetConnection()){
        //         SqlCommand cmd = new SqlCommand("DELETE FROM Login WHERE Id = @Id", con);
        //         cmd.Parameters.AddWithValue("@Id", Id);
        //         con.Open();
        //         cmd.ExecuteNonQuery();
        //     }
        // }
        // public static EntLogin GetById(int Id){
        //     EntLogin entLogin = new EntLogin();
        //     using(SqlConnection con = DBHelper.GetConnection()){
        //         SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Id = @Id", con);
        //         cmd.Parameters.AddWithValue("@Id", Id);
        //         con.Open();
        //         SqlDataReader rdr = cmd.ExecuteReader();
        //         while(rdr.Read()){
        //             entLogin.Id = Convert.ToInt32(rdr["Id"]);
        //             entLogin.Username = rdr["Username"].ToString();
        //             entLogin.Password = rdr["Password"].ToString();
        //         }
        //     }
        //     return entLogin;
        // }
        // public static List<EntLogin> GetAll(){
        //     List<EntLogin> lstEntLogin = new List<EntLogin>();
        //     using(SqlConnection con = DBHelper.GetConnection()){
        //         SqlCommand cmd = new SqlCommand("SELECT * FROM Login", con);
        //         con.Open();
        //         SqlDataReader rdr = cmd.ExecuteReader();
        //         while(rdr.Read()){
        //             EntLogin entLogin = new EntLogin();
        //             entLogin.Id = Convert.ToInt32(rdr["Id"]);
        //             entLogin.Username = rdr["Username"].ToString();
        //             entLogin.Password = rdr["Password"].ToString();
        //             lstEntLogin.Add(entLogin);
        //         }
        //     }
        //     return lstEntLogin;
        // }

    }
}