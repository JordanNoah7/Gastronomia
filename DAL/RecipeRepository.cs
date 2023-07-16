using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RecipeRepository
    {
        public DataTable GetRecipes()
        {
            var dt = new DataTable();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetRecipes", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        Connection.OpenConnection();
                        var dr = cmd.ExecuteReader();
                        dt.Load(dr, LoadOption.OverwriteChanges);
                        Connection.CloseConnection();
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }
        }
    }
}