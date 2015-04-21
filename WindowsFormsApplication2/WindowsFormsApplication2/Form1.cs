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
            Read();
        }

        private void Read()
        {
            XDocument doc = XDocument.Load("companyName.xml");
            var groups = (from dg in doc.Descendants("DocBlock")
                          // where dg.Attribute("name").Value == "Sikker"
                          // from g in dg.Elements("ContentType")
                          select new
                          {
                              contentType = dg.Element("ContentType").Value,
                              ID = dg.Element("ContentItemVersionId").Value,
                              ID2 = dg.Element("ContentItemId").Value,
                              Position = dg.Element("Position").Value,
                              dg.Parent

                          });

            String text = @"<document>
                            <nodes>";
            foreach (var group in groups)
            {
                string ParentID = "";
                string ParentID2 = "";
                if (group.Parent != null && group.Parent.Parent!=null)
                {
                    ParentID = group.Parent.Parent.Element("ContentItemVersionId").Value;
                    ParentID2 = group.Parent.Parent.Element("ContentItemId").Value;
                }
                // viet ra cấu trúc cần thiết
            //    <node type="poste" parent="">
            //    <id></id>
            //    <position></position>
            //</node>
                String note = String.Format(@"<node type=""{0}"" ParentVersionId=""{1}"" ParentId=""{4}"">
                                <VersionId>{2}</VersionId>
                                <id>{5}<id>
                                <position>{3}</position>
                                </node>", group.contentType, ParentID, group.ID, group.Position, ParentID2,group.ID2);
                text += note;

                //  sikkerSone += group.g + ";";
            }
            text += @"</nodes>
                        </document>";
        }
    }
}
