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
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.AdminModePages
{
    public partial class BaseDGV : DataGridView
    {
        private static readonly ILog cLogger = LogManager.GetLogger<BaseDGV>();

        public BindingSource iSource = new BindingSource(); //TODO cambiar public por private
        private DGVHelper iHelper = new DGVHelper();

        public Type DTOType { get; set; }

        public BaseDGV()
        {
            InitializeComponent();
        }

        public IDTO GetItem(int pRowIndex)
        {
            return (IDTO)this.Rows[pRowIndex].DataBoundItem;
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
                this.Rows[this.RowCount - 1].Tag = pDTO;
            }
        }

        public void Modificar(IAddModifyViewForm pForm, IDTO pDTO)
        {
            pForm.Modificar(pDTO);
            DialogResult resultado = pForm.ShowForm();
            if (resultado == DialogResult.OK)
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
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar " + cadena + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        public void AddToSource(IList<IDTO> pDTOs)
        {
            if (this.DTOType == null)
            {
                this.DTOType = pDTOs.First().GetType();
            }
            foreach (IDTO pDTO in pDTOs)
            {
                if (pDTO.GetType() != this.DTOType)
                {
                    //TODO tirar excepcion porque parece que hay un elemento intruso metido aca
                }
                this.iSource.Add(pDTO);
            }
            this.DataSource = this.iSource;
            this.iHelper.Configure(this);
        }

        public IList<IDTO> GetAll()
        {
            IList<IDTO> lList = new List<IDTO>();
            foreach (IDTO element in this.iSource)
            {
                lList.Add(element);
            }
            return lList;
        }
    }


    class DGVHelper
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DGVHelper>();

        IList<PropertyConfigurations> PropertyConfigs { get; set; }

        internal DGVHelper()
        {
            this.PropertyConfigs = new List<PropertyConfigurations>();
        }

        public void Configure(BaseDGV pDGV)
        {
            pDGV.AutoGenerateColumns = false;
            //  pDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GetConfigForEntity(pDGV.DTOType);
            this.ConfigureColumns(pDGV);

        }


        private void ConfigureColumns(BaseDGV pDGV)
        {
            int i = 0;
            bool lError = false;
            IList<DataGridViewColumn> lColumnsToRemove = new List<DataGridViewColumn>();
            IList<DataGridViewColumn> lColumns = this.CopyColumns(pDGV);

            while (!lError && i < lColumns.Count)
            {
                DataGridViewColumn lCol = lColumns[i];
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

        private IList<DataGridViewColumn> CopyColumns(BaseDGV pDGV)
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



            /*  cLogger.InfoFormat
                  (
                  "Propiedad: {0}, Texto: {1}, Mostrar: {2}",
                  xl.Attribute("name").Value,
                  xl.Element("text").Value,
                  xl.Element("enable").Value
                  );*/

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


