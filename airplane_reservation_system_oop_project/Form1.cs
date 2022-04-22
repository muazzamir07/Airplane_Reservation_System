using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace airplane_reservation_system_oop_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-7BAP8EK;Initial Catalog=ticketreservation;Integrated Security=True");
            con.Open();
            MessageBox.Show("congularation databASE connected");

            display();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            SqlCommand cmd = new SqlCommand("insert into passanger_list(p_no,p_cnic,passanger_name,p_father_name,from_city,to_city,date_of_departure,date_of_arrivial,ticket_class)VALUES(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data entered sucessfully");
            display();
            
        }

        public void display()
        {

            SqlCommand cmd = new SqlCommand("select * from passanger_list", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("delete from passanger_list where p_no="+textBox1.Text+" ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data deleted sucessfully");
            display();
          
 
        }

        private void button2_Click(object sender, EventArgs e)                                                                                                                                    
        {

            SqlCommand cmd = new SqlCommand(" update passanger_list  set p_no ='"+textBox1.Text+"' where  p_no='"+textBox1.Text+"' " , con);
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("data updated sucessfully");
            

            
            textBox10.Clear();
            display();

            //int p_no = Convert.ToInt32(textBox1.Text);
            //int p_cnic = Convert.ToInt32(textBox2.Text);
            //int p_name = Convert.ToInt32(textBox3.Text);
            //int p_father_name = Convert.ToInt32(textBox4.Text);
            //int from_city = Convert.ToInt32(textBox5.Text);
            //int to_city = Convert.ToInt32(textBox6.Text);
            //int  date_of_departure  = Convert.ToInt32(textBox7.Text);
            //int date_of_arrivial = Convert.ToInt32(textBox8.Text);
            //int ticket_class = Convert.ToInt32(textBox9.Text);
            //string query = "update passanger_list set p_no=" + p_no + ",p_cnic =" + p_cnic + ",p_name =" + p_name + ", p_father_name=" + p_father_name + ",from_city=" + from_city + ",to_city =" + to_city + ",date_of_departure=" + date_of_departure + ",date_of_arrivial=" + date_of_arrivial + ", ticket_class=" + ticket_class + "";
            //SqlCommand cmd = new SqlCommand(query,con);

            //int a = cmd.ExecuteNonQuery();
            //con.Close();
            //if (a > 0)
            //{
            //    
            //}
            //else 
            //{
            //    MessageBox.Show("data doesnot updated ");
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("your ticket has been booked");
            con.Close();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select * from passanger_list where p_cnic='"+textBox11.Text+"'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            textBox11.Text = " ";
            

        }
         

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            DataGridViewRow Rows = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = Rows.Cells[0].Value.ToString();
            textBox2.Text = Rows.Cells[1].Value.ToString();
            textBox3.Text = Rows.Cells[2].Value.ToString();
            textBox4.Text = Rows.Cells[3].Value.ToString();
            textBox5.Text = Rows.Cells[4].Value.ToString();
            textBox6.Text = Rows.Cells[5].Value.ToString();
            textBox7.Text = Rows.Cells[6].Value.ToString();
            textBox8.Text = Rows.Cells[7].Value.ToString();
            textBox9.Text = Rows.Cells[8].Value.ToString();


            
            
        }

        

        
    }
}
