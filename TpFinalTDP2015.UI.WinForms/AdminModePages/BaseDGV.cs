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
        //private DGVHelper iHelper;

        public Type DTOType { get; set; }

        public BaseDGV()
        {
            InitializeComponent();
        }

        public BaseDGV(Type pDTOType)
        {
            this.DTOType = pDTOType;
          //  this.iHelper = new DGVHelper();
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

        public void AddToSource(List<IDTO> pDTOs)
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
            DataGridViewColumnCollection lcole = this.Columns;
            //this.iHelper.Configure(this);
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


    /*class DGVHelper
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DGVHelper>();

        IList<PropertyConfigurations> PropertyConfigs { get; set; }

        public void Configure(BaseDGV pDGV)
        {
            this.GetConfigForEntity(pDGV.DTOType);
            this.ConfigureColumns(pDGV);

        }

        private void ConfigureColumns(BaseDGV pDGV)
        {
            int i = 0;
            bool lFound = true;
            IList<DataGridViewColumn> lColumns = this.CopyColumns(pDGV);

            while (lFound && i < lColumns.Count)
            {
                DataGridViewColumn lCol = lColumns[i];
                lFound = PropertyConfigs.Any(pro => pro.PropertyName == lCol.Name);
                i++;
            }

            if (lFound)
            {
                PropertyConfigurations lProp = PropertyConfigs
                                    .Where(pro => pro.PropertyName == lColumns[i].Name)
                                    .FirstOrDefault();
                if (lProp != null)
                {
                    if (lProp.Enabled)
                    {
                        lColumns[i].Name = lProp.Value;
                    }
                    else
                    {
                        lColumns.RemoveAt(i);
                    }
                }
                else//TODO cagamos viteh
                {

                }
            }



            for (int i = lColumns.Count - 1; i >= 0; --i)
            {
                

                if (lFound !=  null) 
                {
                    if (lFound.Enabled)
                    {
                        lColumns[i].Name = lFound.Value;
                    }
                    else
                    {
                        lColumns.RemoveAt(i);
                    }
                }
                else//TODO cagamos viteh
                {

                }
            }

            pDGV.Columns.Clear();

            foreach (DataGridViewColumn col in lColumns)
            {
                pDGV.Columns.Add
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
            string lLanCode = "en"; //TODO obtenerlo de otro luga, anda a saber de donde


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
                        Enabled = xl.Element("enable").Value == "1"
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
            internal  bool Enabled { get; set; }
        }

    

