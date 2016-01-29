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
                this.Rows[this.RowCount-1].Tag = pDTO;
            }
        }

        public void Modificar(IAddModifyViewForm pForm, IDTO pDTO)
        {
            pForm.Modificar(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if(resultado == DialogResult.OK)
            {
                //TODO fachada en cada administrador
            }
        }

        public void Eliminar(List<IDTO> pDTOs)
        {
            string cadena = "este elemento";
            if (pDTOs.Count > 1)
            {
                cadena = "estos elementos";
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar "+cadena+"?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (resultado)
            {
                case DialogResult.Yes:
                    //TODO elimnar de la db en fachada
                    foreach (IDTO pDTO in pDTOs)
                    {
                        this.iSource.Remove(pDTO);
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

    }
}
