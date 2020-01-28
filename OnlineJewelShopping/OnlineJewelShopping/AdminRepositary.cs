using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OnlineJewelShopping
{
    class AdminRepositary
    {
        SqlConnection sqlConnection = Connection.getDetails();
        AdminDetails adminDetails = new AdminDetails();
        public void SignUpDetails()
        {

            adminDetails.AddAdmin(sqlConnection);
        }
        public void LoginDetails()
        {
            adminDetails.Login(sqlConnection);

        }
    }
}
