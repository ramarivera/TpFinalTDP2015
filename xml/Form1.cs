﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

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
        string iSelectedEntity;
        string iSelectedLanguage;
        string bannerDTO = "BannerDTO";
        int iPrevLangIndex = 0;
        int iPrevEntityIndex = 0;
        bool iUnsavedChanges = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosed += Form1_FormClosed;
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
        }


        #endregion

        #region Xml Handling
        private void SaveChanges()
        {
            bool lError = this.ValidateConfigFile();

            if (lError)
            {
                MessageBox.Show("Error de Validacion");
            }
            else
            {
                //iConfigFile.Dispose();

                XElement lXEntityLang = (from entity in iConfigContents.Elements().Elements()
                                        from lang in entity.Elements()
                                        where entity.Attribute("name").Value == iSelectedEntity
                                            && lang.Attribute("name").Value == iSelectedLanguage
                                        select lang).FirstOrDefault();

                if (lXEntityLang != null)
                {
                    lXEntityLang.RemoveNodes();
                    lXEntityLang.Add(XDocument.Parse(dataSet.GetXml()).Elements().Elements());
                    iConfigFile.Dispose();

                  //  using (iConfigFile = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                  //  {
                        iConfigContents.Save(path);
                  //  }

                    this.OnLoad(new EventArgs());
                }


                MessageBox.Show(dataSet.GetXml());
            }
        }

        private void ConfigureDataGridView()
        {
            dgvProperties.CellEndEdit += DgvProperties_CellEndEdit;
            /*   dgvProperties.Columns["name"].DisplayIndex = -1;
               dgvProperties.Columns["enabled"].DisplayIndex = -1;
               dgvProperties.Columns["text"].DisplayIndex = -1;*/

            /*  DataGridBoolColumn lBoolColumn = new DataGridBoolColumn();
              lBoolColumn.
              lBoolColumn.HeaderText = "Enabled";
              lBoolColumn.*/

           
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

            //    dgvProperties.AutoGenerateColumns = false;

            //    dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns["enable"]);
                dgvProperties.Columns.Remove(dgvProperties.Columns["enable"]);

              //  dataSet.Tables[0].Columns.Add(new DataColumn("enabled", typeof(int)));
                dgvProperties.Columns.Add(dgvcol1);

                dgvProperties.Columns["name"].DisplayIndex = 0;
                dgvProperties.Columns["text"].DisplayIndex = 1;

                dgvProperties.Columns["name"].HeaderText = "Property Name";
                dgvProperties.Columns["text"].HeaderText = "Text";

                dgvProperties.Columns["name"].ReadOnly = true;

            }
            
            

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
                    //TODO log error message
                }
                );

            return lError;
        }

        private void ReloadLanguageComboBox()
        {
            var query = from entity in iConfigContents.Elements().Elements()
                        where entity.Attribute("name").Value == this.iTranslations[iSelectedEntity]
                        select entity;

            this.cmbLanguage.Items.Clear();

            foreach (XElement lang in query.Elements())
            {
                this.cmbLanguage.Items.Add(lang.Attribute("name").Value);
            }
        }

        private void PopulateComboBox()
        {
            IEnumerable<XElement> lXEntityElements = iConfigContents.Elements().Elements();

            var query = from entity in lXEntityElements
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
                this.iTranslations.Add(name, temp);
                this.cmbEntity.Items.Add(temp);
            }
        }






        private void ReloadPropertyDataSet()
        {
            var query = (from entity in this.iConfigContents.Elements().Elements()
                         from lang in entity.Elements()
                         where entity.Attribute("name").Value == iSelectedEntity
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
        #endregion
    }
}