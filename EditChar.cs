using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class EditChar : Form
    {
        private DatabaseConnection dbConnection;
        private int caracteristicaID;
        private BindingSource bindingSourceCaracteristica;

        public EditChar(int caracterisiticaID)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.caracteristicaID = caracterisiticaID;
            diseny();
            bindingSourceCaracteristica = new BindingSource();
        }

        private void EditChar_Load(object sender, EventArgs e)
        {
            dbConnection.OpenConnection();

            string query = $"SELECT CaracteristicaNom, CaracteristicaValor FROM CaracteristiquesSales WHERE CaracteristicaID = {caracteristicaID}";
            SqlDataReader reader = dbConnection.ExecuteQuery(query);

            if (reader.Read())
            {
                // Crear un objecte de CaracteristicaSala amb les dades llegides
                CaracteristicaSala caracteristica = new CaracteristicaSala
                {
                    CaracteristicaID = caracteristicaID,
                    CaracteristicaNom = reader["CaracteristicaNom"].ToString(),
                    CaracteristicaValor = reader["CaracteristicaValor"].ToString()
                };

                // Vincular l'objecte amb el BindingSource
                bindingSourceCaracteristica.DataSource = caracteristica;

                // Vincular els controls de TextBox amb el BindingSource
                textBoxNomChar.DataBindings.Add("Text", bindingSourceCaracteristica, "CaracteristicaNom");
                textBoxValChar.DataBindings.Add("Text", bindingSourceCaracteristica, "CaracteristicaValor");
            }

            dbConnection.CloseConnection();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Obtenir els valors de l'objecte vinculat
            string nom = ((CaracteristicaSala)bindingSourceCaracteristica.Current).CaracteristicaNom;
            string valor = ((CaracteristicaSala)bindingSourceCaracteristica.Current).CaracteristicaValor;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Omple tots els camps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                string updateQuery = $"UPDATE CaracteristiquesSales SET CaracteristicaNom = '{nom}', CaracteristicaValor = '{valor}', DataModificacio = GETDATE() WHERE CaracteristicaID = {caracteristicaID}";
                dbConnection.ExecuteNonQuery(updateQuery);

                MessageBox.Show("Característica actualitzada correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Estàs segur que vols cancel·lar els canvis?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);
        }
    }
}
