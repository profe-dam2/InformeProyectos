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
    class ChangeEmpleadoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool okActualizar = DataSetHandler.actualizarEmpleado(resumenViewModel.Empleado);
            if (okActualizar)
            {
                resumenViewModel.UpdateEmpleadosCommand.Execute("");
                MessageBox.Show("Se actualizó el empleado");

            }
            else
            {
                MessageBox.Show("Fallo al actualizar");

            }
        }
        public ResumenViewModel resumenViewModel { set; get; }
        public ChangeEmpleadoCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
