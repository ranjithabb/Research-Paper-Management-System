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
using System.IO;


namespace rpms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\ds1\rpms\bin\Debug\research.accdb;Persist Security Info=False;";
             
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 open = new Form1();
            open.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\ds1\rpms\bin\Debug\research.accdb;Persist Security Info=False;";
            connect.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            command.CommandText = "insert into t1 (Title,Author,yr,Publisher,University,pdf) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')";

           
            command.ExecuteNonQuery();
            MessageBox.Show("record inserted");
            //textbox clear
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox8.Text = " ";
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PDF|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = ofd.SafeFileName;
                textBox8.Text = ofd.FileName;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
