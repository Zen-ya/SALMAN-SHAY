using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace endProj
{
    internal class Sql_main :Window
    {

        string userName ;
        string email ;
        string phone;
        string password;
        string user_type;
        List<Sql_main> users = new List<Sql_main>();
        private const string connectionString = "Server=ELYA-C\\SQLEXPRESS;Database=En_chanter;Integrated Security=SSPI;";
        string query_insert = "INSERT INTO Users(User_namee, Email, Phone, PasswordHash , type_user) VALUES(@UserName, @Email, @Phone, @Password , @type_user)";
        string query_show_all_user = "select * from Users";
        string query_delete = "DELETE FROM Users WHERE UserName = @UserNameToDelete;";
        string query_update_user_mail = "UPDATE Users SET UserName = @NewUserName, Email = @NewEmail WHERE UserId = @UserIdToUpdate;";
        string query_update_user_phone = "UPDATE Users SET Phone = @NewPhone WHERE UserId = @UserIdToUpdate;";
        string query_update_user_password = "UPDATE Users SET PasswordHash = @NewPassword WHERE UserId = @UserIdToUpdate;";

        public Sql_main(string userName, string email, string phone, string password)
        {
            this.userName = userName;   
            this.email = email;
            this.phone = phone;
            this.password = HashPassword(password);
            user_type = "USER";
            users.Add(this);
           

        }
        public Sql_main() { }
        public void Add_to_database()
        {       
            try
            {
                // Création et ouverture de la connexion à la base de données
                SqlConnection connection = new SqlConnection(connectionString);
               

                    // Création de la commande SQL avec la requête et la connexion associées
                    using (SqlCommand command_ = new SqlCommand(query_insert, connection))
                    {
                        connection.Open();
                    // Ajout des paramètres avec leurs valeurs
                        command_.Parameters.AddWithValue("@email", this.email);
                        command_.Parameters.AddWithValue("@password", this.password);
                        command_.Parameters.AddWithValue("@phone", this.phone);
                        command_.Parameters.AddWithValue("@username", this.userName);
                        command_.Parameters.AddWithValue("@type_user", this.user_type);

                        // Exécution de la commande SQL
                        int rowsAffected = command_.ExecuteNonQuery();

                        // Vérification du nombre de lignes affectées
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User add.");
                            
                        }
                        else
                        {
                            MessageBox.Show("not add.");
                        }
                    }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show("Erreur : " + ex.Message);
            }
            
        }

       
        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

    }
}