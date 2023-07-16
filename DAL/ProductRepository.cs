using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            var productList = new List<Product>();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetProducts", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                productList.Add(new Product()
                                {
                                    ID_PRODUCTO = Convert.ToInt32(dr["ID_PRODUCTO"]),
                                    NOMBRE = dr["NOMBRE"].ToString()
                                });
                            }
                        }
                        Connection.CloseConnection();
                    }

                    return productList;
                }
                catch (Exception e)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }
        }
    }
}