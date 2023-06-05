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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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
            motoristaOkButton.Visible = false;
            motoristaCancelButton.Visible = false;
            veiculoAddButton.Enabled = false;
            veiculoEditButton.Enabled = false;
            veiculoCancelButton.Visible = false;
            veiculoOkButton.Visible = false;


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("fora");
            if (listBox1.SelectedIndex >= 0)
            {
                Debug.WriteLine("dentro");
                listBox2.Items.Clear();
                clearVeiculosFields();
                veiculoAddButton.Enabled = true;
                veiculoEditButton.Enabled = true;
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
            Debug.WriteLine("Aaaaaaaaaaaa");
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
            cmd.CommandText = "EXEC insertNewPessoa @nome, @email, @foto, @avaliacao, @telefone, @carta_conducao ;";
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









        public void clearVeiculosFields()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

        }



        public Boolean createVeiculo()
        {
            Veiculo veiculo = new Veiculo();
            Motorista currentMotorista = (Motorista)listBox1.SelectedItem;
            String motorista_id = currentMotorista.MotoristaID;

            try
            {
                veiculo.VeiculoMarca = textBox6.Text;
                veiculo.VeiculoModelo = textBox7.Text;
                veiculo.VeiculoCor = textBox8.Text;
                veiculo.VeiculoLugares = textBox9.Text;
                veiculo.VeiculoCapacidadeBateria = textBox10.Text;
                veiculo.VeiculoMatricula = textBox11.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            if (addingVeiculo)
            {
                setVeiculo(getConnection(), veiculo, motorista_id);
                listBox2.Items.Add(veiculo);
            }
            else
            {
                //update motorista
            }

            return true;
        }

        public void setVeiculo(SqlConnection CN, Veiculo veiculo, String motorista_id)
        {
            CN.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC insertVeiculo  @id_motorista, @marca, @modelo, @cor, @lugares, @matricula, @capacidade_bateria ;";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@marca", veiculo.VeiculoMarca);
            cmd.Parameters.AddWithValue("@modelo", veiculo.VeiculoModelo);
            cmd.Parameters.AddWithValue("@cor", veiculo.VeiculoCor);
            cmd.Parameters.AddWithValue("@lugares", veiculo.VeiculoLugares);
            cmd.Parameters.AddWithValue("@matricula", veiculo.VeiculoMatricula);
            cmd.Parameters.AddWithValue("@capacidade_bateria", veiculo.VeiculoCapacidadeBateria);
            cmd.Parameters.AddWithValue("@id_motorista", motorista_id);

            Debug.WriteLine(cmd.ToString());

            cmd.Connection = CN;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message + " " + ex.Source + " " + ex.StackTrace);
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
            finally
            {
                CN.Close();
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            Debug.WriteLine("fora");
            if (listBox1.SelectedIndex >= 0)
            {
                Debug.WriteLine("dentro");
                listBox2.Items.Clear();
                clearVeiculosFields();
                veiculoAddButton.Enabled = true;
                veiculoEditButton.Enabled = true;
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

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentVeiculo = listBox2.SelectedIndex;

                ShowVeiculos();

            }
        }

        private void motoristaOkButton_Click(object sender, EventArgs e)
        {
            try
            {
                createMotorista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            motoristaOkButton.Visible = false;
            motoristaCancelButton.Visible = false;
            clearFields();
            listBox1.Enabled = true;
        }

        private void motoristaAddButton_Click(object sender, EventArgs e)
        {
            clearFields();
            UnlockMotoristaControls();
            motoristaAddButton.Visible = false;
            motoristaEditButton.Visible = false;
            motoristaOkButton.Visible = true;
            motoristaCancelButton.Visible = true;
            listBox1.Enabled = false;
            listBox2.Enabled = false;
            listBox2.Items.Clear();
            adding = true;
        }

        private void motoristaCancelButton_Click(object sender, EventArgs e)
        {
            motoristaOkButton.Visible = false;
            motoristaCancelButton.Visible = false;
            motoristaAddButton.Visible = true;
            motoristaEditButton.Visible=true;


            clearFields();
            LockMotoristaControls();
            listBox1.Enabled = true;
            adding = false;
        }



        private void veiculoOkButton_Click(object sender, EventArgs e)
        {
            try
            {
                createVeiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            veiculoAddButton.Visible = true;
            veiculoCancelButton.Visible = false;
            veiculoOkButton.Visible = false;
            veiculoEditButton.Visible = true;
            clearFields();
            listBox2.Enabled = true;
        }

        private void veiculoAddButton_Click(object sender, EventArgs e)
        {
            clearVeiculosFields();
            UnlockVeiculosControls();
            veiculoAddButton.Visible = false;
            veiculoEditButton.Visible = false;
            veiculoCancelButton.Visible = true;
            veiculoOkButton.Visible = true;
            listBox1.Enabled = false;
            addingVeiculo = true;
        }

        private void veiculoCancelButton_Click(object sender, EventArgs e)
        {
            veiculoAddButton.Visible = true;
            veiculoCancelButton.Visible = false;
            veiculoOkButton.Visible = false;
            veiculoEditButton.Visible = true;


        }

        private void motoristaEditButton_Click(object sender, EventArgs e)
        {

        }
    }
}
