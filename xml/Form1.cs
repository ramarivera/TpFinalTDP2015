using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using TpFinalTDP2015.Service.DTO;

namespace xml
{
    public partial class Form1 : Form
    {
        #region Fields
        DataSet dataSet = new DataSet();
        string path = ".\\Datagrid.xml";
        XDocument iConfigContents;
        FileStream iConfigFile;
        XmlSchemaSet iSchemaSet = new XmlSchemaSet();
        IDictionary<String, String> iTranslations = new Dictionary<String, String>();
        IList<string> iEntityNames;

        string iSelectedEntity;
        string iSelectedLanguage;
        int iPrevLangIndex = 0;
        int iPrevEntityIndex = 0;
        bool iUnsavedChanges = false;

        string banner = "Banner";
        string campaign = "Campaña";
        string slide = "Diapositiva";
        string staticText = "Texto";
        string rssItem = "Item RSS";
        string rssSource = "Fuente RSS";
        string timeInterval = "Intervalo de Tiempo";
        string dateInterval = "Intervalo de Fechas";
        AdminBannerDTO bannnner; //TODO es solo para testear el descrubrimiento de tipos mediante reflection

        #endregion

        public Form1()
        {
            InitializeComponent();

            this.iEntityNames = new List<string>()
            {
                "TpFinalTDP2015.Service.DTO.BannerDTO",
                "TpFinalTDP2015.Service.DTO.CampaignDTO",
                "TpFinalTDP2015.Service.DTO.SlideDTO",
                "TpFinalTDP2015.Service.DTO.TimeIntervalDTO",
                "TpFinalTDP2015.Service.DTO.DateIntervalDTO",
                "TpFinalTDP2015.Service.DTO.RssItemDTO",
                "TpFinalTDP2015.Service.DTO.RssSourceDTO",
                "TpFinalTDP2015.Service.DTO.StaticTextDTO"
            };

            Load += Form1_Load;
            FormClosed += Form1_FormClosed;
        }


        private IEnumerable<XElement> EntityList
        {
            get
            {
                return this.iConfigContents.Elements().Elements();
            }
        }

        #region Event Handlers
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (iConfigFile != null)
            {
                iConfigFile.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbEntity.SelectedIndexChanged -= cmbTable_SelectedIndexChanged;
            cmbEntity.Enter -= CmbTableLanguage_Enter;

            cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;
            cmbLanguage.Enter -= CmbTableLanguage_Enter;

            LoadConfigFile();

            PopulateComboBox();
            cmbEntity.SelectedIndex = iPrevEntityIndex;
            iSelectedEntity = (string)cmbEntity.SelectedItem;

            ReloadLanguageComboBox();
            cmbLanguage.SelectedIndex = iPrevLangIndex;
            iSelectedLanguage = (string)cmbLanguage.SelectedItem;

            ReloadPropertyDataSet();
            ConfigureDataGridView();

            cmbEntity.SelectedIndexChanged += cmbTable_SelectedIndexChanged;
            cmbEntity.Enter += CmbTableLanguage_Enter;

            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            cmbLanguage.Enter += CmbTableLanguage_Enter;

            PopulateLangaugeAdderComboBox();

        }

        private void PopulateLangaugeAdderComboBox()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            IList<CultureInfo> lCultures = new List<CultureInfo>();

            foreach (CultureInfo culture in cultures.Skip(1))
            {
                lCultures.Add(culture);
            }

            cmbLanguageAdder.DisplayMember = "DisplayName";
            cmbLanguageAdder.DataSource = new BindingList<CultureInfo>(lCultures);

        }

        private void CmbTableLanguage_Enter(object sender, EventArgs e)
        {
            if ((ComboBox)sender == cmbEntity)
            {
                iPrevEntityIndex = cmbEntity.SelectedIndex;
            }
            else
            {
                iPrevLangIndex = cmbLanguage.SelectedIndex;
            }
        }

        private void DgvProperties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            iUnsavedChanges = true;
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iUnsavedChanges)
            {
                DialogResult lDialog = MessageBox.Show(
                    "Hay cambios sin guardar, desea continuar y perder los mismos?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                if (DialogResult.No == lDialog)
                {
                    RestoreEntityIndex();
                }
                else if (DialogResult.Yes == lDialog)
                {
                    iUnsavedChanges = false;
                    iPrevEntityIndex = cmbEntity.SelectedIndex;

                }
            }
            if (!iUnsavedChanges)
            {
                iSelectedEntity = (string)cmbEntity.SelectedItem;
                this.ReloadLanguageComboBox();
                this.ReloadPropertyDataSet();
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iUnsavedChanges)
            {
                DialogResult lDialog = MessageBox.Show(
                     "Hay cambios sin guardar, desea continuar y perder los mismos?",
                     "Advertencia",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning
                     );

                if (DialogResult.No == lDialog)
                {
                    RestoreLangIndex();
                }
                else if (DialogResult.Yes == lDialog)
                {
                    iUnsavedChanges = false;
                    iPrevLangIndex = cmbLanguage.SelectedIndex;
                }
            }
            if (!iUnsavedChanges)
            {
                iSelectedLanguage = (string)cmbLanguage.SelectedItem;
                this.ReloadPropertyDataSet();
            }
        }

        private void RestoreEntityIndex()
        {
            cmbEntity.SelectedIndexChanged -= cmbTable_SelectedIndexChanged;
            cmbEntity.Enter -= CmbTableLanguage_Enter;

            cmbEntity.SelectedIndex = iPrevEntityIndex;

            cmbEntity.SelectedIndexChanged += cmbTable_SelectedIndexChanged;
            cmbEntity.Enter += CmbTableLanguage_Enter;
        }

        private void RestoreLangIndex()
        {
            cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;
            cmbLanguage.Enter -= CmbTableLanguage_Enter;

            cmbLanguage.SelectedIndex = iPrevLangIndex;

            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            cmbLanguage.Enter += CmbTableLanguage_Enter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
            /*   CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
               foreach (CultureInfo culture in cultures)
               {
                   try
                   {
                       MessageBox.Show(culture.DisplayName + "___" + culture.EnglishName);
                   }
                   catch (CultureNotFoundException exc)
                   {
                       Console.WriteLine(culture + " is not available on the machine or is an invalid culture identifier.");
                   }
               }*/
        }


        #endregion

        #region Xml Handling

        private IList<string> DiscoverPropertiesForEntity(string pEntityName)
        {
            IList<String> lResult = new List<String>();
            PropertyInfo[] propertyInfos;
            Type lType;

            AssemblyName lAsmName = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                                     from asmName in asm.GetReferencedAssemblies()
                                     where asmName.Name.Contains("TpFinalTDP2015.Service")
                                     select asmName).FirstOrDefault();

            lType = Assembly.Load(lAsmName).GetType(pEntityName);

            if (lType != null)
            {
                propertyInfos = lType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in propertyInfos)
                {
                    lResult.Add(prop.Name);
                }
            }

            return lResult;
        }



        private void RebuildConfigFile()
        {
            Regex regex = new Regex("DTO.(.*?)DTO");

            iConfigContents.RemoveNodes();
            iConfigContents.Add(new XElement("root"));

            foreach (string name in iEntityNames)
            {
                string lName = regex.Match(name).Groups[1].ToString();
                XElement lEntity = new XElement("entity", new XAttribute("name", lName), new XAttribute("fullName", name));

                XElement lLang = GetNewLanguage(name, null);
                lEntity.Add(lLang);

                iConfigContents.Element("root").Add(lEntity);
            }

            SaveFile();
        }

        private XElement GetNewLanguage(string pName, CultureInfo pCulture = null)
        {
            XElement lLang = GetLanguage(pCulture); ;

            foreach (var propName in DiscoverPropertiesForEntity(pName))
            {
                XElement lProp = new XElement(
                    "property",
                    new XAttribute(
                        "name",
                        propName
                        ),
                    new XElement(
                        "text",
                        propName
                        ),
                    new XElement(
                        "enable",
                        "true"
                        )
                    );
                lLang.Add(lProp);
            }

            return lLang;
        }

        private XElement GetLanguage(CultureInfo pCulture = null)
        {
            XElement lLang = new XElement(
                "language",
                new XAttribute("name", "English"),
                new XAttribute("code", "en")
                );

            if (pCulture != null)
            {
                lLang.Attribute("name").SetValue(pCulture.DisplayName);
                lLang.Attribute("code").SetValue(pCulture.Name);
            }

            return lLang;
        }

        private void LoadConfigFile()
        {
            this.iConfigFile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            //iConfigFile.
            iConfigContents = XDocument.Load(iConfigFile);
            if (iSchemaSet.Count == 0)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                iSchemaSet.Add(
                    XmlSchema.Read(
                        assembly.GetManifestResourceStream("xml.XmlSchema.xsd"),
                        null
                        )
                    );
            }
            ValidateConfigFile();
        }

        private bool ValidateConfigFile()
        {
            bool lError = false;
            iConfigContents.Validate(iSchemaSet,
                (o, e) =>
                {
                    lError = true;
                    MessageBox.Show(e.Message);
                    //TODO log error message            
                }
                );

            var query = EntityList;

            int i = 0;

            while (!lError && i < iEntityNames.Count)
            {
                string lName = iEntityNames[i];
                lError = !query.Any(xl => xl.Attribute("fullName").Value == lName);
                i++;
            }

            return lError;
        }
        private void ConfigureDataGridView()
        {
            dgvProperties.CellEndEdit += DgvProperties_CellEndEdit;
            dgvProperties.AutoGenerateColumns = false;

            if (dgvProperties.Columns["enable"] != null)
            {
                DataGridViewCheckBoxColumn dgvcol1 = new DataGridViewCheckBoxColumn()
                {
                    DataPropertyName = "enable",
                    Name = "Enabled",
                    HeaderText = "Enabled?",
                    TrueValue = "true",
                    FalseValue = "false",
                };

                dgvProperties.Columns.Remove(dgvProperties.Columns["enable"]);

                dgvProperties.Columns.Add(dgvcol1);

                dgvProperties.Columns["name"].DisplayIndex = 0;
                dgvProperties.Columns["text"].DisplayIndex = 1;

                dgvProperties.Columns["name"].HeaderText = "Property Name";
                dgvProperties.Columns["text"].HeaderText = "Text";

                dgvProperties.Columns["name"].ReadOnly = true;
            }
        }

        private void ReloadLanguageComboBox()
        {
            var query = from entity in EntityList
                        where entity.Attribute("name").Value == this.iTranslations[iSelectedEntity]
                        select entity;

            this.cmbLanguage.Items.Clear();

            foreach (XElement lang in query.Elements())
            {
                this.cmbLanguage.Items.Add(lang.Attribute("name").Value);
            }

            cmbLanguage.SelectedIndex = 0;
        }

        private void PopulateComboBox()
        {
            var query = from entity in EntityList
                        select entity.Attribute("name").Value;

            this.cmbEntity.Items.Clear();
            this.iTranslations.Clear();

            foreach (string name in query)
            {
                StringBuilder tempName = new StringBuilder();
                tempName.Append(char.ToLower(name[0]));

                foreach (char c in name.Skip(1))
                {
                    tempName.Append(c);
                }

                FieldInfo fieldInfo = this.GetType().GetField(tempName.ToString(), BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance);
                string temp = (string)fieldInfo.GetValue(this).ToString();
                this.iTranslations.Add(temp, name);
                this.cmbEntity.Items.Add(temp);
            }






        }

        private void ReloadPropertyDataSet()
        {
            var query = (from entity in EntityList
                         from lang in entity.Elements()
                         where entity.Attribute("name").Value == iTranslations[iSelectedEntity]
                                 && lang.Attribute("name").Value == iSelectedLanguage
                         select lang).Elements();

            XDocument lXProperties = new XDocument(new XElement("root"));

            foreach (var item in query)
            {
                lXProperties.Element("root").Add(item);
            }

            dataSet.Clear();
            dataSet.ReadXml(lXProperties.CreateReader());

            this.dgvProperties.DataSource = null;
            this.dgvProperties.DataSource = dataSet.Tables[0];
            this.ConfigureDataGridView();
        }

        private void SaveChanges()
        {
            bool lError = this.ValidateConfigFile();

            if (lError)
            {
                DialogResult lDialog = MessageBox.Show(
                    "Error de Validacion, Desea regenerar el archivo?",
                    "Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                    );

                if (lDialog == DialogResult.Yes)
                {
                    RebuildConfigFile();
                }
            }
            else
            {
                XElement lXEntityLang = (from entity in EntityList
                                         from lang in entity.Elements()
                                         where entity.Attribute("name").Value == iSelectedEntity
                                             && lang.Attribute("name").Value == iSelectedLanguage
                                         select lang).FirstOrDefault();

                if (lXEntityLang != null)
                {
                    lXEntityLang.RemoveNodes();
                    lXEntityLang.Add(XDocument.Parse(dataSet.GetXml()).Elements().Elements());
                    SaveFile();
                }

                MessageBox.Show(dataSet.GetXml());
            }
        }

        private void SaveFile()
        {
            iConfigFile.Dispose();

            //  using (iConfigFile = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            //  {
            iConfigContents.Save(path);
            //  }
            this.OnLoad(new EventArgs());
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            CultureInfo lCulture = (CultureInfo)cmbLanguageAdder.SelectedItem;


            string tempName = (from str in iEntityNames
                               where str.Contains(iTranslations[iSelectedEntity])
                               select str).FirstOrDefault();

            XElement lLang = GetNewLanguage(tempName, lCulture);

            var query = from entity in EntityList
                        where entity.Attribute("name").Value == iTranslations[iSelectedEntity] &&
                              !(entity.Elements().Any(lan => lan.Attribute("name").Value == lLang.Attribute("name").Value))
                        select entity;

            if (query.FirstOrDefault() != null)
            {
                query.FirstOrDefault().Add(lLang);
                SaveChanges();
            }
            else
            {
                MessageBox.Show("Test");
            }
            

           
        }


    }
}
