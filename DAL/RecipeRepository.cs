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

        public bool DeleteRecipe(int id)
        {
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_DeleteRecipe", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idReceta", id);
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

        public Recipe GetRecipe(int id)
        {
            Recipe recipe = new Recipe();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetRecipe", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDReceta", id);
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                recipe.ID_RECETA = id;
                                recipe.NOMBRE_RECETA = dr["NOMBRE_RECETA"].ToString();
                                recipe.DESCRIPCION = dr["Descripcion"].ToString();
                                recipe.TIEMPO_PREPARACION = dr["Tiempo_Preparacion"].ToString();
                                recipe.TIEMPO_COCCION = dr["Tiempo_Coccion"].ToString();
                                recipe.PORCIONES = Convert.ToByte(dr["Porciones"]);
                                recipe.DIFICULTAD = Convert.ToByte(dr["Dificultad"]);
                                recipe.ID_CATEGORIA = Convert.ToInt32(dr["ID_CATEGORIA"]);
                                Array.Copy((byte[])dr["concurrency"], recipe.concurrency, 8);
                                recipe.Persona = dr["NOMBRES"] + " " + dr["APELLIDO_PATERNO"] + " " + dr["APELLIDO_MATERNO"];
                                recipe.ID_PERSONA = Convert.ToInt32(dr["ID_PERSONA"]);
                            }

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(dr);
                                recipe.Ingredientes = dt;
                            }
                            //dr.NextResult();
                            if (dr.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(dr);
                                recipe.Preparacion = dt;
                            }
                        }
                        Connection.CloseConnection();
                    }

                    return recipe;
                }
                catch (Exception e)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_UpdateRecipe", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idReceta", recipe.ID_RECETA);
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
                        cmd.Parameters.AddWithValue("@concurrency", recipe.concurrency);
                        Connection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        Connection.CloseConnection();
                    }

                    return true;
                }
                catch (SqlException e)
                {
                    Connection.CloseConnection();
                    return false;
                }
            }
        }
    }
}