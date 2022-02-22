using InformeProyectos.Models;
using InformeProyectos.Services.DataSet;
using InformeProyectos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InformeProyectos.Commands
{
    class InsertEmpleadoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool okInsertar = DataSetHandler.insertarEmpleado(resumenViewModel.Empleado);
            if (okInsertar)
            {
                resumenViewModel.Empleado = new EmpleadoModel();
                resumenViewModel.Empleado.Fecha = DateTime.Today;

            }
            else
            {
                MessageBox.Show("Error muy peligroso");
            }
        }
        public ResumenViewModel resumenViewModel { set; get; }
        public InsertEmpleadoCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
