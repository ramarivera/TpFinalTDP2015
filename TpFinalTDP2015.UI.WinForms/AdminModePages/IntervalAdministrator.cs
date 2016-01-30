using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Intervalos de Fechas")]
    public partial class IntervalAdministrator : AdminModePage
    {
        DateIntervalDTO dateInterval;

        TimeIntervalDTO timeInterval;
        public IntervalAdministrator(): base()
        {
            InitializeComponent();
            //TODO obtener lo que está en la base de datos como una lista mediante fachada y guardar en iSource
            this.dgvDateInterval.DataSource = this.dgvDateInterval.iSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dateInterval = new DateIntervalDTO();
            AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
            this.dgvDateInterval.Agregar(ventana,dateInterval);
            // TODO guardar en base de datos
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //TODO verificar lista no vacia
            List<IDTO> intervalosAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
            {
                intervalosAEliminar.Add((DateIntervalDTO)row.DataBoundItem);
            }
            this.dgvDateInterval.Eliminar(intervalosAEliminar);
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
            this.dgvDateInterval.Modificar(ventana, dateInterval);
        }
    }
}
