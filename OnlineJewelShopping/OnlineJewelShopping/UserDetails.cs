using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OnlineJewelShopping
{
    public class UserDetails : UserClass
    {
        //List for Storing user information
        public List<UserClass> database = new List<UserClass>();
        Validation validation = new Validation();


        public void SignUp(SqlConnection sqlConnection)
        {

            Console.WriteLine("Enter the Name");
            userName = validation.GetName();
            Console.WriteLine("Enter the mobile number");
            phoneNumber = validation.GetPhoneNumber();
            Console.WriteLine("Enter the mail id");
            mailId = validation.GetMail();
            Console.WriteLine("Enter the password");
            password = validation.GetPassword();
            Console.WriteLine("Enter the confirm password");
            conformPassword = validation.GetPassword();
            string sql = "UserProcedure";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();

            param.ParameterName = "@UserId";
            param.Value = userName;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 18;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@PhoneNumber";
            param.Value = phoneNumber;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 11;
            sqlCommand.Parameters.Add(param);
            sqlConnection.Close();

            param = new SqlParameter();
            param.ParameterName = "@MailId";
            param.Value = mailId;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 11;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@password";
            param.Value = password;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 20;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@RoleOfMemeber";
            param.Value = "User";
            param.SqlDbType = SqlDbType.Char;
            param.Size = 5;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Action";
            param.Value = 1;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 18;
            sqlCommand.Parameters.Add(param);


            sqlConnection.Open();
            int rows = sqlCommand.ExecuteNonQuery();
            if (rows >= 1 && password.Equals(conformPassword))
            {
                Console.WriteLine("Registered successfully");
            }
            else
            {
                Console.WriteLine("Registration failed");
            }

            sqlConnection.Close();
        }

        public void Login(SqlConnection sqlConnection)
        {
            Console.WriteLine("Enter the Name");
            userName = validation.GetName();
            Console.WriteLine("Enter the Password");
            password = validation.GetPassword();
            string sql = "Select_UserProcedures";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@UserId";
            sqlParameter.Value = userName;
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 18;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@password";
            sqlParameter.Value = password;
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 18;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Action";
            sqlParameter.Value = 2;
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 18;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@RoleOfMemeber";
            sqlParameter.Value = "User";
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 18;
            sqlCommand.Parameters.Add(sqlParameter);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "REPOSITARY");
            foreach (DataRow dataRow in dataSet.Tables["REPOSITARY"].Rows)
            {
                UserClass userClass = new UserClass();
                userClass.userName = dataRow[0].ToString().Trim();
                userClass.password = dataRow[1].ToString().Trim();

                if (userClass.userName.Equals(userName) && userClass.password.Equals(password))
                {
                    Console.WriteLine("Login successfully");

                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }

        }

    }


}
