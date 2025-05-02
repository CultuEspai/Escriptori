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
    public partial class AddChar : Form
    {
        private DatabaseConnection dbConnection;
        private int salaID;
        private BindingSource bindingSourceCaracteristiques;

        public AddChar(int salaIDSeleccionada)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            salaID = salaIDSeleccionada;
            bindingSourceCaracteristiques = new BindingSource();
            carregarNomSala();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string nom = textBoxNomChar.Text.Trim();
            string valor = textBoxValChar.Text.Trim();

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Omple tots els camps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                comprovarCaracteristica(nom, valor);
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

        private void comprovarCaracteristica(string nom, string valor)
        {
            string checkQuery = "SELECT COUNT(*) FROM CaracteristiquesSales " +
                                "WHERE SalaID = @SalaID AND CaracteristicaNom = @Nom COLLATE Latin1_General_CI_AI";

            using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetConnection()))
            {
                checkCommand.Parameters.AddWithValue("@SalaID", salaID);
                checkCommand.Parameters.AddWithValue("@Nom", nom);

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    actualitzarCaracteristica(nom, valor);
                }
                else
                {
                    afegirCaracteristica(nom, valor);
                }
            }
        }

        private void afegirCaracteristica(string nom, string valor)
        {
            string query = "INSERT INTO CaracteristiquesSales (SalaID, CaracteristicaNom, CaracteristicaValor) " +
                           "VALUES (@SalaID, @Nom, @Valor)";

            using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
            {
                command.Parameters.AddWithValue("@SalaID", salaID);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Valor", valor);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Característica afegida correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Afegeix la nova característica al BindingSource per actualitzar la vista
                    bindingSourceCaracteristiques.Add(new CaracteristicaSala { SalaID = salaID, CaracteristicaNom = nom, CaracteristicaValor = valor });
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en afegir la característica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void actualitzarCaracteristica(string nom, string valor)
        {
            string updateQuery = "UPDATE CaracteristiquesSales SET CaracteristicaValor = @Valor " +
                                 "WHERE SalaID = @SalaID AND CaracteristicaNom = @Nom COLLATE Latin1_General_CI_AI";

            using (SqlCommand updateCommand = new SqlCommand(updateQuery, dbConnection.GetConnection()))
            {
                updateCommand.Parameters.AddWithValue("@SalaID", salaID);
                updateCommand.Parameters.AddWithValue("@Nom", nom);
                updateCommand.Parameters.AddWithValue("@Valor", valor);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Característica actualitzada correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualitza la característica a la vista
                    var caracteristica = bindingSourceCaracteristiques.List.OfType<CaracteristicaSala>()
                                                 .FirstOrDefault(c => c.SalaID == salaID && c.CaracteristicaNom == nom);
                    if (caracteristica != null)
                    {
                        caracteristica.CaracteristicaValor = valor;
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en actualitzar la característica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void carregarNomSala()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT Nom FROM Sales WHERE SalaID = @SalaID";
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@SalaID", salaID);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        labelSala.Text = result.ToString();
                    }
                    else
                    {
                        labelSala.Text = "Sala no trobada";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en carregar el nom de la sala: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelSala.Text = "Error";
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

        
    }

}
