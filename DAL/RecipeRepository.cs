using System;
using System.Data;
using System.Data.SqlClient;
using ML;

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

        public bool AddRecipe(Recipe recipe)
        {
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_AddRecipe", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nombre", recipe.NOMBRE_RECETA);
                        cmd.Parameters.AddWithValue("@descripcion", recipe.DESCRIPCION);
                        cmd.Parameters.AddWithValue("@tiempo_preparacion", recipe.TIEMPO_PREPARACION);
                        cmd.Parameters.AddWithValue("@tiempo_coccion", recipe.TIEMPO_COCCION);
                        cmd.Parameters.AddWithValue("@porciones", recipe.PORCIONES);
                        cmd.Parameters.AddWithValue("@dificultad", recipe.DIFICULTAD);
                        cmd.Parameters.AddWithValue("@id_categoria", recipe.ID_CATEGORIA);
                        cmd.Parameters.AddWithValue("@id_persona", recipe.ID_PERSONA);
                        cmd.Parameters.AddWithValue("@ingredientes", recipe.Ingredientes);
                        cmd.Parameters.AddWithValue("@preparacion", recipe.Preparacion);
                        Connection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        Connection.CloseConnection();
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Connection.CloseConnection();
                    return false;
                }
            }
        }
    }
}