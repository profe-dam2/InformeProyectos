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
    class DataBaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool okInsertar = DataSetHandler.insertaDpto(resumenViewModel.TxtDpto);
            if (okInsertar) {
                resumenViewModel.TxtDpto = "";
            }
            else
            {
                MessageBox.Show("El departamento ya existe. Pon otro nombre");
            }

        }

        public ResumenViewModel resumenViewModel { set; get; }
        public DataBaseCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
