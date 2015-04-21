using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var xmlDoc = new XmlDocument();
            //xmlDoc.Load("companyName.xml");
            //XmlNodeList ListNodeXML = xmlDoc.SelectNodes("root/DocBlock");
            //foreach (XmlNode xmlNode in ListNodeXML)
            //{
            //    XmlNodeList chilnode = xmlNode.SelectNodes("ContentItemVersionId");
            //}
            XDocument doc = XDocument.Load("companyName.xml");
            var groups = (from dg in doc.Descendants("DocBlock")
                         // where dg.Attribute("name").Value == "Sikker"
                         // from g in dg.Elements("ContentType")
                          select new
                              {
                                  contentType = dg.Element("ContentType").Value,
                                  ID = dg.Element("ContentItemVersionId").Value,
                                  Position = dg.Element("Position").Value,
                                  dg.Parent.Parent

                              });

            foreach (var group in groups)
            {
                string ParentID = "";
                if(group.Parent!=null)
                  ParentID= group.Parent.Element("ContentItemVersionId").Value;

              //  sikkerSone += group.g + ";";
            }
        }
    }
}
