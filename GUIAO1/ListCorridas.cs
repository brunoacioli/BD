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
    public partial class ListCorridas : Form
    {
        public List<Corrida> corridasList;
        public List<Motorista> motoristasList;
        public String client_id;
        Corrida corrida;
        private int corridaIndex;
        Motorista motorista;
        private bool adding;
        
        public ListCorridas()
        {
            InitializeComponent();
        }

        public ListCorridas(List<Corrida> corridasList, String client_id) {
            this.client_id = client_id;
            this.corridasList = corridasList;
            this.motoristasList = getMotoristasContent();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Visible = false;
            button5.Visible = false;
            comboBox1.Enabled = false;
            if (listBox1.SelectedIndex >= 0)
            {
                corridaIndex = listBox1.SelectedIndex;
                Corrida aux = corridasList[corridaIndex];
                foreach(Motorista auxMotorista in motoristasList) {
                    if(aux.id_motorista == auxMotorista.MotoristaID)
                    {
                        comboBox1.SelectedItem = auxMotorista;
                    }
                }
                
                showCorridas();
                if (aux.pagamento == null)
                {
                    button1.Visible = true;
                } else
                {
                    button1.Visible = false;
                }

            }
        }

        private void ListCorridas_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void showCorridas() {
            if (listBox1.Items.Count == 0 | corridaIndex < 0)
                return;
            corrida = (Corrida)listBox1.SelectedItem;
            textBox1.Text = corrida.partida;
            textBox2.Text = corrida.destino;
            textBox3.Text = corrida.pagamento;
            textBox5.Text = corrida.duracao;
            textBox4.Text = corrida.gorjeta;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearFields();
            listBox1.Enabled = false;
            comboBox1.Enabled = true;
            adding = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");
            Debug.WriteLine("###########");
            Debug.WriteLine(textBox4.Text.ToString());
            Debug.WriteLine("!!!!!!!!!!!!!1  " + corrida.id);
            terminarCorrida(CN, corrida.id , "'corrida finalizada'" , textBox4.Text.ToString());
            corridasList = getCorridasByClientId(CN, client_id);
            loadData();
            button2.Visible = true;

        }

        public void terminarCorrida(SqlConnection CN, String id, String status, String gorjeta)
        {
            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    SqlCommand sqlcmd = new SqlCommand("Update Corridas set [status] = " + status + ", gorjeta = " + gorjeta + " WHERE id = " + id, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
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

        public void clearFields() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedItem = "";
            comboBox1.Text = ""; 
            button3.Visible = true;
            button5.Visible = true;
            button2.Visible = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                createCorrida();
                corridasList = getCorridasByClientId(getConnection(), client_id);
                loadData();
                listBox1.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button5.Visible = false;
            button2.Visible = true;
            listBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            motorista = (Motorista)comboBox1.SelectedItem;
            Debug.WriteLine(motorista.MotoristaID);
        }


        private List<Motorista> getMotoristasContent()
        {
            SqlConnection CN = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");
            List<Motorista> motoraList = new List<Motorista>();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {

                    SqlCommand sqlcmd = new SqlCommand("EXEC listMotoristas", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Motorista M = new Motorista();
                        M.MotoristaID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        M.MotoristaNome = reader.GetString(reader.GetOrdinal("nome"));
                        M.MotoristaEmail = reader.GetString(reader.GetOrdinal("email"));
                        M.MotoristaFoto = reader.GetString(reader.GetOrdinal("foto"));
                        M.MotoristaAvaliacao = reader.GetDouble(reader.GetOrdinal("avaliacao")).ToString();
                        M.MotoristaTelefone = reader.GetInt32(reader.GetOrdinal("telefone")).ToString();
                        M.MotoristaCartaConducao = reader.GetString(reader.GetOrdinal("carta_conducao"));
                        motoraList.Add(M);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
            return motoraList;
        }

        public void loadData()
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            button3.Visible = false;
            button5.Visible = false;
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            
            Debug.WriteLine("Entreeeeeeeeeei");
            foreach (Corrida c in corridasList)
            {
                listBox1.Items.Add(c);
                Debug.WriteLine("#######");
                Debug.WriteLine(c);
                Debug.WriteLine(corridasList.Count);
                Debug.WriteLine(c.id);
            }

            foreach (Motorista m in motoristasList)
            {
                comboBox1.Items.Add(m);
            }
        }

        public bool createCorrida()
        {
            Debug.WriteLine("Olaaaaaaaaaaaaaaaaaa marcooooo");
            Corrida corrida = new Corrida();
            try
            {
                corrida.partida = textBox1.Text;
                corrida.destino = textBox2.Text;
                corrida.id_cliente = client_id;
                corrida.id_motorista = motorista.MotoristaID;
                corrida.status = "Corrida inicializada";
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
            if(adding)
            {
                setCorrida(getConnection(), corrida);
            }

            return true;
        }

        public void setCorrida(SqlConnection cn, Corrida corrida)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            Debug.WriteLine(corrida.partida);
            Debug.WriteLine(corrida.destino);
            Debug.WriteLine(corrida.id_cliente);
            Debug.WriteLine(corrida.id_motorista);
            Debug.WriteLine(corrida.status);
            cmd.CommandText = "INSERT Corridas(partida, destino, id_cliente, id_motorista, [status]) VALUES(@partida, @destino ,@id_cliente, @id_motorista, @status);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@partida", corrida.partida);
            cmd.Parameters.AddWithValue("@destino", corrida.destino);
            cmd.Parameters.AddWithValue("@id_cliente", corrida.id_cliente);
            cmd.Parameters.AddWithValue("@id_motorista", corrida.id_motorista);
            cmd.Parameters.AddWithValue("@status", corrida.status);
            cmd.Connection = cn;

            try {
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally {
                cn.Close();
            }
        }

        public SqlConnection getConnection() {
            return new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
