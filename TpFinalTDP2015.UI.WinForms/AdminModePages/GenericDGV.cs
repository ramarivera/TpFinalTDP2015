using log4net;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    public partial class GenericDGV<TDto> : DataGridView where TDto : IDTO
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<GenericDGV<TDto>>();

        private BindingSource iSource = new BindingSource(); //TODO cambiar public por private

        public TDto GetItem(int pRowIndex)
        {
            TDto result = default(TDto);

            if (this.Rows.Count > 0 && pRowIndex <= this.Rows.Count - 1)
            {
                result = (TDto)this.Rows[pRowIndex].DataBoundItem;
            }

            return result;
        }

        public GenericDGV(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void Add(IAddModifyViewForm pForm, TDto pDTO)
        {
            pForm.Add(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                this.iSource.Add(pDTO);
                this.Rows[this.RowCount - 1].Tag = pDTO;
            }
        }

        public void Modify(IAddModifyViewForm pForm, TDto pDTO)
        {
            pForm.Modify(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                //TODO fachada en cada administrador
            }
        }

        public void Delete(IList<TDto> pDTOs)
        {
            string cadena = "este elemento";
            if (pDTOs.Count > 1)
            {
                cadena = "estos elementos";
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar " + cadena + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (resultado)
            {
                case DialogResult.Yes:
                    //TODO elimnar de la db en fachada
                    foreach (TDto pDTO in pDTOs)
                    {
                        this.iSource.Remove(pDTO);
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        public void SetSource(IList<TDto> pDTOs)
        {
            this.iSource.Clear();

            foreach (TDto pDTO in pDTOs)
            {
                this.iSource.Add(pDTO);
            }

            this.DataSource = this.iSource;
        }

        public IList<TDto> GetAll()
        {
            return iSource.Cast<TDto>().ToList();
        }
    }
}


