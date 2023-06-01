using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUIAO1
{
    public partial class ListMotoristas : Form
    {
        private List<Motorista> _motoristaList;

        private int currentMotorista;
        private int currentVeiculo;
        private bool adding;
        private bool addingVeiculo;

        public ListMotoristas()
        {

            InitializeComponent();
        }

        public ListMotoristas(List<Motorista> motoraList)
        {
            MotoristaList = motoraList;

            InitializeComponent();
        }

        public List<Motorista> MotoristaList
        {
            get { return _motoristaList; }
            set { _motoristaList = value; }
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
            button4.Visible = false;
            button5.Visible = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Visible = false;
            button9.Visible = false;


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox2.Items.Clear();
                button6.Enabled = true;
                button7.Enabled = true;
                currentMotorista = listBox1.SelectedIndex;
                ShowMotoristas();
                Motorista m = new Motorista();
                m = (Motorista)listBox1.SelectedItem;
                SqlConnection Connection = getConnection();
                _ = new List<Veiculo>();
                List<Veiculo> veiculosList = getMotoristaVeiculoContent(Connection, m.MotoristaID);

                foreach (Veiculo v in veiculosList)
                {
                    listBox2.Items.Add(v);
                }


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



        private List<Veiculo> getMotoristaVeiculoContent(SqlConnection CN, String id)
        {
            List<Veiculo> veiculosList = new List<Veiculo>();
            try
            {
                CN.Open();

                if (CN.State == ConnectionState.Open)
                {

                    string query = "EXEC sp_Motorista_Veiculos " + id;
                    SqlCommand sqlcmd = new SqlCommand(query, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Veiculo V = new Veiculo();

                        V.VeiculoID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        V.VeiculoMarca = reader.GetString(reader.GetOrdinal("marca"));
                        V.VeiculoModelo = reader.GetString(reader.GetOrdinal("modelo"));
                        V.VeiculoCor = reader.GetString(reader.GetOrdinal("cor"));
                        V.VeiculoLugares = reader.GetInt32(reader.GetOrdinal("lugares")).ToString();
                        V.VeiculoMatricula = reader.GetString(reader.GetOrdinal("matricula"));
                        V.VeiculoCapacidadeBateria = reader.GetInt32(reader.GetOrdinal("capacidade_bateria")).ToString();
                        Debug.WriteLine(V.VeiculoModelo);
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

            return veiculosList;
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
            textBox11.Text = veiculo.VeiculoMatricula;
            textBox10.Text = veiculo.VeiculoCapacidadeBateria;
        }

        private SqlConnection getConnection()
        {
            SqlConnection CN = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");

            return CN;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recarga recarga = new Recarga();
            recarga.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearFields();
            UnlockMotoristaControls();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            listBox1.Enabled = false;
            adding = true;

        }

        public void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        public bool createMotorista()
        {
            Motorista motora = new Motorista();
            try
            {
                motora.MotoristaNome = textBox1.Text;
                motora.MotoristaEmail = textBox2.Text;
                motora.MotoristaAvaliacao = textBox3.Text;
                motora.MotoristaTelefone = textBox4.Text;
                motora.MotoristaCartaConducao = textBox5.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            if (adding)
            {
                setMotorista(getConnection(), motora);
                listBox1.Items.Add(motora);
            }
            else
            {
                //update motorista
            }

            return true;
        }

        private void setMotorista(SqlConnection CN, Motorista motora)
        {
            CN.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT  Pessoas(nome, email, foto, avaliacao, telefone, carta_conducao) values(@nome, @email, @foto, @avaliacao, @telefone, @carta_conducao );";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", motora.MotoristaNome);
            cmd.Parameters.AddWithValue("@email", motora.MotoristaEmail);
            cmd.Parameters.AddWithValue("@foto", motora.MotoristaNome + ".jpg");
            cmd.Parameters.AddWithValue("@avaliacao", motora.MotoristaAvaliacao);
            cmd.Parameters.AddWithValue("@telefone", motora.MotoristaTelefone);
            cmd.Parameters.AddWithValue("@carta_conducao", motora.MotoristaCartaConducao);
            cmd.Connection = CN;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                CN.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                createMotorista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button4.Visible = false;
            button5.Visible = false;
            clearFields();
            listBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            clearFields();
            listBox1.Enabled = true;
            adding = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearVeiculosFields();
            UnlockVeiculosControls();
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button9.Visible = true;
            listBox1.Enabled = false;
            addingVeiculo = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        public void clearVeiculosFields()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

        }

        private void button9_Click(object sender, EventArgs e)
        {

           
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
