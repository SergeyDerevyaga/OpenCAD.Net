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
        public Document doc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc = new Document();
            doc.Name = "Example 1";
            doc.Description = "This is an example of OpenCAD.Net Document";
            propertyGrid1.SelectedObject = doc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doc.Save("example.xml");
        }
    }
}
