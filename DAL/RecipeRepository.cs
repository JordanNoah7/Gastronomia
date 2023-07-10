using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RecipeRepository
    {
        public DataTable GetRecipes()
        {
            DataTable dt = new DataTable();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetRecipes", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        Connection.OpenConnection();
                        SqlDataReader dr = cmd.ExecuteReader();
                        Connection.CloseConnection();
                        dt.Load(dr);
                    }

                    return dt;
                }
                catch(Exception ex)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }
        }
    }
}