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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Intervalos de Fechas")]
    public partial class IntervalAdministrator : AdminModePage
    {
        ManageScheduleHandler iController = new ManageScheduleHandler();
        private GenericDGV<DateIntervalDTO> dgvDateInterval;
        private GenericDGV<TimeIntervalDTO> dgvTimeInterval;

        DateIntervalDTO dateInterval;

        TimeIntervalDTO timeInterval;

        public IntervalAdministrator() : base()
        {
           
            InitializeComponent();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.dateInterval = new DateIntervalDTO();
                AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
                this.dgvDateInterval.Add(ventana, this.dateInterval);
                iController.AddSchedule(this.dateInterval);
                this.CargarDateDataGrid();
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
                IList<DateIntervalDTO> intervalosAEliminar = new List<DateIntervalDTO>();
                foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
                {
                    intervalosAEliminar.Add(dgvDateInterval.GetItem(row.Index));
                }
                if (intervalosAEliminar.Count == 0)
                {
                    MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvDateInterval.Delete(intervalosAEliminar);
                    foreach (DateIntervalDTO interval in intervalosAEliminar)
                    {
                        iController.DeleteSchedule(interval);
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
                DataGridViewRow row = dgvDateInterval.CurrentRow;
                this.dateInterval = dgvDateInterval.GetItem(row.Index);
                AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
                this.dgvDateInterval.Modify(ventana, this.dateInterval);
                iController.UpdateSchedule(this.dateInterval);
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
                IList<DateIntervalDTO> lList = this.iController.ListSchedules();
                this.dgvDateInterval.SetSource(lList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarTimeDataGrid()
        {
            this.dateInterval = dgvDateInterval.GetItem(0);
            this.dgvTimeInterval.SetSource(this.dateInterval.ActiveHours);
        }

        //TODO estos dos metodos son muy similares. No podes por ej cuando se carga todo setear el dgvDate en index 0 cosa de que se dispare auto el segundo metodo?
        private void dgvDateInterval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = dgvDateInterval.GetItem(row.Index);
            this.dgvTimeInterval.SetSource(this.dateInterval.ActiveHours);
            //TODO Martin: porque es que se usa un campo date interval?, osea, se usa esa misma instancia en varios metodos como para justificarlo?
        }

        private void btnAddTimeInterval_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = dgvDateInterval.GetItem(row.Index);
            this.timeInterval = new TimeIntervalDTO();
            IAddModifyViewForm ventana = new AgregarModificarIntervaloTiempo();
            ventana.Add((IDTO)this.timeInterval);
            DialogResult resultado = ventana.ShowForm();
            if (resultado == DialogResult.OK)
            {
                this.dateInterval.ActiveHours.Add(this.timeInterval);
            }
            //TODO revisar esto
        }

        private void btnDeleteTimeInterval_Click(object sender, EventArgs e)
        {
            IList<TimeIntervalDTO> intervalosAEliminar = new List<TimeIntervalDTO>();
            foreach (DataGridViewRow row in this.dgvTimeInterval.SelectedRows)
            {
                intervalosAEliminar.Add(dgvTimeInterval.GetItem(row.Index));
            }
            if (intervalosAEliminar.Count == 0)
            {
                MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvTimeInterval.Delete(intervalosAEliminar);
                foreach (TimeIntervalDTO interval in intervalosAEliminar)
                {
                    //TODO ver esto
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = dgvDateInterval.GetItem(row.Index);
            DateIntervalView ventana = new DateIntervalView();
            ventana.View(this.dateInterval);
        }
    }
}
