using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.UI.View;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        StaticTextService iController;

        StaticTextDTO staticText;

        private GenericDGV<StaticTextDTO> dgvStaticText;

        public StaticTextAdministrator(): base()
        {
            InitializeComponent();
        }

        private StaticTextService Controller
        {
            get
            {
                return
                    BusinessServiceLocator.
                    Resolve<StaticTextService>();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    this.staticText = new StaticTextDTO();
                    AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
                    this.dgvStaticText.Add(ventana, this.staticText);
                    iController.Save(this.staticText);
                    this.CargarDataGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    IList<StaticTextDTO> textosAEliminar = new List<StaticTextDTO>();
                    foreach (DataGridViewRow row in this.dgvStaticText.SelectedRows)
                    {
                        textosAEliminar.Add(dgvStaticText.GetItem(row.Index));
                    }
                    if (textosAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvStaticText.Delete(textosAEliminar);
                        foreach (StaticTextDTO text in textosAEliminar)
                        {
                            iController.Delete(text);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }   
        }

        private void dgvStaticText_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (iController = this.Controller)
                {
                    DataGridViewRow row = dgvStaticText.CurrentRow;
                    this.staticText = dgvStaticText.GetItem(row.Index);
                    AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
                    this.dgvStaticText.Modify(ventana, this.staticText);
                    iController.Save(this.staticText);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void StaticTextAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            try
            {
                using (iController = this.Controller)
                {
                    this.dgvStaticText.SetSource(this.iController.GetAll());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvStaticText.CurrentRow;
            this.staticText = dgvStaticText.GetItem(row.Index);
            StaticTextView ventana = new StaticTextView();
            ventana.View(this.staticText);
        }
    }
}
