using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionMalade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable chargerData()
        {
            SqlConnection con = new SqlConnection(@"server=LIEVIN-KENA; uid=sa; pwd=20102001; database=Malade;");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tmalade", con);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dt.Fill(ds);
            cmd.Clone();
            return ds.Tables[0];
        }
        void effacer()
        {
            txtid.Text = "";
            txtnom.Text = "";
            txtadresse.Text = "";
            txtdate.Text = "";
            txtetat.Text = "";
            txttaille.Text = "";
            txtpoid.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=LIEVIN-KENA; uid=sa; pwd=20102001; database=Malade;");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into tmalade(noms,adresse,datenaissance,etatcivil,taille,poids) values (@a,@b,@c,@d,@e,@f)", con);
            cmd.Parameters.AddWithValue("@a", txtnom.Text);
            cmd.Parameters.AddWithValue("@b", txtadresse.Text);
            cmd.Parameters.AddWithValue("@c", DateTime.Parse(txtdate.Text));
            cmd.Parameters.AddWithValue("@d", txtetat.Text);
            cmd.Parameters.AddWithValue("@e", txttaille.Text);
            cmd.Parameters.AddWithValue("@f", txtpoid.Text);

            cmd.ExecuteNonQuery();
            cmd.Clone();

            dataGridView1.DataSource = chargerData();
            effacer();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=LIEVIN-KENA; uid=sa; pwd=20102001; database=Malade;");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tmalade SET noms=@a,adresse=@b,datenaissance=@c,etatcivil=@d,taille=@e,poids=@f WHERE id=@g", con);
            cmd.Parameters.AddWithValue("@a", txtnom.Text);
            cmd.Parameters.AddWithValue("@b", txtadresse.Text);
            cmd.Parameters.AddWithValue("@c", DateTime.Parse(txtdate.Text));
            cmd.Parameters.AddWithValue("@d", txtetat.Text);
            cmd.Parameters.AddWithValue("@e", float.Parse(txttaille.Text));
            cmd.Parameters.AddWithValue("@f", float.Parse(txtpoid.Text));
            cmd.Parameters.AddWithValue("@g", int.Parse(txtid.Text));

            cmd.ExecuteNonQuery();
            cmd.Clone();
            dataGridView1.DataSource = chargerData();
            effacer();
        }

        


        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=LIEVIN-KENA; uid=sa; pwd=20102001; database=Malade;");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM tmalade WHERE id=@a", con);
            cmd.Parameters.AddWithValue("@a", int.Parse(txtid.Text));
            cmd.ExecuteNonQuery();
            cmd.Clone();
            dataGridView1.DataSource = chargerData();
            effacer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = chargerData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtid.Text = dataGridView1["id", i].Value.ToString();
            txtnom.Text = dataGridView1["noms",i].Value.ToString();
            txtadresse.Text = dataGridView1["adresse",i].Value.ToString();
            txtdate.Text = dataGridView1["datenaissance", i].Value.ToString();
            txtetat.Text = dataGridView1["etatcivil", i].Value.ToString();
            txttaille.Text = dataGridView1["taille",i].Value.ToString();
            txtpoid.Text = dataGridView1["poids", i].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
