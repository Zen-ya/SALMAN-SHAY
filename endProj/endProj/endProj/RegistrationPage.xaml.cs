using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace endProj
{
    public partial class RegistrationPage : Window 
    {  
        public RegistrationPage()
        {
            InitializeComponent();
        }
      
        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            string userName = UserToUp.Text;
            string email = EmailToUp.Text;
            string phone = PhoneToUp.Text;
            string password = Password.Password;
            string confirmPassword = ConfirmationPassword.Password;

            if (IsValidRegistrationDetails(userName, email, phone, password, confirmPassword))
            {
                MessageBox.Show("You have successfully registered. Go to the login page to login.");
                Sql_main sql = new Sql_main(userName, email, phone, password);
                sql.Add_to_database();

            }
        }

        private bool IsValidRegistrationDetails(string userName, string email, string phone, string password, string confirmPassword)
        {
            // Validation côté client
            if (!IsValidUsername(userName) || !IsValidEmail(email) || !IsValidPhoneNumber(phone) || !ArePasswordsMatching(password, confirmPassword) || !IsValidPassword(password))
            {
                MessageBox.Show("Invalid registration details. Please correct the errors.");
                return false;
            }

            // Validation côté serveur
            try
            {
             
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid Email.");
                    return false;
                }

       
                if (!IsValidPhoneNumber(phone))
                {
                    MessageBox.Show("Invalid Phone Number. Phone number must be in the format 0XX-XXXXXXX.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

     

        private bool IsValidUsername(string userName)
        {
            return Regex.IsMatch(userName, @"^[a-z]{5,12}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^0\d{1,2}-\d{7}$");
        }

        private bool ArePasswordsMatching(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,12}$");
        }

        private void LogIntPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
