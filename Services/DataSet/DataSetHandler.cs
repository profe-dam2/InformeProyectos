using InformeProyectos.Models;
using InformeProyectos.Services.DataSet.ProyectoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private static empleadoTableAdapter empleadoAdapter = new empleadoTableAdapter();

        public static DataTable GetByIdDpto(int idDpto)
        {
            return adapter.GetDataByIdDpto(idDpto);
        }

        public static DataTable GetByDptoProyecto(int idDpto, int idProyecto)
        {
            return adapter.GetDataByDptoProyecto(idProyecto, idDpto);
        }


        public static bool BorrarDpto(DptoModel dpto)
        {
            try
            {
                dptoAdapter.Delete(dpto.idDpto, dpto.nombreDpto);
                return true;
            }
            catch { return false; }
            
            
        }

        public static void BorrarEmpleado()
        {
           // empleadoAdapter.Delete()
        }

        public static DataTable GetByFechas(string fecha1, string fecha2)
        {
            return adapter.GetDataByFechas(fecha1, fecha2);
        }


        public static bool insertaDpto(string nombreDpto)
        {
            try
            {
                DataTable dptoDataTable = dptoAdapter.GetDataByNombreDpto(nombreDpto);
                if (dptoDataTable.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    dptoAdapter.Insert(nombreDpto);
                    return true;
                }

                

            }catch
            {
                return false;
            }
        }
        public static bool actualizarEmpleado(EmpleadoModel e)
        {
            try
            {
                empleadoAdapter.UpdateEmpleado(e.DNI, e.Nombre, e.Direccion, e.Telefono, e.Fecha.ToString(), e.Dpto.idDpto, e.idEmpleado);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool insertarEmpleado(EmpleadoModel e)
        {
            try
            {
                empleadoAdapter.Insert(e.DNI, e.Nombre, e.Direccion, e.Telefono, e.Fecha, e.Dpto.idDpto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ObservableCollection<EmpleadoModel> GetEmpleados()
        {
            DataTable empleadosDataTable = empleadoAdapter.GetData();
            ObservableCollection<EmpleadoModel> ListaEmpleados = new ObservableCollection<EmpleadoModel>();
           
            foreach(DataRow empleado in empleadosDataTable.Rows)
            {
                EmpleadoModel e = new EmpleadoModel();
                e.idEmpleado = (int)empleado["idEmpleado"];
                e.DNI = empleado["dni"].ToString();
                e.Nombre = empleado["nombreEmpleado"].ToString();
                e.Direccion = empleado["direccionEmpleado"].ToString();
                e.Telefono = empleado["telefono"].ToString();
                e.Fecha = (DateTime)empleado["fechaNacimiento"];
                e.Dpto = getDpto2((int)empleado["idDpto1"]);
                ListaEmpleados.Add(e);
            }
            return ListaEmpleados;
        }
        
        /*
        public static DptoModel getDpto(int idDpto)
        {
            DptoModel dpto = new DptoModel();
            DataTable dptoDT = dptoAdapter.GetDataByIdDpto(idDpto);
            DataRow dptoRow = dptoDT
        }
        */


        public static DptoModel getDpto2(int idDpto)
        {
            DataTable dptosDataTable = dptoAdapter.GetData();
            DptoModel myDpto = new DptoModel();


            foreach (DataRow dpto in dptosDataTable.Rows)
            {
                if((int)dpto["idDpto"] == idDpto)
                {
                    myDpto.idDpto = (int)dpto["idDpto"];
                    myDpto.nombreDpto = dpto["nombreDpto"].ToString();
                    break;
                } 
            }
            return myDpto;
        }


        public static ObservableCollection<DptoModel> getDptos()
        {
            DataTable dptosDataTable = dptoAdapter.GetData();
            ObservableCollection<DptoModel> listaDptos = new ObservableCollection<DptoModel>();
            
            
            foreach(DataRow dpto in dptosDataTable.Rows)
            {
                DptoModel myDpto = new DptoModel();
                myDpto.idDpto = (int)dpto["idDpto"];
                myDpto.nombreDpto = dpto["nombreDpto"].ToString();
                listaDptos.Add(myDpto);
            }
            return listaDptos;
        }
    }
}
