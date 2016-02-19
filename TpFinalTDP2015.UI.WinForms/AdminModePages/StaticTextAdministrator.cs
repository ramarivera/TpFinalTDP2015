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
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.UI.View;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        StaticTextController iController;

        StaticTextDTO staticText;
        public StaticTextAdministrator(): base()
        {
            InitializeComponent();
        }

        private StaticTextController Controller
        {
            get
            {
                return (StaticTextController)
                    ControllerFactory.
                    GetController<StaticTextDTO>();
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
                    this.dgvStaticText.Agregar(ventana, this.staticText);
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
                    List<IDTO> textosAEliminar = new List<IDTO>();
                    foreach (DataGridViewRow row in this.dgvStaticText.SelectedRows)
                    {
                        textosAEliminar.Add((StaticTextDTO)dgvStaticText.GetItem(row.Index));
                    }
                    if (textosAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvStaticText.Eliminar(textosAEliminar);
                        foreach (IDTO text in textosAEliminar)
                        {
                            iController.Delete((StaticTextDTO)text);
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
                    this.staticText = (StaticTextDTO)dgvStaticText.GetItem(row.Index);
                    AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
                    this.dgvStaticText.Modificar(ventana, this.staticText);
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
                    IList<StaticTextDTO> lList = this.iController.GetAll();
                    this.dgvStaticText.AddToSource(lList.ToDTOList());
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
            this.staticText = (StaticTextDTO)dgvStaticText.GetItem(row.Index);
            StaticTextView ventana = new StaticTextView();
            ventana.View(this.staticText);
        }
    }
}
