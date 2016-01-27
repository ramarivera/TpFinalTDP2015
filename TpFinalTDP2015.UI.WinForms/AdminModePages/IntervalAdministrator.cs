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
            ventana.AgregarIntervalo(dateInterval);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
            {
                DateIntervalDTO interval = ((DateIntervalDTO)row.DataBoundItem);
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el intervalo " + interval.Name + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        //this.iFachada.Delete(persona);
                        //this.iBinding.Remove(persona);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void btnAddTimeInterval_Click(object sender, EventArgs e)
        {
            timeInterval = new TimeIntervalDTO();
            AgregarModificarIntervaloTiempo ventana = new AgregarModificarIntervaloTiempo();
            ventana.AgregarIntervalo(timeInterval);
            DialogResult resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                //agregar a los intervalos de tiempo del intervalo de fecha
            }
        }
    }
}
