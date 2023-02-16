using System.Data;
using System.Data.SqlClient;

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
            TestDBConnection(textBox1.Text, textBox2.Text, textBox2.Text, textBox3.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str =  getConnection(textBox1.Text, textBox2.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show(str); 

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