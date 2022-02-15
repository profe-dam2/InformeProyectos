using InformeProyectos.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InformeProyectos.ViewModels
{
    public class ResumenViewModel : ViewModelBase
    {
        public ICommand ReportsCommand { set; get; }
        public ICommand DataBaseCommand { set; get;}
        public int IdDpto { set; get; }
        public string txtDpto { set; get; }
        public DateTime fecha1 { set; get; }
        public DateTime fecha2 { set; get; }
        public UpdateViewCommand UpdateViewCommand { set; get; }
        public ResumenViewModel(UpdateViewCommand UpdateViewCommand)
        {
            ReportsCommand = new ReportsCommand(this);
            this.UpdateViewCommand = UpdateViewCommand;
            DataBaseCommand = new DataBaseCommand(this);
            fecha1 = DateTime.Today;
            fecha2 = DateTime.Today;
        }
    }

}
