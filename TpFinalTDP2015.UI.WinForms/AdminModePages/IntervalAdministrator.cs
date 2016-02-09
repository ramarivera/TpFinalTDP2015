using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Intervalos de Fechas")]
    public partial class IntervalAdministrator : AdminModePage
    {
        DateIntervalController iController = new DateIntervalController();

        DateIntervalDTO dateInterval;

        TimeIntervalDTO timeInterval;
        public IntervalAdministrator(): base()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.dateInterval = new DateIntervalDTO();
            AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
            this.dgvDateInterval.Agregar(ventana,this.dateInterval);
            iController.SaveDateInterval(this.dateInterval);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<IDTO> intervalosAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
            {
                intervalosAEliminar.Add((DateIntervalDTO)row.DataBoundItem);
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
                    iController.DeleteDateInterval((DateIntervalDTO)interval);
                }
            }
            
        }

        private void btnAddTimeInterval_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)row.Tag;
            this.timeInterval = new TimeIntervalDTO();
            AgregarModificarIntervaloTiempo ventana = new AgregarModificarIntervaloTiempo();
            DialogResult resultado =ventana.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                //this.dateInterval.ActiveHours.Add
            }
            //TODO revisar esto
        }

        private void dgvDateInterval_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)row.Tag;
            AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
            this.dgvDateInterval.Modificar(ventana, this.dateInterval);
            iController.SaveDateInterval(this.dateInterval);
        }

        private void IntervalAdministrator_Load(object sender, EventArgs e)
        {
            IList<DateIntervalDTO> lList = this.iController.GetDateIntervals();
            foreach (var dto in lList)
            {
                this.dgvDateInterval.iSource.Add(dto);
            }
            this.dgvDateInterval.DataSource = this.dgvDateInterval.iSource;
        }
    }
}
