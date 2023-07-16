using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace DAL
{
    public class UnitMeasureRepository
    {
        public List<UnitMeasure> GetUnitMeasures()
        {
            var unitMeasureList = new List<UnitMeasure>();
            using (var cnDb = Connection.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand("usp_GetUnitMeasure", cnDb))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        Connection.OpenConnection();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                unitMeasureList.Add(new UnitMeasure()
                                {
                                    ID_UNIDAD_MEDIDA = Convert.ToInt32(dr["ID_UNIDAD_MEDIDA"]),
                                    ABREVIATURA = dr["ABREVIATURA"].ToString()
                                });
                            }
                        }
                        Connection.CloseConnection();
                    }

                    return unitMeasureList;
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