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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        ManageTextHandler iController;

        private GenericDGV<StaticTextDTO> dgvStaticText;

        public StaticTextAdministrator(IControllerFactory pFactory) : base(pFactory)
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StaticTextDTO staticText = new StaticTextDTO();
                AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
                this.dgvStaticText.Add(ventana, staticText);
                iController.AddText(staticText);
                this.CargarDataGrid();
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
                        iController.DeleteText(text);
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
                DataGridViewRow row = dgvStaticText.CurrentRow;
                StaticTextDTO staticText = dgvStaticText.GetItem(row.Index);
                AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
                this.dgvStaticText.Modify(ventana, staticText);
                iController.ModifyText(staticText);
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
                this.dgvStaticText.SetSource(this.iController.ListTexts());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvStaticText.CurrentRow;
                StaticTextDTO staticText = dgvStaticText.GetItem(row.Index);
                StaticTextView ventana = new StaticTextView();
                ventana.View(staticText);
            }
            catch (EntidadNulaException ex)
            {
                MessageBox.Show(ex.Message, "Entidad nula", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
