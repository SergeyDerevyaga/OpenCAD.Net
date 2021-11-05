using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadCoreLib;

namespace TestCadCoreLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.Name = "Example 1";
            doc.Description = "This is an example of OpenCAD.Net Document";

            Sheet sh = new Sheet();
            doc.Sheets.Add(sh);

            sh = new Sheet();
            sh.Format = Formats.A3;
            sh.Multiplier = 3;
            sh.Landscape = true;
            doc.Sheets.Add(sh);

            CadCoreLib.View vw = new CadCoreLib.View();
            vw.Scale = 0.5f;
            sh.Views.Add(vw);

            doc.Save("example.xml");
        }
    }
}
