using System.Data;

namespace ML
{
    public class Recipe
    {
        public int ID_RECETA { get; set; }         
        public string NOMBRE_RECETA { get; set; }    
        public string DESCRIPCION { get; set; }       
        public string TIEMPO_PREPARACION { get; set; }
        public string TIEMPO_COCCION { get; set; }    
        public byte PORCIONES { get; set; }         
        public byte DIFICULTAD { get; set; }        
        public int ID_CATEGORIA { get; set; }      
        public int ID_PERSONA { get; set; }
        public DataTable Ingredientes { get; set; } = new DataTable();
        public DataTable Preparacion { get; set; } = new DataTable();
    }
}