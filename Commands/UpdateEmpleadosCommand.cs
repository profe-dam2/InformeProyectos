using InformeProyectos.Services.DataSet;
using InformeProyectos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InformeProyectos.Commands
{
    class UpdateEmpleadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            resumenViewModel.ListaEmpleados = DataSetHandler.GetEmpleados();
        }

        public ResumenViewModel resumenViewModel { set; get; }
        public UpdateEmpleadosCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
