using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.UI.View;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Intervalos de Fechas")]
    public partial class IntervalAdministrator : AdminModePage
    {
        DateIntervalService iController;

        DateIntervalDTO dateInterval;

        TimeIntervalDTO timeInterval;

        public IntervalAdministrator(): base()
        {
            InitializeComponent();
        }


        private DateIntervalService Controller
        {
            get
            {
                return (DateIntervalService)
                    ServiceFactory.
                    GetService<DateIntervalDTO>();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    this.dateInterval = new DateIntervalDTO();
                    AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
                    this.dgvDateInterval.Agregar(ventana, this.dateInterval);
                    iController.Save(this.dateInterval);
                    this.CargarDateDataGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    List<IDTO> intervalosAEliminar = new List<IDTO>();
                    foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
                    {
                        intervalosAEliminar.Add((DateIntervalDTO)dgvDateInterval.GetItem(row.Index));
                    }
                    if (intervalosAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvDateInterval.Eliminar(intervalosAEliminar);
                        foreach (IDTO interval in intervalosAEliminar)
                        {
                            iController.Delete((DateIntervalDTO)interval);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvDateInterval_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    DataGridViewRow row = dgvDateInterval.CurrentRow;
                    this.dateInterval = (DateIntervalDTO)dgvDateInterval.GetItem(row.Index);
                    AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
                    this.dgvDateInterval.Modificar(ventana, this.dateInterval);
                    iController.Save(this.dateInterval);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void IntervalAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDateDataGrid();
            this.CargarTimeDataGrid();
        }

        private void CargarDateDataGrid()
        {
            try
            {
                using (iController = this.Controller)
                {
                    IList<DateIntervalDTO> lList = this.iController.GetAll();
                    this.dgvDateInterval.AddToSource(lList.ToDTOList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarTimeDataGrid()
        {
            this.dateInterval = (DateIntervalDTO)dgvDateInterval.GetItem(0);
            this.dgvTimeInterval.AddToSource(this.dateInterval.ActiveHours.ToDTOList());
        }
        //TODO estos dos metodos son muy similares. No podes por ej cuando se carga todo setear el dgvDate en index 0 cosa de que se dispare auto el segundo metodo?
        private void dgvDateInterval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)dgvDateInterval.GetItem(row.Index);
            this.dgvTimeInterval.AddToSource(this.dateInterval.ActiveHours.ToDTOList());
            //TODO Martin: porque es que se usa un campo date interval?, osea, se usa esa misma instancia en varios metodos como para justificarlo?
        }

        private void btnAddTimeInterval_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)dgvDateInterval.GetItem(row.Index);
            this.timeInterval = new TimeIntervalDTO();
            IAddModifyViewForm ventana = new AgregarModificarIntervaloTiempo();
            ventana.Agregar((IDTO)this.timeInterval);
            DialogResult resultado = ventana.ShowForm();
            if (resultado == DialogResult.OK)
            {
                this.dateInterval.ActiveHours.Add(this.timeInterval);
            }
            //TODO revisar esto
        }

        private void btnDeleteTimeInterval_Click(object sender, EventArgs e)
        {
            List<IDTO> intervalosAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvTimeInterval.SelectedRows)
            {
                intervalosAEliminar.Add((TimeIntervalDTO)dgvTimeInterval.GetItem(row.Index));
            }
            if (intervalosAEliminar.Count == 0)
            {
                MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvTimeInterval.Eliminar(intervalosAEliminar);
                foreach (IDTO interval in intervalosAEliminar)
                {
                    //TODO ver esto
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)dgvDateInterval.GetItem(row.Index);
            DateIntervalView ventana = new DateIntervalView();
            ventana.View(this.dateInterval);
        }
    }
}
