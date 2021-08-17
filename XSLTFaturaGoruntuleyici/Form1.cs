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
using System.Xml;
using System.Xml.Xsl;

namespace XSLTFaturaGoruntuleyici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string xml = File.ReadAllText(Application.StartupPath + "\\5630634486-SYM2019000001059.xml");
            string xslt_str = File.ReadAllText(Application.StartupPath + "\\ThreeColor.xslt");

            string output = String.Empty;

            using (StringReader srt = new StringReader(xslt_str)) 
            using (StringReader sri = new StringReader(xml)) 
            {
                using (XmlReader xrt = XmlReader.Create(srt))
                using (XmlReader xri = XmlReader.Create(sri))
                {
                    XslCompiledTransform xslt = new XslCompiledTransform();
                    xslt.Load(xrt);
                    using (StringWriter sw = new StringWriter())
                    using (XmlWriter xwo = XmlWriter.Create(sw, xslt.OutputSettings)) 
                    {
                        xslt.Transform(xri, xwo);
                        output = sw.ToString();
                        webBrowser1.DocumentText = output;
                    }
                }
            }

          
        }
    }
}
