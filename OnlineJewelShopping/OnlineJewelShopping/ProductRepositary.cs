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
    class ProductRepositary
    {
        ProductDetails productDetails = new ProductDetails();
        public void AddProduct(SqlConnection sqlConnection)
        {
            productDetails.AddProducts(sqlConnection);
        }
        public void RemoveProduct(SqlConnection sqlConnection)
        {
            productDetails.RemoveProduct(sqlConnection);
        }
        public void ViewProduct(SqlConnection sqlConnection)
        {
            productDetails.RemoveProduct(sqlConnection);
        }
    }
}
