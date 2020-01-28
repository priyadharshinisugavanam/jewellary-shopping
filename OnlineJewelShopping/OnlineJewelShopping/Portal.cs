using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewelShopping
{
    class Portal
    {
        class Home
        {

            static void Main(String[] args)
            {
                try
                {
                    UserAdminModules display = new UserAdminModules();
                    display.AdminUserOperation();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();

            }
        }
    }
}
