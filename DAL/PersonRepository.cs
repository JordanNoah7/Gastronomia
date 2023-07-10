﻿using System;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class PersonRepository
    {
        public Person GetByUsername(string username)
        {
            var person = new Person();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetByUsername", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@userName", username);
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                person.USERNAME = dr["USERNAME"].ToString();
                                person.CONTRASENA = dr["CONTRASENA"].ToString();
                            }
                        }

                        Connection.CloseConnection();
                    }

                    return person;
                }
                catch (Exception ex)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }
        }

        public Person GetPerson(string username, string password)
        {
            var person = new Person();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetPerson", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@contrasena", password);
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                person.ID_PERSONA = Convert.ToInt32(dr["ID_PERSONA"].ToString());
                                person.NOMBRES = dr["NOMBRES"].ToString();
                                person.APELLIDO_PATERNO = dr["APELLIDO_PATERNO"].ToString();
                                person.APELLIDO_MATERNO = dr["APELLIDO_MATERNO"].ToString();
                            }
                        }

                        Connection.CloseConnection();
                    }

                    return person;
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