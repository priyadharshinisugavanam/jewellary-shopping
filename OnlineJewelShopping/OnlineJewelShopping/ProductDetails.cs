using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineJewelShopping
{
    class ProductClass
    {
        public string productName { get; set; }
        public string productRange { get; set; } 
    }
    class ProductDetails:ProductClass
    {
        SortedList<string, string> product = new SortedList<string, string>();
        Statements statements = new Statements();
        public void AddProducts(SqlConnection sqlConnections)
        {
            
            Console.WriteLine(statements.productNameAdd);
            productName = Console.ReadLine();
            Console.WriteLine(statements.productRange);
            productRange = Console.ReadLine();
            string sql = "PRODUCTS";
            SqlCommand sqlCommand = new SqlCommand(sql,sqlConnections);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = "@productName";
            sqlParameter.Value = productName;
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 20;
            sqlCommand.Parameters.Add(sqlParameter);
            
            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@productRange";
            sqlParameter.Value = productRange;
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 10;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Action";
            sqlParameter.Value = 1;
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 1;
            sqlCommand.Parameters.Add(sqlParameter);


            sqlConnections.Open();

            int rows = sqlCommand.ExecuteNonQuery();
            if (rows >= 1)
            {
                Console.WriteLine(statements.productAdd);
            }
            else
            {
                Console.WriteLine(statements.productNotAdd);
            }

            sqlConnections.Close();

          

        }
       
        public void ViewProduct(SqlConnection sqlConnections)
        {
            string sql = "View_Products";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnections);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Action";
            sqlParameter.Value = 2;
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 1;
            sqlCommand.Parameters.Add(sqlParameter);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "ProductCatogery");
            product.Clear();
            foreach (DataRow dataRow in dataSet.Tables["ProductCatogery"].Rows)
            {
                ProductClass productClass = new ProductClass();
                productClass.productName = dataRow[0].ToString().Trim();
                productClass.productRange = dataRow[1].ToString().Trim();
                product.Add(productClass.productName, productClass.productRange);

            }
            foreach(KeyValuePair<string,string> product in product)
            {
                Console.WriteLine(product.Key+" "+product.Value);
            }
        }
        public void RemoveProduct(SqlConnection sqlConnection)
        {
            Console.Write(statements.productNameAdd);
            string productName = Console.ReadLine();

            string sql = "DELETE_Procedure";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@Name";
            para.Value = productName;
            para.SqlDbType = SqlDbType.Char;
            sqlCommand.Parameters.Add(para);
            para = new SqlParameter();
            para.ParameterName = "@Action";
            para.Value = 3;
            para.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(para);
            sqlDataAdapter.DeleteCommand = sqlCommand;
            sqlConnection.Open();
            int retRows = sqlDataAdapter.DeleteCommand.ExecuteNonQuery();

            if (retRows >= 1)
            {
                Console.WriteLine(statements.productDeleted);
            }
            else
            {
                Console.WriteLine(statements.productNotDeleted);
            }
            sqlCommand.Dispose();
            sqlConnection.Close();

        }

    }
}
