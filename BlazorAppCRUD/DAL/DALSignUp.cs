using System.Data.SqlClient;
using BlazorAppCRUD.Model;
using Microsoft.JSInterop;

namespace BlazorAppCRUD.DAL
{
    public static class DALSignUp
    {
        public static bool Add(EntSignup entLogin)
        {
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserData (Email, Password, FirstName, LastName, Address, FatherName, PhoneNumber) VALUES (@Email, @Password, @FirstName, @LastName, @Address, @FatherName, @PhoneNumber)", con);
                cmd.Parameters.AddWithValue("@Email", entLogin.Email);
                cmd.Parameters.AddWithValue("@Password", entLogin.Password);
                cmd.Parameters.AddWithValue("@FirstName", entLogin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entLogin.LastName);
                cmd.Parameters.AddWithValue("@Address", entLogin.Address);
                cmd.Parameters.AddWithValue("@FatherName", entLogin.FatherName);
                cmd.Parameters.AddWithValue("@PhoneNumber", entLogin.PhoneNumber);
                int a = cmd.ExecuteNonQuery();
                
           
                if(a==0)
                 {
                     return false;
                 }
                con.Close();
                return true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // public static bool Add(EntSignup entLogin)
        // {
        //     using (SqlConnection con = DBHelper.GetConnection())
        //     {
        //         try
        //         {
        //             con.Open();

        //             // Check if the email already exists in the database
        //             using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM UserData WHERE Email = @Email", con))
        //             {
        //                 checkCmd.Parameters.AddWithValue("@Email", entLogin.Email);
        //                 int userCount = (int)checkCmd.ExecuteScalar();

        //                 if (userCount == 0)
        //                 {
        //                     // The email is not present, so we can insert the new user
        //                     using (SqlCommand insertCmd = new SqlCommand("INSERT INTO UserData (Email, Password, FirstName, LastName, Address, FatherName, PhoneNumber) VALUES (@Email, @Password, @FirstName, @LastName, @Address, @FatherName, @PhoneNumber)", con))
        //                     {
        //                         insertCmd.Parameters.AddWithValue("@Email", entLogin.Email);
        //                         insertCmd.Parameters.AddWithValue("@Password", entLogin.Password);
        //                         insertCmd.Parameters.AddWithValue("@FirstName", entLogin.FirstName);
        //                         insertCmd.Parameters.AddWithValue("@LastName", entLogin.LastName);
        //                         insertCmd.Parameters.AddWithValue("@Address", entLogin.Address);
        //                         insertCmd.Parameters.AddWithValue("@FatherName", entLogin.FatherName);
        //                         insertCmd.Parameters.AddWithValue("@PhoneNumber", entLogin.PhoneNumber);

        //                         insertCmd.ExecuteNonQuery();
        //                     }
        //                 }
        //                 else
        //                 {

        //                     // The email is already in use, set a flag to indicate the duplicate
        //                     return true;
        //                 }
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             throw; // Handle the exception appropriately in your application
        //         }
        //     }

        //     // If the email is not a duplicate, return false
        //     return false;
        // }


        public static List<EntSignup> GetAll()
        {
            List<EntSignup> lstEntSignup = new List<EntSignup>();
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
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

        public static void Update(EntSignup entSignup)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
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
        public static void Delete(int Id)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM UserData WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static EntSignup GetById(int Id)
        {
            EntSignup entSignup = new EntSignup();
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
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