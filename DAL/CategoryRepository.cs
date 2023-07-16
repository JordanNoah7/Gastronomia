using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class CategoryRepository
    {
        public List<Category> GetCategories()
        {
            var categoryList = new List<Category>();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetCategories", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                categoryList.Add(new Category()
                                {
                                    ID_CATEGORIA = Convert.ToInt32(dr["ID_CATEGORIA"]),
                                    NOMBRE_CATEGORIA = dr["NOMBRE_CATEGORIA"].ToString()
                                });
                            }
                        }
                        Connection.CloseConnection();
                    }

                    return categoryList;
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