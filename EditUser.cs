using CultuEspai.Models;
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

namespace CultuEspai
{
    public partial class EditUser : Form
    {
        private DatabaseConnection dbConnection;
        private int usuariID;
        private BindingSource bindingSourceUser;
        public EditUser(int id)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            diseny();
            this.usuariID = id;
            bindingSourceUser = new BindingSource();

        }
        private void EditUser_Load(object sender, EventArgs e)
        {

            Usuaris user = carregarUsuariDesDeDB(usuariID);

            if (user == null)
            {
                MessageBox.Show("No s'ha trobat l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bindingSourceUser.DataSource = user;

            //Etiquetes
            labelNom.Text = user.Nom;
            labelCorreu.Text = user.Correu;
            labelContrasenya.Text = user.Contrasenya;

            carregarTipusUsuaris();
            comboBoxTipus.SelectedItem = user.TipusUsuari;
            comboBoxTipus.DataBindings.Add("SelectedItem", bindingSourceUser, "TipusUsuari", true, DataSourceUpdateMode.OnPropertyChanged);

            checkBoxActiu.DataBindings.Add("Checked", bindingSourceUser, "Actiu");

            if (LogIn.UsuariActual.UsuariID == user.UsuariID)
            {
                comboBoxTipus.Enabled = false;
                checkBoxActiu.Enabled = false;
            }
            else if (LogIn.UsuariActual.TipusUsuari == "Organitzador")
            {
                comboBoxTipus.Enabled = false;
                if(user.TipusUsuari == "Superadmin" || user.TipusUsuari == "Organitzador")
                {
                    checkBoxActiu.Enabled = false;
                }
            }

        }
        private Usuaris carregarUsuariDesDeDB(int id)
        {
            Usuaris usuari = null;

            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT * FROM Usuaris WHERE UsuariID = @UsuariID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UsuariID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        usuari = new Usuaris
                        {
                            UsuariID = (int)reader["UsuariID"],
                            Nom = reader["Nom"].ToString(),
                            Correu = reader["Correu"].ToString(),
                            Contrasenya = reader["Contrasenya"].ToString(),
                            TipusUsuari = reader["TipusUsuari"].ToString(),
                            Actiu = (bool)reader["Actiu"]
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en carregar l'usuari: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return usuari;
        }
        private void carregarTipusUsuaris()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT DISTINCT TipusUsuari FROM Usuaris";
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxTipus.Items.Clear();

                    while (reader.Read())
                    {
                        comboBoxTipus.Items.Add(reader["TipusUsuari"].ToString());
                    }

                    reader.Close();
                }
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
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnection.OpenConnection();

                Usuaris usuariActualitzat = (Usuaris)bindingSourceUser.Current;

                string query = "UPDATE Usuaris SET TipusUsuari = @TipusUsuari, Actiu = @Actiu WHERE UsuariID = @UsuariID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@UsuariID", usuariActualitzat.UsuariID);
                command.Parameters.AddWithValue("@TipusUsuari", usuariActualitzat.TipusUsuari);
                command.Parameters.AddWithValue("@Actiu", usuariActualitzat.Actiu);

                command.ExecuteNonQuery();

                MessageBox.Show("Usuari actualitzat correctament!", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en actualitzar l'usuari: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);

        }
        
    }
}
