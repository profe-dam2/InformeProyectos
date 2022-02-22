using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformeProyectos.Models
{
    public class EmpleadoModel
    {
        public int idEmpleado { set; get; }
        public string DNI { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public DateTime Fecha { set; get; }
        public DptoModel Dpto { set; get; }

    }
}
