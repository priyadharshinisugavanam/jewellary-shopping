using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewelShopping
{
    class Statements
    {
        
        public string nameString = "Enter the Name";
        public string passwordString = "Enter the pasword";
        public string mailId = "Enter the Mail Id";
        public string phoneNumber = "Enter the Phone Number";
        public string adminAddString = "Admin Added";
        public string adminNotAddString = "Admin not Added";
        public string loginStirng = "Login Successful";
        public string secondLoginString = "Login failed";
        public string reEnterName = "Re-Enter the Name";
        public string nameSmallString = "Entered Name is too small";
        public string correctName = "Enter the Name in  correct Format";
        public string invalidString = "Invalid";
        public string reEnterPhone = "Re-Enter the Phone Number";
        public string  invalidPhone = "Invalid Phone Number";
        public string correctPhone = "Enter the Phone Number in  correct Format";
        public string reEnterMail = "Invalid Mail Id Re-Enter the Mail Id";
        public string invalidMail = "Invalid Mail Id";
        public string correcrForamt = "The Format shoud have a caps letter,a special character and number";
        public string reEnterPassword = "Re-Enter the Password";
        public string correctPassword = "Enter the password in correct format";
        public string productNameAdd = "Enter the name of the Product ";
        public string productRange = "Enter the Range of the Product";
        public string productAdd = "Product Added";
        public string productNotAdd = "Product  is Not Added";
        public string productDeleted = "Product is Deleted";
        public string productNotDeleted = "Prodcut is not Deleted";
        public string welcomeMessage = "**********************************************Mathre Jewellary Shopping*************************************************";
        public string optionMessage = "Enter the Option";
        public string loginMessage = "Do you want to login now?";
        public string userOption = "If yes press 1 or press 2 to exit";




    }
    class Connection
    {
        public static SqlConnection getDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
    public enum MajorOption
    {
        Admin,
        User,
        Exit

    };
    //enum for User
    public enum UserOption
    {
        SignUp,
        Login,
        Exit
    };
    //Enum for admin operation
    public enum AdminOption
    {
        AddAdmin,
        AdminLogin,
        Exit

    };
    public enum AdminLoginOption
    {
        AddProduct,
        ViewProduct,
        RemoveProduct,
        Exit
    }


}
