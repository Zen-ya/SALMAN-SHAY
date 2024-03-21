using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace endProj
{
    /// <summary>
    /// Interaction logic for DateManeger.xaml
    /// </summary>
    public partial class DateManeger : Window
    {
        DataTable dataTable;
        SqlConnection connection = new SqlConnection();
        string donne = "Data Source=ELYA-C\\SQLEXPRESS;Integrated Security=True";
        private const string connectionString = "Server=ELYA-C\\SQLEXPRESS;Database=En_chanter;Integrated Security=SSPI;";
        string query_show_all_user = "select * from Users";
        public DateManeger()
        {
            InitializeComponent();
            LoadData();
        }
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
        //private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void Label_TextInput(object sender, TextCompositionEventArgs e)
        //{

        //}

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    grid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void DeleteUser(Sql_main employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", employee);
                command.ExecuteNonQuery();
            }
        }
    }
}
