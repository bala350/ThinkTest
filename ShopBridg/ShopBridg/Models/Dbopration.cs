using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBridg.Models;
using System.Data;
using System.Data.SqlClient;


namespace ShopBridg.Models
{
    public class Dbopration
    {
        public ConnectionString conString = new ConnectionString();



        internal void AddProduct(Product obj)
        {
            try
            {
                
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCommand cmd = new SqlCommand("InsertProduct", SqlCon);//storeprocedure
                SqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName",obj.ItemName);
                cmd.Parameters.AddWithValue("@Price", obj.Price);
                cmd.Parameters.AddWithValue("@Discription", obj.Discription);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.ExecuteNonQuery();
              


            }
            catch (Exception ex)
            {

                
            }
        }
        
        internal List<Product> getAllInfo()
        {
            List<Product> objlist = new List<Product>();
            try
            {
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCon.Open();
                SqlCommand Sqlcmd = new SqlCommand("select * from tbl_product", SqlCon);

                SqlDataReader readar = Sqlcmd.ExecuteReader();

                while (readar.Read())
                {
                    try
                    {
                        Product obj = new Product();
                        obj.ProductID = readar["ProductID"].ToString();
                        obj.ItemName = readar["ItemName"].ToString();
                        obj.Price =Convert.ToDecimal(readar["Price"].ToString());
                        obj.Discription = readar["Description"].ToString();
                        obj.Stock = readar["Stock"].ToString();
                        objlist.Add(obj);
                    }
                    catch (Exception objEx)
                    {

                    }

                }
            }

            catch (Exception objEx)
            {

            }
            return objlist;
        }



        internal void UpdateProduct( Product obj)
        {
            try
            {
              //  Product obj = new Product();
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCommand cmd = new SqlCommand("Sp_Update", SqlCon);//storeprocedure
                SqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", obj.ProductID);
                cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
                cmd.Parameters.AddWithValue("@Price", obj.Price);
                cmd.Parameters.AddWithValue("@Discription", obj.Discription);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {


            }
           
        }



        public void DeleteProduct(int ProductID)
        {
            try
            {
                  Product obj = new Product();
                SqlConnection SqlCon = new SqlConnection(conString.connString);
                SqlCommand cmd = new SqlCommand("Sp_Delete", SqlCon);//storeprocedure
                SqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", ProductID);
               
                cmd.ExecuteNonQuery();
                SqlCon.Close();


            }
            catch (Exception ex)
            {


            }

        }

    }
}