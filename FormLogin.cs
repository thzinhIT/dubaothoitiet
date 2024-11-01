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

namespace howto_weather_forecast2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=THONGDOAN\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy tên người dùng và mật khẩu từ các ô nhập liệu
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                String querry = "SELECT * FORM login WHERE username = '" + textBox1 + "' AND password = '" + textBox2 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if ( dtable.Rows.Count > 0 )
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    Form form = new Form();
                    form.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch{
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
            MessageBox.Show(password, username, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
