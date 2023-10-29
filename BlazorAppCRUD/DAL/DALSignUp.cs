using System.Data.SqlClient;
using BlazorAppCRUD.Model;
using Microsoft.JSInterop;

namespace BlazorAppCRUD.DAL
{
    public static class DALSignUp
    {
        public static void Add(EntSignup entLogin)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                try {
                    SqlCommand cmd = new SqlCommand("INSERT INTO UserData (Email, Password,FirstName,LastName,Address,FatherName,PhoneNumber) VALUES (@Email, @Password,@FirstName,@LastName,@Address,@FatherName,@PhoneNumber)", con);
                    cmd.Parameters.AddWithValue("@Email", entLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", entLogin.Password);
                    cmd.Parameters.AddWithValue("@FirstName", entLogin.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", entLogin.LastName);
                    cmd.Parameters.AddWithValue("@Address", entLogin.Address);
                    cmd.Parameters.AddWithValue("@FatherName", entLogin.FatherName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entLogin.PhoneNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)  {
                    
                    throw;
                }
            }
        }
        
        public static List<EntSignup> GetAll(){
            List<EntSignup> lstEntSignup = new List<EntSignup>();
            using(SqlConnection con = DBHelper.GetConnection()){
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
                    EntSignup entSiEntSignup = new EntSignup();
                    string? v = rdr["Id"].ToString();
                    entSiEntSignup.Id = v == null ? 0 : Convert.ToInt32(v);
                    entSiEntSignup.Email = rdr["Email"].ToString();
                    entSiEntSignup.Password = rdr["Password"].ToString();
                    entSiEntSignup.FirstName = rdr["FirstName"].ToString();
                    entSiEntSignup.LastName = rdr["LastName"].ToString();
                    entSiEntSignup.Address = rdr["Address"].ToString();
                    entSiEntSignup.FatherName = rdr["FatherName"].ToString();
                    entSiEntSignup.PhoneNumber = rdr["PhoneNumber"].ToString();
                    lstEntSignup.Add(entSiEntSignup);
                }
            }
            return lstEntSignup;
        }
        
        public static void Update(EntSignup entSignup){
            using(SqlConnection con = DBHelper.GetConnection()){
                SqlCommand cmd = new SqlCommand("UPDATE UserData SET Email = @Email, Password = @Password,FirstName=@FirstName,LastName=@LastName,FatherName=@FatherName,Address=@Address,PhoneNumber=@PhoneNumber WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", entSignup.Id);
                cmd.Parameters.AddWithValue("@Email", entSignup.Email);
                cmd.Parameters.AddWithValue("@Password", entSignup.Password);
                cmd.Parameters.AddWithValue("@FirstName", entSignup.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entSignup.LastName);
                cmd.Parameters.AddWithValue("@Address", entSignup.Address);
                cmd.Parameters.AddWithValue("@FatherName", entSignup.FatherName);
                cmd.Parameters.AddWithValue("@PhoneNumber", entSignup.PhoneNumber);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int Id){
            using(SqlConnection con = DBHelper.GetConnection()){
                SqlCommand cmd = new SqlCommand("DELETE FROM UserData WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static EntSignup GetById(int Id){
            EntSignup entSignup = new EntSignup();
            using(SqlConnection con = DBHelper.GetConnection()){
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
                    entSignup.Id = Convert.ToInt32(rdr["Id"]);
                    entSignup.Email = rdr["Email"].ToString();
                    entSignup.Password = rdr["Password"].ToString();
                    entSignup.FirstName = rdr["FirstName"].ToString();
                    entSignup.LastName = rdr["LastName"].ToString();
                    entSignup.Address = rdr["Address"].ToString();
                    entSignup.FatherName = rdr["FatherName"].ToString();
                    entSignup.PhoneNumber = rdr["PhoneNumber"].ToString();
                }
            }
            return entSignup;
        }
        

    }
}