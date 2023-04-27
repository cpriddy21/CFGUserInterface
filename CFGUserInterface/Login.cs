using MySql.Data.MySqlClient;

namespace CFGUserInterface
{
    public partial class Login : Form
    {
        BindingSource repBindingSource = new BindingSource();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO DAOinstance = new DAO();
            String name = textBox1.Text;
            String PW = textBox2.Text;
            
            System.Diagnostics.Debugger.Break();
            if (DAOinstance.loginCheck(name, PW) == true)
            {
                Menu f2 = new Menu();
                f2.Show();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu f2 = new Menu();
            f2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DAO DAOinstance = new DAO();
            String name = textBox1.Text;
            String PW = textBox2.Text;

            //System.Diagnostics.Debugger.Break();
            if (DAOinstance.loginCheck(name, PW) == true)
            {
                Menu f2 = new Menu();
                f2.Show();
            }
            
            //hnfianf
        }
    }
}
