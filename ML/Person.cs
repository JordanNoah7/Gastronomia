using System;
using System.Collections.Generic;

namespace ML
{
    public class Person
    {
        public int ID_PERSONA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string SEXO { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string USERNAME { get; set; }
        public string CONTRASENA { get; set; }
        public List<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();
        public List<PersonGroup> PersonGroups { get; set; } = new List<PersonGroup>();
    }
}