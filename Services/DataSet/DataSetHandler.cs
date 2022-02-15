using InformeProyectos.Services.DataSet.ProyectoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformeProyectos.Services.DataSet
{
    class DataSetHandler
    {
        private static departamentoTableAdapter dptoAdapter = new departamentoTableAdapter();

        private static InformesTableAdapter adapter = new InformesTableAdapter();

        public static DataTable GetByIdDpto(int idDpto)
        {
            return adapter.GetDataByIdDpto(idDpto);
        }

        public static DataTable GetByFechas(string fecha1, string fecha2)
        {
            return adapter.GetDataByFechas(fecha1, fecha2);
        }


        public static void insertaDpto(string nombreDpto)
        {
            dptoAdapter.Insert(nombreDpto);
        }
    }
}
