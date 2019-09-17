using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CompareTool
{
    public partial class Form1 : Form
    {
        public IEnumerable<string> objects;
        public XElement xcontent;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            xcontent = XElement.Load(@"C:\Users\gurudeepm\Downloads\migrate\content.xml");
            objects = xcontent.Descendants("Object").Select(r => r.Attribute("Type").Value).Distinct();
            var objectList = objects.ToList();
            comboBox1.DataSource = objectList;
            using(StreamWriter sw  = File.CreateText(@"C:\Users\gurudeepm\Downloads\migrate\diffFile.txt"))
            {
                sw.WriteLine(String.Join("\\n",objectList));
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var comboValue = comboBox1.SelectedItem.ToString();
            var objectContent = xcontent.Descendants("Object").Where(r => r.Attribute("Type").Value == comboValue).Descendants("Properties").ToList();
            //if(objectContent)
            listBox1.Items.Clear();
            switch (comboValue)
            {
                case "Telerik.Sitefinity.Security.Model.Role":
                    SimpleObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.Pages.Model.PageTemplate":
                    DynamicsObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.Pages.Model.PageControl":
                    DynamicsObjectReturn2(objectContent);
                    break;
                case "Telerik.Sitefinity.Pages.Model.ControlProperty":
                    SimpleObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.DynamicTypes.Model.ThePortalConnectorExtensions.SavedQuery":
                    SimpleObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.Pages.Model.TemplateControl":
                    DynamicsObjectReturn3(objectContent);
                    break;
                case "pavliks.PortalConnector.Migrations.Exporting.Content.Identifiers.Media.ThumbnailWrapper":
                    SimpleObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.Forms.Model.FormDraft":
                    SimpleObjectReturn(objectContent);
                    break;
                case "Telerik.Sitefinity.Forms.Model.FormDraftControl":
                    DynamicsObjectReturn3(objectContent);
                    break;
                case "Telerik.Sitefinity.Forms.Model.FormControl":
                    DynamicsObjectReturn3(objectContent);
                    break;
                default:
                    DynamicsObjectReturn(objectContent);
                    break;
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DynamicsObjectReturn(List<XElement> objectContent)
        {
            var test2 = objectContent.Select(r => (new PageTemplate() { Id = Convert.ToString(r.Element("Id").Value), Name = Convert.ToString(r.Element("Title").Element("invariant").Value), ApplicationName = Convert.ToString(r.Element("ApplicationName").Value) }));
            //Permission = Convert.ToString(r.Descendants("Permissions").Select(y => { new Permissions() { Id = Convert.ToString(null), PermissionName = Convert.ToString(null) } })).ToList()

            foreach (PageTemplate pageTemplate in test2)
            {
                listBox1.Items.Add(pageTemplate.Id);
                listBox1.Items.Add(pageTemplate.Name);
                listBox1.Items.Add(pageTemplate.ApplicationName);
                //foreach(Permissions permissions in pageTemplate.Permission)
                //{
                //    listBox1.Items.Add(permissions.Id);
                //    listBox1.Items.Add(permissions.PermissionName);
                //}
            }
        }

        private void DynamicsObjectReturn2(List<XElement> objectContent)
        {
            var test2 = objectContent.Select(r => (new BaseClass() { Id = Convert.ToString(r.Element("Id").Value), Name = Convert.ToString(r.Element("PlaceHolder").Value) }));
            //Permission = Convert.ToString(r.Descendants("Permissions").Select(y => { new Permissions() { Id = Convert.ToString(null), PermissionName = Convert.ToString(null) } })).ToList()

            foreach (BaseClass pageTemplate in test2)
            {
                listBox1.Items.Add(pageTemplate.Id);
                listBox1.Items.Add(pageTemplate.Name);
                //listBox1.Items.Add(pageTemplate.ApplicationName);
                //foreach(Permissions permissions in pageTemplate.Permission)
                //{
                //    listBox1.Items.Add(permissions.Id);
                //    listBox1.Items.Add(permissions.PermissionName);
                //}
            }
        }

        private void DynamicsObjectReturn3(List<XElement> objectContent)
        {
            var test2 = objectContent.Select(r => (new BaseClass() { Id = Convert.ToString(r.Element("Id").Value), Name = Convert.ToString(r.Element("PlaceHolder").Value) }));
            //Permission = Convert.ToString(r.Descendants("Permissions").Select(y => { new Permissions() { Id = Convert.ToString(null), PermissionName = Convert.ToString(null) } })).ToList()

            foreach (BaseClass pageTemplate in test2)
            {
                listBox1.Items.Add(pageTemplate.Id);
                listBox1.Items.Add(pageTemplate.Name);
                //listBox1.Items.Add(pageTemplate.ApplicationName);
                //foreach(Permissions permissions in pageTemplate.Permission)
                //{
                //    listBox1.Items.Add(permissions.Id);
                //    listBox1.Items.Add(permissions.PermissionName);
                //}
            }
        }

        private void SimpleObjectReturn(List<XElement> objectContent)
        {
            var test1 = objectContent.Select(r => (new BaseClass() { Id = Convert.ToString(r.Element("Id").Value), Name = Convert.ToString(r.Element("Name").Value) })).ToList();
            //.Select(r => r.Descendants("Properties").Select(x=>x.Attribute("Id").Value) .ToList());
            foreach (BaseClass values in test1)
            {
                listBox1.Items.Add(values.Id);
                listBox1.Items.Add(values.Name);
            }
        }
    }
}
