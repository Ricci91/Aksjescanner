using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stockscanner
{
    public partial class Form1 : Form
    {
        Scanner scanner;
        public Form1()
        {
            InitializeComponent();
            scanner = new Scanner();
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(scanner.scan());
        }
    }
}
