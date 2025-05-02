using CultuEspai.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class AddUser : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;
        public AddUser()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();
            diseny();
            inicialitzarBinding();
        }

        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);
        }
        private void inicialitzarBinding()
        {
            bindingSource.DataSource = new Usuaris();

            textBoxNom.DataBindings.Add("Text", bindingSource, "Nom", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCorreu.DataBindings.Add("Text", bindingSource, "Correu", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxContra.DataBindings.Add("Text", bindingSource, "Contrasenya", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxTipus.DataBindings.Add("Text", bindingSource, "TipusUsuari", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxActiu.DataBindings.Add("Checked", bindingSource, "Actiu", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Usuaris nouUsuari = (Usuaris)bindingSource.Current;

            if (string.IsNullOrEmpty(nouUsuari.Nom) || string.IsNullOrEmpty(nouUsuari.Correu) ||
                string.IsNullOrEmpty(nouUsuari.Contrasenya) || string.IsNullOrEmpty(nouUsuari.TipusUsuari))
            {
                MessageBox.Show("Omple tots els camps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                comprovarUsuari(nouUsuari.Correu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void comprovarUsuari(string correu)
        {
            string checkQuery = "SELECT COUNT(*) FROM Usuaris WHERE Correu = @Correu COLLATE Latin1_General_CI_AI";

            using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetConnection()))
            {
                checkCommand.Parameters.AddWithValue("@Correu", correu);

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Aquest correu electrònic ja està registrat. Si us plau, utilitza un altre.", "Correu en ús", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    afegirUsuari();
                }
            }
        }
        
        private void afegirUsuari()
        {
            Usuaris nouUsuari = (Usuaris)bindingSource.Current;
            string query = "INSERT INTO Usuaris (Nom, Correu, TipusUsuari, Actiu, ContrasenyaHash) " +
                           "VALUES (@Nom, @Correu, @TipusUsuari, @Actiu, @ContrasenyaHash)";

            using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
            {
                string passwordHash = hashPassword(nouUsuari.Contrasenya);

                command.Parameters.AddWithValue("@Nom", nouUsuari.Nom);
                command.Parameters.AddWithValue("@Correu", nouUsuari.Correu);
                command.Parameters.AddWithValue("@TipusUsuari", nouUsuari.TipusUsuari);
                command.Parameters.AddWithValue("@Actiu", nouUsuari.Actiu);
                command.Parameters.Add("@ContrasenyaHash", passwordHash);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Usuari afegit correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en afegir l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void carregarTipusUsuaris()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT DISTINCT TipusUsuari FROM Usuaris";
                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTipus.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTipus.Items.Add(reader["TipusUsuari"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en carregar els tipus d'usuaris: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Estàs segur que vols cancel·lar els canvis?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private string hashPassword(string password) 
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            if (LogIn.UsuariActual.TipusUsuari == "Organitzador")
            {
                comboBoxTipus.Enabled = false;

                comboBoxTipus.Items.Clear();
                comboBoxTipus.Items.Add("Normal");
                comboBoxTipus.SelectedItem = "Normal";
            }
            else
                carregarTipusUsuaris();
        }
    }
}
