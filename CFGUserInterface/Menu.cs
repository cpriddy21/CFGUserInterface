using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFGUserInterface
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Representative Report
            RepresentativeReport f = new RepresentativeReport();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Customer Report
            CustomerReport f = new CustomerReport();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Add new Rep
            AddNewRep f = new AddNewRep();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update customer credit limit
            UpdateCustomerCL f = new UpdateCustomerCL();
            f.Show();
        }
    }
}
