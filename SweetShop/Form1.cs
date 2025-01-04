using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= C:\\Users\\nvm\\Documents\\Sweets.mdb");
                //connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.4.0; Data Source= *add your path to the database* );
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
                   // command.CommandText = "INSERT INTO AssortSweets(ID_Assort, Name_Sweet, ID_Group, Recipe, Weight, PricePerSwet) VALUES("
                    // + "'" + s.ID_Assort + "'" + ", " + "'" + s.Name_Sweet + "'" + ", " + s.ID_Group + ", " + "'" + s.Recipe + "'"+ ", " + s.Weight + ", " + s.PricePerSweet + ");";

                    command.CommandText = "INSERT INTO AssortSweets(ID_Assort, Name_Sweet, ID_Group, Recipe, Weight, PricePerSwet) " +
                        "VALUES(@ID_Assort, @Name_Sweet, @ID_Group, @Recipe, @Weight, @PricePerSwet );";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_Assort", s.ID_Assort);
                    command.Parameters.AddWithValue("@Name_Sweet", s.Name_Sweet);
                    command.Parameters.AddWithValue("@ID_Group", s.ID_Group);
                    command.Parameters.AddWithValue("@Recipe", s.Recipe);
                    command.Parameters.AddWithValue("@Weight", s.Weight);
                    command.Parameters.AddWithValue("@PricePerSwet", s.PricePerSwet);


                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Row " + s.Name_Sweet + " added to the table");

                }


                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново! ");
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
                    //command.CommandText = "INSERT INTO Order(ID_Order, DateOfDelivery, ID_Assort, Addons, PricePerSweet, AmountOfSweets) VALUES("
                    //  + o.ID_Order + ", TO_DATE( " + "'" + o.DateOfDelivery + "'" + ", 'YYYY-MM-DD')" /*Might need to change the date format later*/ + ", " + "'" + o.ID_Assort + "'" 
                    // + ", " + o.Addons /*Needs work; making sure it will be always 0 or 1*/ + ", " + o.PricePerSweet + ", " + o.AmountOfSweets + ");"; 

                    command.CommandText = "INSERT INTO Order(ID_Order, DateOfDelivery, ID_Assort, Addon, PricePerSweet, AmountOfSweets) " +
                    "VALUES(@ID_Order, @DateOfDelivery, @ID_Assort, @Addon, @PricePerSweet, @AmountOfSweets);";

                   // command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_Order", o.ID_Order);
                    command.Parameters.AddWithValue("@DateOfDelivery", o.DateOfDelivery);
                    command.Parameters.AddWithValue("@ID_Assort", o.ID_Assort);
                    command.Parameters.AddWithValue("@Addon", o.Addon);
                    command.Parameters.AddWithValue("@PricePerSweet", o.PricePerSweet);
                    command.Parameters.AddWithValue("@AmountOfSweets", o.AmountOfSweets);

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Row " + o.ID_Order + " added to the table");

                }

                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново!" + o.Addon + " , " + o.DateOfDelivery);
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
                    //command.CommandText = "INSERT INTO GroupOfSweets(ID_Group, Name_Group); VALUES("
                    // + g.ID_Group + ", " + "'" + g.Name_Group + "' " + ");";
                    command.CommandText = "INSERT INTO GroupOfSweets(ID_Group, Name_Group) VALUES( @ID_Group, @Name_Group);";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_Group", g.ID_Group);
                    command.Parameters.AddWithValue("@Name_Group", g.Name_Group);

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Row " + g.Name_Group + " added to the table");

                }

                catch (Exception)
                {
                    MessageBox.Show("Некоректни данни! Моля въведете отново! ");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                }

            }

            public void UpdateAssortSweets(string idAssort, string nameSweet, int idGroup, string recipe, double weight, double pricePerSweet)
            {
                string query = @"
                UPDATE AssortSweets
                SET Name_Sweet = @Name_Sweet, 
                    ID_Group = @ID_Group, 
                    Recipe = @Recipe, 
                    Weight = @Weight, 
                    PricePerSwet = @PricePerSweet
                WHERE ID_Assort = @ID_Assort";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name_Sweet", nameSweet);
                    command.Parameters.AddWithValue("@ID_Group", idGroup);
                    command.Parameters.AddWithValue("@Recipe", recipe);
                    command.Parameters.AddWithValue("@Weight", weight);
                    command.Parameters.AddWithValue("@PricePerSweet", pricePerSweet);
                    command.Parameters.AddWithValue("@ID_Assort", idAssort);

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "AssortSweets updated successfully." : "No records updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating AssortSweets: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            public void UpdateGroupOfSweets(int idGroup, string nameGroup)
            {
                string query = @"
                UPDATE GroupOfSweets
                SET Name_Group = @Name_Group
                WHERE ID_Group = @ID_Group";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name_Group", nameGroup);
                    command.Parameters.AddWithValue("@ID_Group", idGroup);

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "GroupOfSweets updated successfully." : "No records updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating GroupOfSweets: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            public void UpdateOrder(string idOrder, DateTime dateOfDelivery, string idAssort, int addon, double pricePerSweet, int amountOfSweets)
            {
                string query = @"
                UPDATE [Order]
                SET DateOfDelivery = @DateOfDelivery, 
                    ID_Assort = @ID_Assort, 
                    Addon = @Addon, 
                    PricePerSweet = @PricePerSweet, 
                    AmountOfSweets = @AmountOfSweets
                WHERE ID_Order = @ID_Order";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@DateOfDelivery", dateOfDelivery);
                    command.Parameters.AddWithValue("@ID_Assort", idAssort);
                    command.Parameters.AddWithValue("@Addon", addon);
                    command.Parameters.AddWithValue("@PricePerSweet", pricePerSweet);
                    command.Parameters.AddWithValue("@AmountOfSweets", amountOfSweets);
                    command.Parameters.AddWithValue("@ID_Order", idOrder);

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Order updated successfully." : "No records updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating Order: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            public void DeleteAssort(string idAssortToDelet) 
            {
                string myDelete = "DELETE FROM AssortSweets WHERE ID_Assort=" +"'" + idAssortToDelet + "'";
                connection.Open();
                command.CommandText = myDelete;
                command.Connection = connection;
                command.ExecuteNonQuery();
                MessageBox.Show("Record Delete", "Congrats");
                connection.Close();
            }
            
            public void DeleteGroup(string groupToDelete)
            {
                string myDelete = "DELETE FROM GroupOfSweets WHERE Name_Group=" + "'" + groupToDelete + "'";
                connection.Open();
                command.CommandText = myDelete;
                command.Connection = connection;
                command.ExecuteNonQuery();
                MessageBox.Show("Record Delete", "Congrats");
                connection.Close();
            }

            public void DeleteOrder(string idOrderToDelete) 
            {
                string myDelete = "DELETE FROM Order WHERE ID_Order=" + idOrderToDelete;
                connection.Open();
                command.CommandText = myDelete;
                command.Connection = connection;
                command.ExecuteNonQuery();
                MessageBox.Show("Record Delete", "Congrats");
                connection.Close();
            }

            public string GetOrder(DateTime dateOfDelivery)
            {
                string myGet = "SELECT FROM Order WHERE DateOfDelivery=" + dateOfDelivery;
                connection.Open();
                command.CommandText = myGet;
                command.Connection = connection;
                var reader = command.ExecuteReader();
                string result = string.Empty;
                while (reader.Read())
                {
                    while (reader.Read())
                    {
                        string ID_Order = reader.GetValue(0).ToString();
                        string DateOfDelivery = reader.GetString(1);
                        string ID_Assort = reader.GetString(2);
                        string Addons = reader.GetString(3);
                        string PricePerSweet = reader.GetString(4);
                        string AmountOfSweet = reader.GetString(5);
                        result += ID_Order + " " + DateOfDelivery + " " + ID_Assort + " " + ID_Assort + " " + Addons + " " + PricePerSweet + " "+ AmountOfSweet + "/n ";
                    }

                }
                connection.Close();
                return result;
            }

            public string GetEarningsByAssort(string idAssort)
            {
                string query = @"
                SELECT SUM(PricePerSweet * AmountOfSweets) AS TotalEarnings
                FROM [Order]
                WHERE ID_Assort = @ID_Assort";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_Assort", idAssort);

                    var result = command.ExecuteScalar();
                    return result != null ? $"Total earnings for Assort ID {idAssort}: {result} BGN" : "No data found.";
                }
                catch (Exception ex)
                {
                    return "Error calculating earnings: " + ex.Message;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            public string GetEarningsByGroup(string groupName)
            {
                string query = @"
                SELECT SUM(o.PricePerSweet * o.AmountOfSweets) AS TotalEarnings
                FROM [Order] o
                INNER JOIN AssortSweets a ON o.ID_Assort = a.ID_Assort
                INNER JOIN GroupOfSweets g ON a.ID_Group = g.ID_Group
                WHERE g.Name_Group = @GroupName";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    var result = command.ExecuteScalar();
                    return result != null ? $"Total earnings for Group {groupName}: {result} BGN" : "No data found.";
                }
                catch (Exception ex)
                {
                    return "Error calculating earnings: " + ex.Message;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            public string GetEarningsByOrder(string orderId)
            {
                string query = @"
                SELECT SUM(PricePerSweet * AmountOfSweets) AS TotalEarnings
                FROM [Order]
                WHERE ID_Order = @OrderID";

                try
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@OrderID", orderId);

                    var result = command.ExecuteScalar();
                    return result != null ? $"Total earnings for Order ID {orderId}: {result} BGN" : "No data found.";
                }
                catch (Exception ex)
                {
                    return "Error calculating earnings: " + ex.Message;
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
            s.Weight = double.Parse(textBox5.Text);
            s.Name_Sweet = textBox2.Text;
            s.PricePerSwet = double.Parse(textBox6.Text);
            b.Insert(s);

        }

        private void button2_Click(object sender, EventArgs e) //Orders
        {
            Order o = new Order();
            o.ID_Order = textBox12.Text;
            o.DateOfDelivery= DateTime.Parse(dateTimePicker1.Text);
            o.ID_Assort = textBox10.Text;
            o.AddonConv =  checkBox1.Checked;
            if (o.AddonConv == true)
            {
                o.Addon = 1;
            }

            else if (o.AddonConv == false)
            {
                o.Addon = 0;
            }
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

        private void button10_Click(object sender, EventArgs e)
        {
            string idAssort = textBox17.Text;
            if (!string.IsNullOrEmpty(idAssort))
            {
                MessageBox.Show(b.GetEarningsByAssort(idAssort));
            }
            else
            {
                MessageBox.Show("Please enter a valid Assort ID.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string groupName = textBox16.Text;
            if (!string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show(b.GetEarningsByGroup(groupName));
            }
            else
            {
                MessageBox.Show("Please enter a valid Group Name.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string orderId = textBox11.Text;
            if (!string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show(b.GetEarningsByOrder(orderId));
            }
            else
            {
                MessageBox.Show("Please enter a valid Order ID.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idAssortToDelet = textBox9.Text;

            b.DeleteAssort(idAssortToDelet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string groupToDelete = textBox14.Text;
            b.DeleteGroup(groupToDelete);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string idorderToDelete = textBox15.Text;
            b.DeleteOrder(idorderToDelete);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(b.GetOrder(dateTimePicker2.Value));

        }

        private void button16_Click(object sender, EventArgs e)
        {
            string idAssort = textBox1.Text;
            string nameSweet = textBox2.Text;
            int idGroup = int.Parse(textBox3.Text);
            string recipe = textBox4.Text;
            double weight = double.Parse(textBox5.Text);
            double pricePerSweet = double.Parse(textBox6.Text);

            b.UpdateAssortSweets(idAssort, nameSweet, idGroup, recipe, weight, pricePerSweet);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int idGroup = int.Parse(textBox18.Text);
            string nameGroup = textBox13.Text;

            b.UpdateGroupOfSweets(idGroup, nameGroup);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string idOrder = textBox12.Text;
            DateTime dateOfDelivery = DateTime.Parse(dateTimePicker1.Text);
            string idAssort = textBox10.Text;
            int addon = checkBox1.Checked ? 1 : 0;
            double pricePerSweet = double.Parse(textBox8.Text);
            int amountOfSweets = int.Parse(textBox7.Text);

            b.UpdateOrder(idOrder, dateOfDelivery, idAssort, addon, pricePerSweet, amountOfSweets);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

       
    }
}
