using InformeProyectos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InformeProyectos.Commands
{
    public class ReportsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string consulta = (string)parameter;

            if(consulta == "idDpto")
            {
                resumenViewModel.UpdateViewCommand.HomeViewModel.GenerarInforme(resumenViewModel.IdDpto);
                resumenViewModel.UpdateViewCommand.Execute("home");

            }else if (consulta == "fechas")
            {
                string fecha1 = resumenViewModel.fecha1.ToString();
                string fecha2 = resumenViewModel.fecha2.ToString();
                resumenViewModel.UpdateViewCommand.HomeViewModel.GenerarInformeFechas(fecha1, fecha2);
                resumenViewModel.UpdateViewCommand.Execute("home");
            }
        }

        public ResumenViewModel resumenViewModel { get; set; }
        public ReportsCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
            
        }
    }
}
