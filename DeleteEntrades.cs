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
    public partial class DeleteEntrades : Form
    {
        public int Quantitat { get; private set; }
        private int entradaID;
        private int esdevenimentID;
        private DatabaseConnection dbConnection;
        private bool teButaques;


        public DeleteEntrades(string nomUsuari, string nomEsdeveniment, int numEntrades, decimal? preuEntrada, string numeroButaca, int entradaID, int? esdevenimentID)
        {
            InitializeComponent();

            this.entradaID = entradaID;
            this.esdevenimentID = esdevenimentID ?? 0;

            dbConnection = new DatabaseConnection();

            labelNomUsuari.Text = nomUsuari;
            labelNomEsdeveniment.Text = nomEsdeveniment;
            labelNumEntrades.Text = numEntrades.ToString();

            if (!string.IsNullOrEmpty(numeroButaca))
            {
                teButaques = true;
                numericUpDownQuantitat.Visible = false;
                labelEntrades.Visible = false;

                string[] butaques = numeroButaca.Split(',');
                listBoxButaques.Items.AddRange(butaques);
            }
            else
            {
                teButaques = false;
                listBoxButaques.Visible = false;
                labelButaques.Visible = false;
                numericUpDownQuantitat.Maximum = numEntrades;
            }

            if (preuEntrada == null)
            {
                labelDePagament.Visible = false;
                labelTornar.Visible = false;
                labelDiners.Visible = false;
            }
            else
            {
                labelDiners.Text = preuEntrada.ToString();
            }
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnection.OpenConnection();

                if (teButaques)
                {
                    if (listBoxButaques.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Selecciona almenys una butaca!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Llistar butaques seleccionades
                    List<string> butaquesSeleccionades = listBoxButaques.SelectedItems.Cast<string>().ToList();

                    // Obtenir butaques actuals de la BBDD
                    string query = "SELECT NumeroButaca FROM Entrades WHERE EntradaID = @EntradaID";
                    SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                    command.Parameters.AddWithValue("@EntradaID", entradaID);
                    string butaquesActuals = (string)command.ExecuteScalar();

                    List<string> llistaActual = butaquesActuals.Split(',').Select(b => b.Trim()).ToList();
                    List<string> novesButaques = llistaActual.Except(butaquesSeleccionades).ToList();

                    if (novesButaques.Count == 0)
                    {
                        // 🔥 Si no queden butaques, eliminar tota l'entrada
                        string deleteQuery = "DELETE FROM Entrades WHERE EntradaID = @EntradaID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbConnection.GetConnection());
                        deleteCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                        deleteCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // 🔄 Actualitzar les butaques i la quantitat
                        string updateQuery = "UPDATE Entrades SET NumeroButaca = @NumeroButaca, Quantitat = @Quantitat WHERE EntradaID = @EntradaID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, dbConnection.GetConnection());
                        updateCommand.Parameters.AddWithValue("@NumeroButaca", string.Join(",", novesButaques));
                        updateCommand.Parameters.AddWithValue("@Quantitat", novesButaques.Count);
                        updateCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                        updateCommand.ExecuteNonQuery();
                    }

                    // 🔄 Actualitzar EntradesDisp
                    actualitzarEntradesDisponibles(butaquesSeleccionades.Count);
                }
                else
                {
                    // Entrades normals
                    int quantitatEliminar = (int)numericUpDownQuantitat.Value;

                    // Obtenir quantitat actual
                    string selectQuery = "SELECT Quantitat FROM Entrades WHERE EntradaID = @EntradaID";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, dbConnection.GetConnection());
                    selectCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                    int quantitatActual = (int)selectCommand.ExecuteScalar();

                    if (quantitatEliminar >= quantitatActual)
                    {
                        // 🔥 Eliminar tota l'entrada
                        string deleteQuery = "DELETE FROM Entrades WHERE EntradaID = @EntradaID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbConnection.GetConnection());
                        deleteCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                        deleteCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // 🔄 Reduir la quantitat
                        int novaQuantitat = quantitatActual - quantitatEliminar;
                        string updateQuery = "UPDATE Entrades SET Quantitat = @NovaQuantitat WHERE EntradaID = @EntradaID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, dbConnection.GetConnection());
                        updateCommand.Parameters.AddWithValue("@NovaQuantitat", novaQuantitat);
                        updateCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                        updateCommand.ExecuteNonQuery();
                    }

                    // 🔄 Actualitzar EntradesDisp
                    actualitzarEntradesDisponibles(quantitatEliminar);
                }

                MessageBox.Show("Entrades eliminades correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en eliminar entrades: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void actualitzarEntradesDisponibles(int quantitatAafegir)
        {
            string updateEntradesDispQuery = "UPDATE Esdeveniments SET EntradesDisp = EntradesDisp + @Quantitat WHERE EsdevenimentID = @EsdevenimentID";

            SqlCommand updateCommand = new SqlCommand(updateEntradesDispQuery, dbConnection.GetConnection());
            updateCommand.Parameters.AddWithValue("@Quantitat", quantitatAafegir);
            updateCommand.Parameters.AddWithValue("@EsdevenimentID", esdevenimentID);
            updateCommand.ExecuteNonQuery();
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
