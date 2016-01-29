using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.AdminModePages
{
    public partial class BaseDGV : DataGridView
    {
        public BindingSource iSource = new BindingSource();
        public BaseDGV()
        {
            InitializeComponent();
            this.dgv.DataSource = iSource;
        }

        public BaseDGV(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Agregar(IAddModifyViewForm pForm, IDTO pDTO)
        {
            pForm.Agregar(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                this.iSource.Add(pDTO);
                //this.dgv.Rows[this.dgv.RowCount].Tag = pDTO;
                this.dgv.DataSource = iSource;
            }
        }

        public void Modificar(IAddModifyViewForm pForm, IDTO pDTO)
        {
            pForm.Modificar(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if(resultado == DialogResult.OK)
            {
                //fachada
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

    }
}
