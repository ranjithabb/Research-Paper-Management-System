using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
namespace rpms
{
    public partial class Form6 : Form
    {
        public static OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\ds1\rpms\bin\Debug\research.accdb");

        
        public Form6()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  linkLabel1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con1.Open();
            DataTable dt6 = new DataTable();
            OleDbDataAdapter ODA = new OleDbDataAdapter("SELECT * FROM t1 WHERE " + "Title LIKE '%" + textBox1.Text + "%'", con1);
            ODA.Fill(dt6);
            dataGridView1.DataSource = dt6;
            con1.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 open = new Form1();
            open.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
       /*  Form1 frm1=new Form1(textBox2.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
         Form1 frm2=new Form1(textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
         Form1 frm3=new Form1(textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
         Form1 frm4=new Form1(textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
         Form1 frm5=new Form1(textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
         Form1 frm6=new Form1(textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString());*/
            
        }
    }
}
