
using System.Text.RegularExpressions;
using System.Windows;

namespace endProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        private const string conect_sql_string = "Data Source=ELYA-C\\SQLEXPRESS;Initial Catalog=En_chanter;Integrated Security=True;Encrypt=False";
        
        public MainWindow()
        {
            InitializeComponent();
        }
            

        public static bool CheckingDetailsRegex(string user, string password)
        {
            return Regex.IsMatch(user, @"^[a-z]{5,12}$") &&
                   Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{7,12}$");
        }



        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string UserLogIn = UserToLogIn.Text;
            string PasswordLogIn = PasswordToLogIn.Text;
            if (CheckingDetailsRegex(UserLogIn, PasswordLogIn))
            {
                // הפניה לשרת לבדיקה עם שם המשתמש קיים

                if (true)//אם שם המשתמש קיים הפניה  לעמוד מנהל
                {
                    // אם חזר אמת מהשרת יש לפתוח עמוד ניהול משתמשים
                    DateManeger dateManeger = new DateManeger();
                    dateManeger.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("user name or password incorrect please try again");
            }
        }

        private void Registration_NavgetButton(object sender, RoutedEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            this.Close();//סגירת החלון הנוחכי
        }

    }
 }
