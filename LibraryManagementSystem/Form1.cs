using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    

    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;uid=root;pwd=YOUR_PASSWORD;"); // Update your password if needed
        string currentTable = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO books (title, author, year) VALUES (@title, @author, @year)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@author", textBox3.Text);
                    cmd.Parameters.AddWithValue("@year", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Added!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Adding Book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE books SET title=@title, author=@author, year=@year WHERE book_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@author", textBox3.Text);
                    cmd.Parameters.AddWithValue("@year", textBox4.Text);
                    cmd.Parameters.AddWithValue("@id", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating Book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM books WHERE book_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Deleting Book: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO members (name, email, phone) VALUES (@name, @email, @phone)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBox6.Text);
                    cmd.Parameters.AddWithValue("@email", textBox7.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox8.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrower Added!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Adding Borrower: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE members SET name=@name, email=@email, phone=@phone WHERE member_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBox6.Text);
                    cmd.Parameters.AddWithValue("@email", textBox7.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox8.Text);
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrower Updated!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating Borrower: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM members WHERE member_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrower Deleted!");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Deleting Borrower: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM books";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    currentTable = "books";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Showing Books: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM members";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    currentTable = "members";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Showing Borrowers: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            RefreshData();

        }

        private void RefreshData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM books";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                currentTable = "books";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Refreshing Data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // If showing Books table
                textBox2.Text = row.Cells["book_id"].Value.ToString();
                textBox1.Text = row.Cells["title"].Value.ToString();
                textBox3.Text = row.Cells["author"].Value.ToString();
                textBox4.Text = row.Cells["year"].Value.ToString();

                // If showing Members table, adjust accordingly
                textBox5.Text = row.Cells["member_id"].Value.ToString();
                textBox6.Text = row.Cells["name"].Value.ToString();
                textBox7.Text = row.Cells["email"].Value.ToString();
                textBox8.Text = row.Cells["phone"].Value.ToString();
            }
        }
    }
}
