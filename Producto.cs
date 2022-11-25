using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBaseDeDatos
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public float? Costo { get; set; }
        public float? PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }
    }
}
