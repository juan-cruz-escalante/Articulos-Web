using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dominio
{
    public class Marcas
    {
        public int IdMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public override string ToString()
        {
            return DescripcionMarca;
        }

    }
}
