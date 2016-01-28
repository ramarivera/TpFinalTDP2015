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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dateInterval = new DateIntervalDTO();
            AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
            this.dgvDateInterval.Agregar(ventana,dateInterval);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
            {
                DateIntervalDTO interval = ((DateIntervalDTO)row.DataBoundItem);
                this.dgvDateInterval.Eliminar(interval);
            }
        }

        private void btnAddTimeInterval_Click(object sender, EventArgs e)
        {
            timeInterval = new TimeIntervalDTO();
            AgregarModificarIntervaloTiempo ventana = new AgregarModificarIntervaloTiempo();
            //this.dgvDateInterval.Agregar() falta
        }

        private void dgvDateInterval_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDateInterval.CurrentRow;
            this.dateInterval = (DateIntervalDTO)row.Tag;//this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha();
            this.dgvDateInterval.Modificar(ventana, dateInterval);
        }
    }
}
