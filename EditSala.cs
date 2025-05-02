using CultuEspai.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class EditSala : Form
    {
        private DatabaseConnection dbConnection;
        private int salaID;
        private BindingSource bindingSourceSala;

        public EditSala(int id)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            diseny();
            this.salaID = id;
            bindingSourceSala = new BindingSource();
        }
        private void EditSala_Load(object sender, EventArgs e)
        {

            // Obtenir la informació de la sala des de la base de dades
            Sales sala = carregarSalaDesDeDB(salaID);

            if (sala == null)
            {
                MessageBox.Show("No s'ha trobat la sala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bindingSourceSala.DataSource = sala;

            // Actualitzar les etiquetes i els controls
            labelNomSala.Text = sala.Nom;
            labelMetresQuadrats.Text = sala.MetresQuadrats.ToString();

            numericUpDownAforament.DataBindings.Add("Value", bindingSourceSala, "Aforament");
            checkBoxCadiresFixes.DataBindings.Add("Checked", bindingSourceSala, "CadiresFixes");
            textBoxDescripcio.DataBindings.Add("Text", bindingSourceSala, "Descripcio");
        }

        private Sales carregarSalaDesDeDB(int id)
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT * FROM Sales WHERE SalaID = @SalaID";
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@SalaID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Sales sala = new Sales
                        {
                            SalaID = (int)reader["SalaID"],
                            Nom = reader["Nom"].ToString(),
                            Aforament = (int)reader["Aforament"],
                            CadiresFixes = (bool)reader["CadiresFixes"],
                            MetresQuadrats = (int)reader["MetresQuadrats"],
                            Descripcio = reader["Descripcio"].ToString()
                        };

                        reader.Close();
                        return sala;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en carregar la sala: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return null;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnection.OpenConnection();

                // Obtenir l'objecte Sala actualitzat
                Sales salaActualitzada = (Sales)bindingSourceSala.Current;

                // Query d'actualització amb els valors de l'objecte
                string query = "UPDATE Sales SET Aforament = @Aforament, CadiresFixes = @CadiresFixes, Descripcio = @Descripcio WHERE SalaID = @SalaID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@SalaID", salaActualitzada.SalaID);
                command.Parameters.AddWithValue("@Aforament", salaActualitzada.Aforament);
                command.Parameters.AddWithValue("@CadiresFixes", salaActualitzada.CadiresFixes);
                command.Parameters.AddWithValue("@Descripcio", salaActualitzada.Descripcio);

                command.ExecuteNonQuery();

                MessageBox.Show("Sala actualitzada correctament!", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en actualitzar la sala: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
