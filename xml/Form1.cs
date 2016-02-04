using System;
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
        DataSet dataSet = new DataSet();
        string path = ".\\Datagrid.xml";
        XDocument iConfigFile;
        IDictionary<String, String> iTranslations = new Dictionary<String, String>();
        string bannerDTO = "BannerDTO"; 

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iConfigFile = XDocument.Load(path);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("xml.XmlSchema.xsd");
            XmlSchemaSet lSchemaSet = new XmlSchemaSet();
            lSchemaSet.Add(XmlSchema.Read(stream, null));

            iConfigFile.Validate(lSchemaSet,null);
            PopulateComboBox();
            cmbTable.SelectedIndex = 0;
            ReloadLanguageComboBox();
            cmbLanguage.SelectedIndex = 0;
            ReloadPropertyDataSet();
            cmbTable.SelectedIndexChanged += cmbTable_SelectedIndexChanged;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;

        }

        private void ReloadLanguageComboBox()
        {
            var query = from entity in iConfigFile.Elements().Elements()
                        where entity.Attribute("name").Value == this.iTranslations[(string)this.cmbTable.SelectedItem]
                        select entity;

            this.cmbLanguage.Items.Clear();

            foreach (var lang in query.Elements())
            {
                this.cmbLanguage.Items.Add(((XElement)lang).Attribute("name").Value);
            }
        }

        private void PopulateComboBox()
        {
            IEnumerable<XElement> lXEntityElements = iConfigFile.Elements().Elements();

            var query = from entity in lXEntityElements
                        select (string)entity.Attribute("name").Value;

            this.cmbTable.Items.Clear();


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
                string temp = (string) fieldInfo.GetValue(this).ToString();
                this.iTranslations.Add(name, temp);
                this.cmbTable.Items.Add(temp);
            }

           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Create xml reader
                XmlReader xmlFile = XmlReader.Create(openFileDialog1.FileName, new XmlReaderSettings());
                
                //Read xml to dataset
                dataSet.ReadXml(xmlFile);
                //Pass empdetails table to datagridview datasource
                
                //Close xml reader
                xmlFile.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debugger.Break();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* string tabla = this.textBox1.Text;

            dgvProperties.DataSource = dataSet.Tables[tabla];
            */
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReloadLanguageComboBox();
            this.ReloadPropertyDataSet();
        }

        private void ReloadPropertyDataSet()
        {
            

            string lEntityName = (string) this.cmbTable.SelectedItem;
            string lLanguage = (string)this.cmbLanguage.SelectedItem;

            var query = from entity in this.iConfigFile.Elements().Elements()
                        where (string)entity.Attribute("name").Value == lEntityName
                                && (from lang in entity.Elements()
                                    where (string)lang.Attribute("name").Value == lLanguage
                                    select lang).FirstOrDefault() != null
                        select (entity.Element("language"));

            IList<XElement> lXml = query.Elements().ToList();
            XDocument lXProperties = new XDocument(new XElement("root"));

            foreach (var item in lXml)
            {
                lXProperties.Element("root").Add(item);
            }

            dataSet.ReadXml(lXProperties.CreateReader());

            this.dgvProperties.DataSource = dataSet.Tables[0];



        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ReloadPropertyDataSet();

        }
    }
}
