using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUIAO1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection CN = getConnection();
            List<Motorista> data = getMotoristasContent(CN);         

            ListMotoristas listMotoristas = new ListMotoristas(data, CN);
            listMotoristas.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // string str = getConnection();
            //MessageBox.Show(str);

            //ListClients listClients = new ListClients();

           // listClients.Show();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}