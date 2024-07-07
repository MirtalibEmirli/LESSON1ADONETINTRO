using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdoTask
{
    public partial class Form1 : Form
    {

        SqlConnection sqlConnection = null;
        SqlDataReader reader = null;
        DataTable table = null;


        public Form1()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*table = new DataTable();
                      table.Columns.Add("Id");
                      table.Columns.Add("Name");
                      table.Columns.Add("Surname");
                      DataRow row = table.NewRow();
                      row[0] = 1;
                      row[1] = "Hakuna";
                      row[2] = "Matata";
                      table.Rows.Add(row);
                      dataGridView1.DataSource = table;*/
            try
            {
                sqlConnection.Open();
                var command = new SqlCommand("Select* From Authors", sqlConnection);
                dataGridView1.DataSource = null;
                table = new DataTable();
             reader = command.ExecuteReader();
                int line = 0;

                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(reader.GetName(i));
                        }

                        line = 1;
                    }
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                }
            }

            finally
            {
                sqlConnection?.Close();
                reader?.Close();
            }
            dataGridView1.DataSource = table;

        }

      



       

        private void execbutton_Click(object sender, EventArgs e)
        {

            try
            {
                sqlConnection.Open();
                var query = "INSERT INTO Authors (Id, Firstname,LastName) VALUES(@ID,@Name,@Surname)";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@ID", (id.Text));
                command.Parameters.AddWithValue("@Name", name.Text);
                command.Parameters.AddWithValue("@Surname", sname.Text);

                command.ExecuteNonQuery();

                //reader = command.ExecuteReader();
                MessageBox.Show("Added with succes", "Imfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id.Text = string.Empty;
                name.Text = string.Empty;
                sname.Text = string.Empty;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
