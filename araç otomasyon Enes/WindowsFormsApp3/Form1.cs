using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GNKKFD3;Initial Catalog=araclar;Integrated Security=True;Encrypt=False");
        SqlCommand komut;
        SqlDataAdapter adapter;
        DataTable Table;

        void BilgiGetir(int a)
        {
            switch (a)
            {
                case 1: komut = new SqlCommand("   EXEC aractablo ", baglanti); break;
                case 2: komut = new SqlCommand("EXEC otomatik ", baglanti); break;
                case 3: komut = new SqlCommand("EXEC  manuel", baglanti); break;
                case 4: komut = new SqlCommand("EXEC satılık", baglanti); break;
                case 5: komut = new SqlCommand("EXEC  kiralık", baglanti); break;
                case 6:
                    if (!string.IsNullOrEmpty(textBox3.Text))
                    {

                        komut = new SqlCommand(string.Format("EXEC arama @uretim={0}", textBox3.Text), baglanti);
                    }
                    else
                    {
                        DialogResult rs = MessageBox.Show("lütfen deger girin", "hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (rs == DialogResult.No)
                        {
                            MessageBox.Show("lütfen deger girin !!!", "HATA  !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            } 
          
            baglanti.Open(); 
            komut.ExecuteNonQuery();
            adapter = new SqlDataAdapter(komut);
            Table = new DataTable();
            adapter.Fill(Table);
            dataGridView1.DataSource = Table;
            baglanti.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BilgiGetir(1);
            komut = new SqlCommand("select * from marka", baglanti);
            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();


            while (reader.Read())
            {
                comboBox1.Items.Add(reader["marka"].ToString());
            }
            baglanti.Close();
            reader.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vites = null;
            string envanter = null;
            if (radioButton1.Checked)
            {
                vites = "otomatik";
            }
            else if (radioButton2.Checked)
            {
                vites = "manuel";
            }
            if (checkBox2.Checked)
            {
                envanter = "satılık";
            }
            if (checkBox1.Checked)
            {
                envanter = "kiralık";
            }
            komut = new SqlCommand(string.Format("select model_id from modeller where model='{0}' " ,comboBox2.Text), baglanti);
            baglanti.Open();
            string modelıd=komut.ExecuteScalar().ToString();
            baglanti.Close();
            komut = new SqlCommand(string.Format("  insert into araclar(marka,model,uretım_yılı,vites_tipi,envanter_tipi)values('{0}','{1}','{2}','{3}','{4}')", comboBox1.SelectedIndex + 1, modelıd, textBox1.Text, vites, envanter), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery(); baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand(string.Format(" delete from araclar where arac_seri={0}", textBox2.Text), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            BilgiGetir(1);
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vites = null;
            string envanter = null;
            if (radioButton1.Checked)
            {
                vites = "otomatik";
            }
            else if (radioButton2.Checked)
            {
                vites = "manual";
            }
            if (checkBox2.Checked)
            {
                envanter = "satılık";
            }
            if (checkBox1.Checked)
            {
                envanter = "kiralık";
            }
            komut = new SqlCommand(string.Format("select model_id from modeller where model='{0}' ", comboBox2.Text), baglanti);
            baglanti.Open();
            string modelıd = komut.ExecuteScalar().ToString();
            baglanti.Close();
            komut = new SqlCommand(string.Format("update araclar set marka='{0}',model='{1}',uretım_yılı='{2}',vites_tipi='{3}',envanter_tipi='{4}' where arac_seri={5}", comboBox1.SelectedIndex+1, modelıd, textBox1.Text, vites, envanter, textBox2.Text), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            BilgiGetir(1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            BilgiGetir(6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BilgiGetir(1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BilgiGetir(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BilgiGetir(2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BilgiGetir(3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BilgiGetir(5);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            komut = new SqlCommand(string.Format("select * from modeller where marka_id={0} ", comboBox1.SelectedIndex + 1), baglanti);
            baglanti.Open();
            SqlDataReader reader2 = komut.ExecuteReader();


            while (reader2.Read())
            {
                comboBox2.Items.Add(reader2["model"].ToString());
            }
            baglanti.Close();
            reader2.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string vites = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string envanter = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (vites == "otomatik")
                radioButton1.Checked = true;
            else if (vites == "manuel")
                radioButton2.Checked = true;
            if (envanter == "satılık")
                checkBox2.Checked = true;
            else if (envanter == "kiralık")
                checkBox1.Checked = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
