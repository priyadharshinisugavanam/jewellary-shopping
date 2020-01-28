using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineJewelShopping
{

    class AdminClass
    {
        //properties
        
        public  string adminName { get; set; }
        public  string adminPassword { get; set; }
        

    }
    
    //Implementing InterfaceforDetailWindow and extending Adminclass
    class AdminDetails : AdminClass
    {
        Statements statements = new Statements();
        public  SortedList<string,string> admin = new SortedList<string, string>();
        Validation validation = new Validation();
        public void AddAdmin(SqlConnection sqlConnection)
        {
            
            Console.WriteLine(statements.nameString);
            adminName = validation.GetName();
            Console.WriteLine(statements.passwordString);
            adminPassword = validation.GetPassword();
            string sql = "AdminProcedure";
            Console.WriteLine(statements.mailId);
            string mailId = validation.GetMail();
            Console.WriteLine(statements.phoneNumber);
            string phoneNumber = validation.GetPhoneNumber();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlParameter paramm = new SqlParameter();
            sqlCommand.CommandType = CommandType.StoredProcedure;

            paramm.ParameterName = "@UserId";
            paramm.Value = adminName;
            paramm.SqlDbType = SqlDbType.Char;
            paramm.Size = 18;
            sqlCommand.Parameters.Add(paramm);

            paramm = new SqlParameter();
            paramm.ParameterName = "@password";
            paramm.Value = adminPassword;
            paramm.SqlDbType = SqlDbType.Char;
            paramm.Size = 18;
            sqlCommand.Parameters.Add(paramm);

            paramm = new SqlParameter();
            paramm.ParameterName = "@MailId";
            paramm.Value = mailId;
            paramm.SqlDbType = SqlDbType.Char;
            paramm.Size = 20;
            sqlCommand.Parameters.Add(paramm);

            paramm = new SqlParameter();
            paramm.ParameterName = "@PhoneNumber";
            paramm.Value = phoneNumber;
            paramm.SqlDbType = SqlDbType.Char;
            paramm.Size = 13;
            sqlCommand.Parameters.Add(paramm);

            paramm = new SqlParameter();
            paramm.ParameterName = "@Action";
            paramm.Value = 1;
            paramm.SqlDbType = SqlDbType.Int;
            paramm.Size = 18;
            sqlCommand.Parameters.Add(paramm);

            paramm = new SqlParameter();
            paramm.ParameterName = "@RoleOfMemeber";
            paramm.Value = "Admin";
            paramm.SqlDbType = SqlDbType.VarChar;
            paramm.Size = 5;
            sqlCommand.Parameters.Add(paramm);

            sqlConnection.Open();
            int rows = sqlCommand.ExecuteNonQuery();
            if (rows >= 1)
            {
                Console.WriteLine(statements.adminAddString);
            }
            else
            {
                Console.WriteLine(statements.adminNotAddString);
            }

            sqlConnection.Close();



        }
        public override string ToString()
        {
            return adminName + " " + adminPassword;
        }
        public void Login(SqlConnection sqlConnection)
        {
           
            Console.WriteLine(statements.nameString);
            string adminsName = validation.GetName();
            Console.WriteLine(statements.passwordString);
            string adminspassword = validation.GetPassword();
            string sql = "Select_AdminProcedure";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserId";
            param.Value = adminsName;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 18;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@password";
            param.Value = adminspassword;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 18;
            sqlCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Action";
            param.Value = 2;
            param.SqlDbType = SqlDbType.Int;
            param.Size = 18;
            sqlCommand.Parameters.Add(param);
            
            param = new SqlParameter();
            param.ParameterName = "@RoleOfMemeber";
            param.Value = "Admin";
            param.SqlDbType = SqlDbType.Char;
            param.Size = 5;
            sqlCommand.Parameters.Add(param);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "REPOSITARY");

            AdminClass adminClass = new AdminClass();

            foreach (DataRow row in dataSet.Tables["REPOSITARY"].Rows)
            {
                UserAdminModules user = new UserAdminModules();
                adminClass.adminName = row[0].ToString().Trim();
                adminClass.adminPassword = row[1].ToString().Trim();
                if (adminClass.adminName == adminsName && adminClass.adminPassword == adminspassword)
                {
                    Console.WriteLine(statements.loginStirng);
                    user.AdminsWork();
                }
                else
                {
                    Console.WriteLine(statements.secondLoginString);
                }
            }
        }
      
        

    }
}



