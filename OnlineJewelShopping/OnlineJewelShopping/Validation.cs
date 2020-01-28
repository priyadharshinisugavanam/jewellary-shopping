using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace OnlineJewelShopping
{
    


        class Validation
        {
            string userName;
            string phoneNumber;
            string mailId;
            string password;
        Statements statements = new Statements();

            public string GetName()
            {

                try
                {
                    userName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + statements.reEnterName);
                    GetName();
                }
                if (userName.Length < 4)
                {
                    Console.WriteLine(statements.reEnterName);
                    Console.WriteLine(statements.nameSmallString);
                    GetName();
                }
                if (userName != null)
                {
                    int index = 3;
                    for (int i = 0; i < userName.Length - 2; i++)
                    {
                        if ((userName.Substring(i, index).Equals(userName.Substring(i, index)) == false))
                        {
                            Console.WriteLine(statements.invalidString);
                            GetName();
                        }
                    }
                }
                Regex check = new Regex(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$");
                if (check.IsMatch(userName) == false)
                {
                    Console.WriteLine(statements.reEnterName);
                    GetName();
                }
                return (userName);
            }
            public string GetPhoneNumber()
            {

                try
                {
                    phoneNumber = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + statements.reEnterPhone);
                    GetPhoneNumber();
                }
                Regex check = new Regex(@"^[6789]\d{9}$");
                if (check.IsMatch(phoneNumber) == false)
                {
                    Console.WriteLine(statements.invalidPhone);
                    Console.WriteLine(statements.correctPhone);
                    GetPhoneNumber();
                }
                return phoneNumber;
            }
            public string GetMail()
            {

                try
                {
                    mailId = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + statements.reEnterMail);
                    GetMail();
                }
                Regex check = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (check.IsMatch(mailId) == false)
                {
                    Console.WriteLine(statements.invalidMail);
                    Console.WriteLine(statements.correcrForamt);
                    GetMail();
                }
                return mailId;
            }

            public string GetPassword()
            {

                try
                {
                    password = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + statements.reEnterPassword);
                    GetPassword();
                }
                Regex regex = new Regex(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
                if ((regex.IsMatch(password)) == false)
                {
                    Console.WriteLine(statements.correctPassword);
                    GetPassword();
                }
                return password;
            }

        }
    }



