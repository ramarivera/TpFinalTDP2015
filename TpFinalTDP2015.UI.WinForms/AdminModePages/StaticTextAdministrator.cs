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
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        StaticTextDTO staticText;
        public StaticTextAdministrator(): base()
        {
            InitializeComponent();
            //TODO obtener lo que está en la base de datos como una lista mediante fachada y guardar en iSource
            this.dgvStaticText.DataSource = this.dgvStaticText.iSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            staticText = new StaticTextDTO();
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvStaticText.Agregar(ventana,staticText);
            // TODO guardar en base de datos
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO verificar lista no vaciaa
            List<IDTO> textosAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvStaticText.SelectedRows)
            {
                textosAEliminar.Add((StaticTextDTO)row.DataBoundItem);
            }
            this.dgvStaticText.Eliminar(textosAEliminar);
        }

        private void dgvStaticText_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvStaticText.CurrentRow;
            this.staticText = (StaticTextDTO)row.Tag;//this.iBinding.Single<Persona>(p => p.PersonaId == (int)row.Tag);
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvStaticText.Modificar(ventana, staticText);
        }
    }
}
