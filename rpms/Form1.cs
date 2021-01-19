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
    public partial class Form1 : Form
    {
        public static OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\ds1\rpms\bin\Debug\research.accdb");
        Class1 db = new Class1();

        public Form1(/*string value*/)
        {
            InitializeComponent();
        }
        
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
           
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("author", "Author's");
            dataGridView1.Columns.Add("yr", "years");
            dataGridView1.Columns.Add("publisher", "Publisher");
            dataGridView1.Columns.Add("university", "University");
            
           DataGridViewLinkColumn Field2 = new DataGridViewLinkColumn();
            dataGridView1.Columns.Add(Field2);
            Field2.HeaderText = "PDF";
            Field2.Name = "../../Downloads/rp1.pdf";
            Field2.Text = "PDF view";
            Field2.UseColumnTextForLinkValue = true;


            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\ds1\rpms\bin\Debug\research.accdb;Persist Security Info=False;";
            connect.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            command.CommandText = "SELECT * FROM t1";
           
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                dataGridView1.Rows.Add();
              
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["title"].Value = reader[1].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["author"].Value = reader[2].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["yr"].Value = reader[3].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["publisher"].Value = reader[4].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["university"].Value = reader[5].ToString();
            }
            connect.Close();
            con1.Open();
            OleDbCommand cmd = con1.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from t1";
            cmd.ExecuteNonQuery();
            DataTable  dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["university"].ToString());
            }
            con1.Close();
           
            con1.Open();
            OleDbCommand cmd1 = con1.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from t1";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                comboBox2.Items.Add(dr1["author"].ToString());
            }
            con1.Close();
            con1.Open();
            OleDbCommand cmd2 = con1.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from t1";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                comboBox3.Items.Add(dr2["publisher"].ToString());
            }
            con1.Close();
           }
        
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            button1.Text = trackBar1.Value.ToString();
		}
		
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
             textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
             pdf.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            OleDbCommand cmd1 = con1.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from t1 where author='" + comboBox2.SelectedItem.ToString() + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            da1.Fill(dt3);
            foreach (DataRow dr1 in dt3.Rows)
            {
                textBox5.Text = dr1["university"].ToString();
                textBox1.Text = dr1["title"].ToString();
                textBox2.Text = dr1["author"].ToString();
                textBox3.Text = dr1["yr"].ToString();
                textBox4.Text = dr1["publisher"].ToString();
                pdf.Text = dr1["PDF"].ToString();
            }
            con1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            OleDbCommand cmd2 = con1.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from t1 where publisher='" + comboBox3.SelectedItem.ToString() + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt4 = new DataTable();
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            da2.Fill(dt4);
            foreach (DataRow dr2 in dt4.Rows)
            {
                textBox5.Text = dr2["university"].ToString();
                textBox1.Text = dr2["title"].ToString();
                textBox2.Text = dr2["author"].ToString();
                textBox3.Text = dr2["yr"].ToString();
                textBox4.Text = dr2["publisher"].ToString();
                pdf.Text = dr2["PDF"].ToString();
            }
            con1.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }
 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            OleDbCommand cmd = con1.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from t1 where university='"+comboBox1.SelectedItem.ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt5 = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt5);
            foreach (DataRow dr in dt5.Rows)
            {
                textBox5.Text=dr["university"].ToString();
                textBox1.Text = dr["title"].ToString();
                textBox2.Text = dr["author"].ToString(); 
                textBox3.Text = dr["yr"].ToString();
                textBox4.Text = dr["publisher"].ToString();
                pdf.Text = dr["PDF"].ToString();
            }
            con1.Close();
        }

       
        private void pdf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("C:\\Users\\User\\Documents\\Visual Studio 2012\\Projects\\rpms\\pdfs\\rp1.pdf");
           
        }

      
        private void eXITToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 add = new Form3();
            add.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dECSENDINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);

        }

        private void aSCENDINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 ff = new Form5();
            ff.ShowDialog();
        }

         
        private void sEARCHONKEYWORDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 ff = new Form6();
            ff.ShowDialog();
        }

        
    }
}
