using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using MarrSystems.TpFinalTDP2015.UI.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        private GenericDGV<StaticTextDTO> dgvStaticText;

        public StaticTextAdministrator(IControllerFactory pFactory) : base(pFactory)
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageTextHandler>())
                {
                    StaticTextDTO staticText = new StaticTextDTO();
                    AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo(this.iFactory);
                    this.dgvStaticText.Add(ventana, staticText);
                    controller.AddText(staticText);
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
                using (var controller = this.iFactory.GetController<ManageTextHandler>())
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
                            controller.DeleteText(text);
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
                using (var controller = this.iFactory.GetController<ManageTextHandler>())
                {
                    DataGridViewRow row = dgvStaticText.CurrentRow;
                    StaticTextDTO staticText = dgvStaticText.GetItem(row.Index);
                    AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo(this.iFactory);
                    this.dgvStaticText.Modify(ventana, staticText);
                    controller.ModifyText(staticText);
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
                using (var controller = this.iFactory.GetController<ManageTextHandler>())
                {
                    this.dgvStaticText.SetSource(controller.ListTexts());
                }
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
