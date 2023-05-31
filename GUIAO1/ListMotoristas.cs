using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIAO1
{
    public partial class ListMotoristas : Form
    {
        private List<Motorista> _motoristaList;
        private SqlConnection _connection;
        private int currentMotorista;
        private int currentVeiculo;
        private int aux = 0;
        private List<Veiculo> veiculosList ;
        public ListMotoristas()
        {

            InitializeComponent();
        }

        public ListMotoristas(List<Motorista> motoraList, SqlConnection cn)
        {
            MotoristaList = motoraList;
            Connection = cn;
            InitializeComponent();
        }

        public List<Motorista> MotoristaList
        {
            get { return _motoristaList; }
            set { _motoristaList = value; }
        }

        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void ListMotristas_Load(object sender, EventArgs e)
        {
            foreach (Motorista m in MotoristaList)
            {
                listBox1.Items.Add(m);
            }
            LockMotoristaControls();
            LockVeiculosControls();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentMotorista = listBox1.SelectedIndex;
                ShowMotoristas();
                Motorista m = new Motorista();
                m = (Motorista)listBox1.SelectedItem;
                getMotoristaVeiculoContent(Connection, m.MotoristaID);

            }
        }

        public void ShowMotoristas()
        {
            if (listBox1.Items.Count == 0 | currentMotorista < 0)
                return;
            Motorista motora = new Motorista();
            motora = (Motorista)listBox1.SelectedItem;
            textBox1.Text = motora.MotoristaNome;
            textBox2.Text = motora.MotoristaEmail;
            textBox3.Text = motora.MotoristaAvaliacao;
            textBox4.Text = motora.MotoristaTelefone;
            textBox5.Text = motora.MotoristaCartaConducao;
        }

        public void LockMotoristaControls()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        public void UnlockMotoristaControls()
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
        }
        public void LockVeiculosControls()
        {
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
        }

        public void UnlockVeiculosControls()
        {
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
        }

        private void getMotoristaVeiculoContent(SqlConnection CN, String id)
        {
          
            try
            {
                
                if (CN.State == ConnectionState.Open)
                {

                    SqlCommand sqlcmd = new SqlCommand("EXEC sp_Motorista_Veiculos " + id, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Veiculo V = new Veiculo();

                        V.VeiculoID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        V.VeiculoMarca = reader.GetString(reader.GetOrdinal("marcar"));
                        V.VeiculoModelo = reader.GetString(reader.GetOrdinal("modelo"));
                        V.VeiculoCor = reader.GetString(reader.GetOrdinal("cor"));
                        V.VeiculoLugares = reader.GetInt32(reader.GetOrdinal("lugares")).ToString();
                        V.VeiculoMatricula = reader.GetString(reader.GetOrdinal("matricula"));
                        V.VeiculoCapacidadeBateria = reader.GetInt32(reader.GetOrdinal("capacidade_bateria")).ToString();
                        veiculosList.Add(V);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentVeiculo = listBox2.SelectedIndex;
                ShowVeiculos();
                             
            }
        }

        public void ShowVeiculos()
        {
            if (listBox1.Items.Count == 0 | currentVeiculo < 0)
                return;
            Veiculo veiculo = new Veiculo();
            veiculo = (Veiculo)listBox2.SelectedItem;
            textBox6.Text = veiculo.VeiculoMarca;
            textBox7.Text = veiculo.VeiculoModelo;
            textBox8.Text = veiculo.VeiculoCor;
            textBox9.Text = veiculo.VeiculoLugares;
            textBox10.Text = veiculo.VeiculoMatricula;
            textBox11.Text = veiculo.VeiculoCapacidadeBateria;
        }
    }
}
