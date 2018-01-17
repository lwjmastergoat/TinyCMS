using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyRepo.Models;
using DDMF;
using System.Data.SqlClient;

namespace TinyRepo.Factories
{
    public class FactoryUsers : AutoFac<Users>
    {
        public Users Login(string Username, string Password)
        {
            string SQL = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password";

            using(SqlCommand cmd = new SqlCommand(SQL, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                Mapper<Users> mapper = new Mapper<Users>();
                SqlDataReader reader = cmd.ExecuteReader();

                Users user = new Users();

                if (reader.Read())
                {
                    user = mapper.Map(reader);
                }

                reader.Close();
                cmd.Connection.Close();

                return user;
            }
        }

    }
}
