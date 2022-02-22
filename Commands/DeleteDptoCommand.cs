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
    class DeleteDptoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(resumenViewModel.SelectedDpto != null){
                bool okResult = DataSetHandler.BorrarDpto(resumenViewModel.SelectedDpto);
                if (okResult)
                {
                    resumenViewModel.UpdateDptoCommand.Execute(null);
                    MessageBox.Show("Departamento eliminado");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un departamento");
            }
            
        }
        public ResumenViewModel resumenViewModel { set; get; }
        public DeleteDptoCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
