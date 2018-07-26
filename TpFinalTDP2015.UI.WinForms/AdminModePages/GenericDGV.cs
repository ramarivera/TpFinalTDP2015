using log4net;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.CrossCutting;
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    public partial class GenericDGV<TDto> : DataGridView where TDto : IDTO
    {
        private static readonly ILog cLogger = LogManagerWrapper.GetLogger<GenericDGV<TDto>>();

        private BindingSource iSource = new BindingSource();

        public static DataGridViewColumn CreateColumn<TValue>(
            Expression<Func<TDto, TValue>> pPropertySelector,
            string pCabeceraColumna = null)
        {
            var lColumna = new DataGridViewTextBoxColumn();

            var lNombrePropiedad = Reflect<TDto>.PropertyName(pPropertySelector);
            var lCabeceraColumna = String.IsNullOrEmpty(pCabeceraColumna) ? lNombrePropiedad : pCabeceraColumna;

            lColumna.DataPropertyName = lNombrePropiedad;
            lColumna.HeaderText = lCabeceraColumna;

            return lColumna;
        }

        public GenericDGV(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.AutoGenerateColumns = false;
        }

        public GenericDGV(IContainer container, params DataGridViewColumn[] pColumns)
            : this(container)
        {

        }

        public void AddColumns(params DataGridViewColumn[] pColumns)
        {
            if (pColumns != null && pColumns.Length > 0)
            {
                this.ClearColumns();
                this.Columns.AddRange(pColumns);
            }
        }

        public void AddColumn(DataGridViewColumn pColumn)
        {
            this.Columns.Add(pColumn);
        }

        public void AddColumn(
            Expression<Func<TDto, object>> pPropertySelector,
            string pCabeceraColumna = null)
        {
            var lColumna = CreateColumn(pPropertySelector, pCabeceraColumna);
            this.Columns.Add(lColumna);
        }

        public TDto GetItem(int pRowIndex)
        {
            TDto result = default(TDto);

            if (this.Rows.Count > 0 && pRowIndex <= this.Rows.Count - 1)
            {
                result = (TDto)this.Rows[pRowIndex].DataBoundItem;
            }

            return result;
        }

        public bool Add(IAddModifyViewForm pForm, TDto pDTO)
        {
            bool acepted = false;
            pForm.Add(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                this.iSource.Add(pDTO);
                this.Rows[this.RowCount - 1].Tag = pDTO;
                acepted = true;
            }
            return acepted;
        }

        public bool Modify(IAddModifyViewForm pForm, TDto pDTO)
        {
            bool acepted = false;
            pForm.Modify(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
            {
                acepted = true;
            }
            return acepted;
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

        private void ClearColumns()
        {
            for (int i = this.Columns.Count - 1; i > 0; i--)
            {
                this.Columns.RemoveAt(i);
            }
        }
    }
}


