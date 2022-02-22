using InformeProyectos.Commands;
using InformeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand UpdateDptoCommand { set; get; }
        public ICommand InsertEmpleadoCommand { set; get; }
        public ICommand DeleteDptoCommand { set; get; }
        public ICommand UpdateEmpleadosCommand { set; get; }
        public ICommand ChangeEmpleadoCommand { set; get; }

        private ObservableCollection<EmpleadoModel> listaEmpleados;
        public ObservableCollection<EmpleadoModel> ListaEmpleados
        {
            get { return listaEmpleados; }
            set
            {
                listaEmpleados = value;
                OnPropertyChanged(nameof(ListaEmpleados));
            }
        }
        public int IdDpto { set; get; }
        public int IDProyecto { set; get; }

        private DptoModel selectedDpto;
        public DptoModel SelectedDpto
        {
            set
            {
                selectedDpto = value;
                OnPropertyChanged(nameof(SelectedDpto));
            }
            get
            {
                return selectedDpto;
            }
        }
        
        private string txtDpto;
        public string TxtDpto
        {
            set
            {
                txtDpto = value;
                OnPropertyChanged(nameof(TxtDpto));
            }
            get
            {
                return txtDpto; 
            }
        }

        private EmpleadoModel empleado;
        public EmpleadoModel Empleado
        {
            set
            {
                empleado = value;
                OnPropertyChanged(nameof(Empleado));
            }
            get
            {
                return empleado;
            }
        }

        public DateTime fecha1 { set; get; }
        public DateTime fecha2 { set; get; }
        public UpdateViewCommand UpdateViewCommand { set; get; }
        private ObservableCollection<DptoModel> listaDepartamentos;
        public ObservableCollection<DptoModel> ListaDepartamentos
        {
            get
            {
                return listaDepartamentos;
            }
            set
            {
                listaDepartamentos = value;
                OnPropertyChanged(nameof(ListaDepartamentos));
            }
        }
        public ResumenViewModel(UpdateViewCommand UpdateViewCommand)
        {
            ReportsCommand = new ReportsCommand(this);
            this.UpdateViewCommand = UpdateViewCommand;
            DataBaseCommand = new DataBaseCommand(this);
            UpdateDptoCommand = new UpdateDptoCommand(this);
            InsertEmpleadoCommand = new InsertEmpleadoCommand(this);
            DeleteDptoCommand = new DeleteDptoCommand(this);
            UpdateEmpleadosCommand = new UpdateEmpleadosCommand(this);
            ChangeEmpleadoCommand = new ChangeEmpleadoCommand(this);
            ListaEmpleados = new ObservableCollection<EmpleadoModel>();
            ListaDepartamentos = new ObservableCollection<DptoModel>();
            fecha1 = DateTime.Today;
            fecha2 = DateTime.Today;
            Empleado = new EmpleadoModel();
            Empleado.Fecha = DateTime.Today;
        }
    }

}
