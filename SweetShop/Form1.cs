using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace SweetShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Connection b = new Connection();

        class Connection
        {

            OleDbConnection connection;
            OleDbCommand command;
            private void ConnectTo()
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.4.0; Data Source= C:\\Users\\nvm\\Documents\\Sweets.mdb");
                command = connection.CreateCommand();
            }

            public Connection()
            {
                ConnectTo();
            }

            public void Insert(AssortSweets s)
            {
                try
                {
                    command.CommandText = "INSERT INTO AssortSweets(ID_Assort, Name_Sweet, ID_Group, Recipe, Weigth, PricePerSweet) VALUES("
                    + "'" + s.ID_Assort + "'" + ", " + "'" + s.Name_Sweet + "'" + ", " + s.ID_Group + ", " + "'" + s.Recipe + "'"+ ", " + s.Weight + ", " + s.PricePerSweet + ")";
                    command.CommandType = CommandType.Text;
                    // command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново!");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                }

            }

            public void Insert(Order o)
            {
                try
                {
                    command.CommandText = "INSERT INTO Order(ID_Order, DateOfDelivery, ID_Assort, Addons, PricePerSweet, AmountOfSweets) VALUES("
                     + o.ID_Order + ", TO_DATE( " + "'" + o.DateOfDelivery + "'" + ", 'YYYY-MM-DD')" /*Might need to change the date format later*/ + ", " + "'" + o.ID_Assort + "'" 
                     + ", " + o.Addons /*Needs work; making sure it will be always 0 or 1*/ + ", " + o.PricePerSweet + ", " + o.AmountOfSweets + ")";
                    command.CommandType = CommandType.Text;
                    // command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                }

                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново!");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                }

            }

            public void Insert(GroupOfSweets g)
            {
                try
                {
                    command.CommandText = "INSERT INTO AssortSweets(ID_Group, Name_Group);VALUES("
                     + g.ID_Group + ", " + "'" + g.Name_Group + "'" + ")";
                    command.CommandType = CommandType.Text;
                    // command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново!");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e) //AssortSweets
        {
            AssortSweets s = new AssortSweets();
            s.ID_Assort = textBox1.Text;
            s.Name_Sweet = textBox2.Text;
            s.ID_Group = int.Parse(textBox3.Text);
            s.Recipe = textBox4.Text;
            s.Weight = textBox5.Text;
            s.Name_Sweet = textBox2.Text;
            s.PricePerSweet = double.Parse(textBox3.Text);
            b.Insert(s);

        }

        private void button2_Click(object sender, EventArgs e) //Orders
        {
            Order o = new Order();
            o.ID_Order = textBox12.Text;
            o.DateOfDelivery= DateTime.Parse(dateTimePicker1.Text);
            o.ID_Order = textBox10.Text;
            o.Addons =  checkBox1.Checked;
            o.PricePerSweet = double.Parse(textBox8.Text);
            o.AmountOfSweets = int.Parse(textBox7.Text);
            b.Insert(o);

        }

        private void button3_Click(object sender, EventArgs e) //GroupOfSweets
        {
            GroupOfSweets g = new GroupOfSweets();
            g.ID_Group = int.Parse(textBox18.Text);
            g.Name_Group = textBox13.Text;
            b.Insert(g);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
        
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void label17_Click(object sender, EventArgs e)
        {

        }
        
        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

       
    }
}
