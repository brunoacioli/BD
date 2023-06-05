using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GUIAO1
{
    public partial class ListClients : Form
    {

        private List<Cliente> _clientesList;
        Cliente cliente;
        private SqlConnection _connection;
        private int clientIndex;

        public ListClients()
        {
            InitializeComponent();
        }

        public ListClients(List<Cliente> clientesList, SqlConnection cn)
        {
            ClientesList = clientesList;
            Connection = cn;
            InitializeComponent();
            button1.Visible = false;
        }

        public List<Cliente> ClientesList
        {
            get { return _clientesList; }
            set { _clientesList = value; }
        }

        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        private void ListClients_Load(object sender, EventArgs e)
        {
            button1.Visible = false;

            foreach (Cliente c in ClientesList)
            {
                listBox1.Items.Add(c);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = false;

            if (listBox1.SelectedIndex >= 0)
            {
                clientIndex = listBox1.SelectedIndex;
                showClientes();
                button1.Visible = true;

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showClientes()
        {
            if (listBox1.Items.Count == 0 | clientIndex < 0)
                return;
            cliente = (Cliente)listBox1.SelectedItem;
            textBox1.Text = cliente.ClienteNome;
            textBox2.Text = cliente.ClienteEmail;
            textBox3.Text = cliente.ClienteAvaliacao;
            textBox4.Text = cliente.ClienteTelefone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("ALOOOOOOOOOO");
            SqlConnection connection = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");
            List<Corrida> corridasList = getCorridasByClientId(connection, cliente.ClienteID);
            Debug.WriteLine("#######");
            Debug.WriteLine(corridasList.Count);

            ListCorridas corridas = new ListCorridas(corridasList, cliente.ClienteID);
            corridas.Show();
        }


        private List<Corrida> getCorridasByClientId(SqlConnection CN, String id)
        {
            List<Corrida> corridasList = new List<Corrida>();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {

                    SqlCommand sqlcmd = new SqlCommand("EXEC sp_Cliente_Corridas " + id, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Corrida C = new Corrida();
                        C.id = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        C.partida = reader.GetString(reader.GetOrdinal("partida"));
                        C.destino = reader.GetString(reader.GetOrdinal("destino"));
                        //C.inicio = reader.GetString(reader.GetOrdinal("inicio"));
                        //C.fim = reader.GetString(reader.GetOrdinal("fim")).ToString();
                        C.duracao = reader.IsDBNull(reader.GetOrdinal("duracao")) ? null : reader.GetString(reader.GetOrdinal("duracao")).ToString();
                        C.pagamento = reader.IsDBNull(reader.GetOrdinal("pagamento")) ? null : reader.GetDecimal(reader.GetOrdinal("pagamento")).ToString().Substring(0, 4);
                        C.gorjeta = reader.IsDBNull(reader.GetOrdinal("gorjeta")) ? null : reader.GetDecimal(reader.GetOrdinal("gorjeta")).ToString().Substring(0, 4);
                        C.id_cliente = reader.GetInt32(reader.GetOrdinal("id_cliente")).ToString();
                        C.id_motorista = reader.GetInt32(reader.GetOrdinal("id_motorista")).ToString();
                        corridasList.Add(C);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
            return corridasList;
        }
    }
}
