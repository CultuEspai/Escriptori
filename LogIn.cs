using CultuEspai.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class LogIn : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;

        //variable estatica per l'usuari actual
        //public static Usuari UsuariActual { get; private set; }
        public static Usuaris UsuariActual { get; private set; }


        public LogIn()
        {
            InitializeComponent();
            UIHelper.SetRoundedCorners(roundedPanel, 20);
            UIHelper.SetRoundedCorners(buttonLogIn, 5);

            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();

            // Vincula els TextBox als camps de la font de dades (binding)
            bindingSource.DataSource = new UserLogin();
            textBoxEmail.DataBindings.Add("Text", bindingSource, "Email");
            textBoxPassword.DataBindings.Add("Text", bindingSource, "Password");
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string userEmail = ((UserLogin)bindingSource.Current).Email;
            string password = ((UserLogin)bindingSource.Current).Password;

            //string userEmail = "joan.puig@example.com";
            //string password = "contrasenya123";

            //string userEmail = "marta.garcia@example.com";
            //string password = "contrasenya456";

            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Si us plau, omple tots els camps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int val = validateUser(userEmail, password);

            if (val == 1)
            {
                this.Hide(); // Oculta el formulari de login

                // Obre la pantalla del superadmin
                GestioSales superAdminForm = new GestioSales();
                superAdminForm.ShowDialog();
                this.Close();
            }
            else if(val == 2)
            {
                this.Hide();

                GestioUsuaris gestioUsuaris = new GestioUsuaris();
                gestioUsuaris.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credencials incorrectes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int validateUser(string email, string enteredPassword)
        {
            int isValid = 0;
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT UsuariID, Nom, Correu, TipusUsuari, ContrasenyaHash FROM Usuaris WHERE Correu = @email";
                SqlCommand cmd = new SqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedHash = reader["ContrasenyaHash"] as string; // BCrypt genera un hash en string
                    if (string.IsNullOrEmpty(storedHash))
                    {
                        MessageBox.Show("L'usuari no té una contrasenya guardada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }

                    // Validar la contrasenya amb BCrypt
                    if (BCrypt.Net.BCrypt.EnhancedVerify(enteredPassword, storedHash))
                    {
                        // Crear la instància de l'usuari actual amb les dades recuperades
                        UsuariActual = new Usuaris
                        {
                            UsuariID = reader.GetInt32(0),
                            Nom = reader.GetString(1),
                            Correu = reader.GetString(2),
                            TipusUsuari = reader.GetString(3)
                        };

                        if (UsuariActual.TipusUsuari == "Superadmin")
                        {
                            isValid = 1; // Superadmin
                        }
                        else if (UsuariActual.TipusUsuari == "Organitzador")
                        {
                            isValid = 2; // Organitzador
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de connexió: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return isValid;
        }



    }

    // Classe que conté les dades del login
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
