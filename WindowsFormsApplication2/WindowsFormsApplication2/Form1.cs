﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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


        }

        private void Read()
        {
            XDocument doc = XDocument.Load("input.xml");
            var groups = (from dg in doc.Descendants("DocBlock")
                          // where dg.Attribute("name").Value == "Sikker"
                          // from g in dg.Elements("ContentType")
                          select new
                          {
                              contentType = (dg.Element("ContentType") != null) ? dg.Element("ContentType").Value : "",
                              ID = (dg.Element("ContentItemVersionId") != null) ? dg.Element("ContentItemVersionId").Value : "",
                              ID2 = (dg.Element("ContentItemId") != null) ? dg.Element("ContentItemId").Value : "",
                              Position = (dg.Element("Position") != null) ? dg.Element("Position").Value : "",
                              dg.Parent

                          });

            String text =
@"<document>
    <nodes>
";
            foreach (var group in groups)
            {
                string ParentID = "";
                string ParentID2 = "";
                if (group.Parent != null && group.Parent.Parent != null)
                {
                    ParentID = (group.Parent.Parent.Element("ContentItemVersionId") != null) ? group.Parent.Parent.Element("ContentItemVersionId").Value : "";
                    ParentID2 = (group.Parent.Parent.Element("ContentItemId") != null) ? group.Parent.Parent.Element("ContentItemId").Value : "";
                }
                // viet ra cấu trúc cần thiết
                //    <node type="poste" parent="">
                //    <id></id>
                //    <position></position>
                //</node>
                String note = String.Format(
@"      <node type=""{0}"" ParentVersionId=""{1}"" ParentId=""{4}"">
            <VersionId>{2}</VersionId>
            <id>{5}</id>
            <position>{3}</position>
        </node>
", group.contentType, ParentID, group.ID, group.Position, ParentID2, group.ID2);
                text += note;

                //  sikkerSone += group.g + ";";
            }
            text +=
@"  </nodes>
</document>";
            using (FileStream fs = new FileStream("result.xml", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(text);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            var et = new Orchard_Edilexpert_PRODEntities();

            if (radioButton1.Checked)
            {
                int _from = Convert.ToInt32(txtFrom.Text);
                int _to = Convert.ToInt32(txtTo.Text);
                //blogs = et.Edilex_Documents_DocumentPartRecord.Where(r => r.Id >= _from && r.Id <= _to && r.DocBlockTree != null).Select(r=>r.DocBlockTree).ToList();
                data = (from b in et.Edilex_Documents_DocumentPartRecord
                         where b.Id >= _from && b.Id <= _to && b.DocBlockTree != null
                         select b.DocBlockTree).ToList();
            }
            else if (raAll.Checked)
            {
                data = (from b in et.Edilex_Documents_DocumentPartRecord
                         where b.DocBlockTree != null
                         select b.DocBlockTree).ToList();

            }
            if (data == null||data.Count==0)
            {
                MessageBox.Show("Không có dữ liệu Docblock trong khoảng chọn");
                return;
            }
            //  clear contend  

            File.WriteAllText("result.xml", String.Empty);

            // write đoạn đầu
            using (FileStream fs = new FileStream("result.xml", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("<documents>");
            }
            // var student = L2EQuery.FirstOrDefault<String>();
            foreach (var contents in data)
            {
                String contents2 = contents.Replace("utf-16", "utf-8");
                System.IO.File.WriteAllText(@"input.xml", contents2);
                Read();
            }
            // write đoạn cuối
            using (FileStream fs = new FileStream("result.xml", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("</documents>");
            }
            MessageBox.Show("Done!");
        }

        public List<string> data { get; set; }
    }
}