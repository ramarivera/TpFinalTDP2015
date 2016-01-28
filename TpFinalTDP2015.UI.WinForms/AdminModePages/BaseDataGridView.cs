using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI
{
    public partial class BaseDataGridView: UserControl
    {
        //public delegate void CellContentDoubleClickEventHandler (DataGridViewCellEventArgs e);
        //public event CellContentDoubleClickEventHandler CellContetDoubleClick;

        BindingSource iSource = new BindingSource();
        public BaseDataGridView()
        {
            InitializeComponent();
            this.dgv.DataSource = iSource;
        }

        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return this.dgv.SelectedRows; }
        }

        public DataGridViewRow CurrentRow
        {
            get { return this.dgv.CurrentRow; }
        }

        /*public DataGridView DateSource
        {
            get { return this.dgv.DataSource; }
        }*/

        public void Agregar(IAddModifyViewForm pForm ,IDTO pDTO)
        {
            pForm.Agregar(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                //turno de la fachada
            }
        }

        public void Eliminar(IDTO pDTO)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar este elemento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        public event EventHandler ModificarConDobleClick;
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ModificarConDobleClick != null)
            {
                ModificarConDobleClick(this, e);
            }
        }
    }
}
