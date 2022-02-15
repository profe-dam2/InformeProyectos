using InformeProyectos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InformeProyectos.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public HomeViewModel HomeViewModel { get; set; }
        public ResumenViewModel ResumenViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string viewName = (string)parameter;

                if (viewName.Equals("home"))
                {
                    mainViewModel.SelectedViewModel = HomeViewModel;
                }else if (viewName.Equals("resumen"))
                {
                    mainViewModel.SelectedViewModel = ResumenViewModel;
                }
            }
        }

        public MainViewModel mainViewModel { get; set; }
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.mainViewModel.SelectedViewModel = new HomeViewModel();
            HomeViewModel = new HomeViewModel();
            ResumenViewModel = new ResumenViewModel(this);
        }
    }
}
