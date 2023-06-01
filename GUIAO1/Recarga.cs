using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUIAO1
{
    public partial class Recarga : Form
    {
        private int currentRecarga;
        private int currentDescanso;
        public Recarga()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection CN = getConnection();
            List<PontoRecarga> recargas = new List<PontoRecarga>();
            recargas = getPontoRecargasContent(CN);

            foreach (PontoRecarga p in recargas)
            {
                listBox1.Items.Add(p);
            }

        }

        private List<PontoRecarga> getPontoRecargasContent(SqlConnection CN)
        {
            List<PontoRecarga> recargaList = new List<PontoRecarga>();
            try
            {
                CN.Open();

                if (CN.State == ConnectionState.Open)
                {

                    string query = "SELECT * FROM Ponto_Recarga";
                    SqlCommand sqlcmd = new SqlCommand(query, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        PontoRecarga R = new PontoRecarga();

                        R.RecargaID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        R.RecargaEmpresa = reader.GetString(reader.GetOrdinal("empresa"));
                        R.RecargaCapacidade = reader.GetInt32(reader.GetOrdinal("capacidade")).ToString();
                        if (reader.GetBoolean(reader.GetOrdinal("disponibilidade")) == true)
                        {
                            R.RecargaDisponibilidade = "Disponível";
                        }
                        else
                        {
                            R.RecargaDisponibilidade = "Indisponível";
                        }
                        R.RecargaMorada = reader.GetString(reader.GetOrdinal("morada"));

                        recargaList.Add(R);



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return recargaList;
        }

        private List<PontoDescanso> getPontoDescansoContent(SqlConnection CN, String id)
        {
            List<PontoDescanso> descansoList = new List<PontoDescanso>();
            try
            {
                CN.Open();

                if (CN.State == ConnectionState.Open)
                {

                    string query = "EXEC sp_PontosDescanso " + id;
                    SqlCommand sqlcmd = new SqlCommand(query, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        PontoDescanso D = new PontoDescanso();

                        D.DescansoID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        D.DescansoNome = reader.GetString(reader.GetOrdinal("nome"));
                        D.DescansoAvaliacao = reader.GetDouble(reader.GetOrdinal("avaliacao")).ToString();

                        descansoList.Add(D);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return descansoList;
        }

        private List<Comodidade> getComodidadesContent(SqlConnection CN, String id)
        {
            List<Comodidade> comodidadeList = new List<Comodidade>();
            try
            {
                CN.Open();

                if (CN.State == ConnectionState.Open)
                {

                    string query = "EXEC sp_GetComodidades " + id;
                    SqlCommand sqlcmd = new SqlCommand(query, CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Comodidade C = new Comodidade();

                        C.ComodidadeID = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                        C.ComodidadeTipo = reader.GetString(reader.GetOrdinal("tipo"));


                        comodidadeList.Add(C);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return comodidadeList;
        }

        private SqlConnection getConnection()
        {
            SqlConnection CN = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p10g2" +
                                                       "; uid = " + "p10g2" + ";" + "password = " + "@Osmarfrango1");

            return CN;
        }

        public void ShowRecargas()
        {
            if (listBox1.Items.Count == 0 | currentRecarga < 0)
                return;
            PontoRecarga recarga = new PontoRecarga();
            recarga = (PontoRecarga)listBox1.SelectedItem;

            textBox1.Text = recarga.RecargaEmpresa;
            textBox2.Text = recarga.RecargaCapacidade;
            textBox3.Text = recarga.RecargaDisponibilidade;
            textBox4.Text = recarga.RecargaMorada;


        }

        public void ShowDescansos()
        {
            if (listBox1.Items.Count == 0 | currentDescanso < 0)
                return;
            PontoDescanso descanso = new PontoDescanso();
            descanso = (PontoDescanso)listBox2.SelectedItem;

            textBox5.Text = descanso.DescansoAvaliacao;
            textBox6.Text = descanso.DescansoNome;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                currentRecarga = listBox1.SelectedIndex;
                ShowRecargas();
                PontoRecarga r = new PontoRecarga();
                r = (PontoRecarga)listBox1.SelectedItem;
                SqlConnection CN = getConnection();
                List<PontoDescanso> descansos = new List<PontoDescanso>();


                descansos = getPontoDescansoContent(CN, r.RecargaID);

                foreach (PontoDescanso des in descansos)
                {
                    listBox2.Items.Add(des);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentDescanso = listBox2.SelectedIndex;
                ShowDescansos();

                PontoDescanso d = new PontoDescanso();
                d = (PontoDescanso)listBox2.SelectedItem;
                SqlConnection CN = getConnection();
                List<Comodidade> comodidades = new List<Comodidade>();

                comodidades = getComodidadesContent(CN, d.DescansoID);

                foreach (Comodidade c in comodidades)
                {
                    listBox3.Items.Add(c);
                }


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
