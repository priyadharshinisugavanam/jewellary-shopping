using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace OnlineJewelShopping
{
    class UserRepositary
    {
        SqlConnection sqlConnection = Connection.getDetails();
        UserDetails userDetails = new UserDetails();
        public  void SignUpDetails()
        {
           
            userDetails.SignUp(sqlConnection);
        }
        public void LoginDetails()
        {
            userDetails.Login(sqlConnection);
            
        }
    }
}
