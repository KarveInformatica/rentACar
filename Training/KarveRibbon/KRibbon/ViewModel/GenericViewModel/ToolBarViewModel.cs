using KRibbon.Commands.ToolBarCommand;
using KRibbon.Logic.ToolBar;
using KRibbon.Model.Generic;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.ViewModel.GenericViewModel
{
    public class ToolBarViewModel : GenericPropertyChanged
    {
        #region Variables
        private AnteriorToolBarCommand  anteriortoolbarcommand;
        private BuscarToolBarCommand    buscartoolbarcommand;
        private CancelarToolBarCommand  cancelartoolbarcommand;
        private EditarToolBarCommand    editartoolbarcommand;
        private EliminarToolBarCommand  eliminartoolbarcommand;
        private GuardarToolBarCommand   guardartoolbarcommand;
        private ImprimirToolBarCommand  imprimirtoolbarcommand;
        private NuevoToolBarCommand     nuevotoolbarcommand;
        private SalirToolBarCommand     salirtoolbarcommand;
        private SiguienteToolBarCommand siguientetoolbarcommand;
        #endregion

        #region Constructor
        public ToolBarViewModel()
        {
            this.anteriortoolbarcommand  = new AnteriorToolBarCommand(this);
            this.buscartoolbarcommand    = new BuscarToolBarCommand(this);
            this.cancelartoolbarcommand  = new CancelarToolBarCommand(this);
            this.editartoolbarcommand    = new EditarToolBarCommand(this);
            this.eliminartoolbarcommand  = new EliminarToolBarCommand(this);
            this.guardartoolbarcommand   = new GuardarToolBarCommand(this);
            this.imprimirtoolbarcommand  = new ImprimirToolBarCommand(this);
            this.nuevotoolbarcommand     = new NuevoToolBarCommand(this);
            this.salirtoolbarcommand     = new SalirToolBarCommand(this);
            this.siguientetoolbarcommand = new SiguienteToolBarCommand(this);
        }
        #endregion

        #region Commands
        public ICommand AnteriorToolBarCommand  { get { return anteriortoolbarcommand; } }
        public ICommand BuscarToolBarCommand    { get { return buscartoolbarcommand; } }
        public ICommand CancelarToolBarCommand  { get { return cancelartoolbarcommand; } }
        public ICommand EditarToolBarCommand    { get { return editartoolbarcommand; } }
        public ICommand EliminarToolBarCommand  { get { return eliminartoolbarcommand; } }
        public ICommand GuardarToolBarCommand   { get { return guardartoolbarcommand; } }
        public ICommand ImprimirToolBarCommand  { get { return imprimirtoolbarcommand; } }
        public ICommand NuevoToolBarCommand     { get { return nuevotoolbarcommand; } }
        public ICommand SalirToolBarCommand     { get { return salirtoolbarcommand; } }
        public ICommand SiguienteToolBarCommand { get { return siguientetoolbarcommand; } }
        #endregion

        #region Métodos
        public void AnteriorToolBar(object parameter)
        {
            AnteriorToolBarLogic.AnteriorToolBar();
        }

        public void BuscarToolBar(object parameter)
        {
            BuscarToolBarLogic.BuscarToolBar();
        }

        public void CancelarToolBar(object parameter)
        {
            CancelarToolBarLogic.CancelarToolBar();
        }

        public void EditarToolBar(object parameter)
        {
            EditarToolBarLogic.EditarToolBar();
        }

        public void EliminarToolBar(object parameter)
        {
            EliminarToolBarLogic.EliminarToolBar();
        }

        public void GuardarToolBar(object parameter)
        {
            GuardarToolBarLogic.GuardarToolBar();
        }

        public void ImprimirToolBar(object parameter)
        {
            ImprimirToolBarLogic.ImprimirToolBar();
        }

        public void NuevoToolBar(object parameter)
        {
            NuevoToolBarLogic.NuevoToolBar();
        }

        public void SalirToolBar(object parameter)
        {
            SalirToolBarLogic.SalirToolBar();
        }

        public void SiguienteToolBar(object parameter)
        {
            SiguienteToolBarLogic.SiguienteToolBar();
        }
        #endregion
    }
}