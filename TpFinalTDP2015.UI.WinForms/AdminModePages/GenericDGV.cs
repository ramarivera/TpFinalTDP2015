using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    public partial class GenericDGV<TDto> : DataGridView where TDto: IDTO
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<GenericDGV<TDto>>();

        public BindingSource iSource = new BindingSource(); //TODO cambiar public por private
        private DGVHelper<TDto> iHelper = new DGVHelper<TDto>();
        private bool configured = false;


        public TDto GetItem(int pRowIndex)
        {
            return (TDto) this.Rows[pRowIndex].DataBoundItem;
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

            if (!configured)
            {
                this.iHelper.Configure(this); //TODO esto se tendria que hacer una vez por cada dgv, no una vez cada vez que se agrega algo :(
                configured = true;
            } 
        }

        public IList<TDto> GetAll()
        {
          return  iSource.Cast<TDto>().ToList();
        }
    }


    class DGVHelper<TDto> where TDto : IDTO
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<DGVHelper<TDto>>();

        IList<PropertyConfigurations> PropertyConfigs { get; set; }

        internal DGVHelper()
        {
            this.PropertyConfigs = new List<PropertyConfigurations>();
        }

        public void Configure(GenericDGV<TDto> pDGV)
        {
            pDGV.AutoGenerateColumns = false;
            //  pDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GetConfigForEntity(typeof(TDto));
            this.ConfigureColumns(pDGV);
            pDGV.RowHeadersVisible = false;

        }


        private void ConfigureColumns(GenericDGV<TDto> pDGV)
        {
            int i = 0;
            bool lError = false;
            IList<DataGridViewColumn> lColumnsToRemove = new List<DataGridViewColumn>();
            IList<DataGridViewColumn> lColumns = this.CopyColumns(pDGV);

            while (!lError && i < lColumns.Count)
            {
                DataGridViewColumn lCol = lColumns[i];
                lCol.ReadOnly = true;
                PropertyConfigurations lProp = PropertyConfigs
                                    .Where(pro => pro.PropertyName == lCol.Name)
                                    .FirstOrDefault();
                if (lProp != null)      // meramente para estar seguro que no falle nada
                {
                    if (lProp.Enabled)
                    {
                        lCol.HeaderText = lProp.Value;
                    }
                    else
                    {
                        lColumnsToRemove.Add(lCol);
                    }
                    i++;
                }
                else//TODO cagamos viteh
                {
                    lError = true;
                }

            }

            if (!lError)
            {
                foreach (DataGridViewColumn col in lColumnsToRemove)
                {
                    lColumns.Remove(col);
                }
                pDGV.Columns.Clear();
                pDGV.Columns.AddRange(lColumns.ToArray());
            }

        }

        private IList<DataGridViewColumn> CopyColumns(GenericDGV<TDto> pDGV)
        {
            IList<DataGridViewColumn> lResult = new List<DataGridViewColumn>();

            foreach (DataGridViewColumn col in pDGV.Columns)
            {
                lResult.Add((DataGridViewColumn)col.Clone());
            }

            return lResult;
        }

        private void GetConfigForEntity(Type pEntityType)
        {
            XDocument lXDoc = XDocument.Load("Datagrid.xml");
            IEnumerable<XElement> lXEntityElements = lXDoc.Elements().Elements();

            cLogger.Info("Descomponiendo XML");

            var query = from entity in lXEntityElements
                        where ((string)entity.Attribute("fullName") == pEntityType.FullName)
                        select entity;

            XElement lXEntity = query.FirstOrDefault();
            //TODO excepcion de lxEntity es null despues del default
            string lLanCode = "es-AR"; //TODO obtenerlo de otro luga, anda a saber de donde


            query = from language in lXEntity.Elements()
                    where ((string)language.Attribute("code") == lLanCode)
                    select language;

            XElement lXLanguage = query.FirstOrDefault();

            foreach (var xl in lXLanguage.Elements())
            {
                this.PropertyConfigs.Add
                (
                    new PropertyConfigurations()
                    {
                        PropertyName = xl.Attribute("name").Value,
                        Value = xl.Element("text").Value,
                        Enabled = xl.Element("enable").Value == "true"
                    }
                );
            }



        }

        class PropertyConfigurations
        {
            internal string PropertyName { get; set; }
            internal string Value { get; set; }
            internal bool Enabled { get; set; }

            public override string ToString()
            {
                return String.Format("{0}:{1} ({2})", this.PropertyName, this.Value, this.Enabled);
            }
        }
    }
}


