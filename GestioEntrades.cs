using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class GestioEntrades : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;
        private int? usuariID;
        private int? esdevenimentID;
        public GestioEntrades(int? usuariID = null, int? esdevenimentID = null, string nomUsuari = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();
            this.usuariID = usuariID;
            this.esdevenimentID = esdevenimentID;
            diseny();

        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonAddEntrada, 8);
            UIHelper.SetRoundedCorners(buttonDeleteEntrada, 8);
            dataGridViewEntrades.DataError += dataGridViewEntrades_DataError;
        }

        private void GestioEntrades_Load(object sender, EventArgs e)
        {
            comprovarOrigen();
        }
        private void comprovarOrigen()
        {
            if (usuariID.HasValue)
            {
                carregarEntradesPerUsuari(usuariID.Value);
            }
            else if (esdevenimentID.HasValue)
            {
                carregarEntradesPerEsdeveniment(esdevenimentID.Value);
            }
        }
        private void carregarEntradesPerUsuari(int usuariID)
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT E.*, U.Nom AS NomUsuari, S.Nom AS NomEvent, S.Preu AS Preu FROM Entrades E JOIN Usuaris U ON E.UsuariID = U.UsuariID " +
                    "JOIN Esdeveniments S ON E.EsdevenimentID = S.EsdevenimentID WHERE E.UsuariID = @UsuariID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@UsuariID", usuariID);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aquest usuari no té cap entrada.");
                }
                else
                {
                    carregarEntrades(dt);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en carregar les entrades: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void carregarEntradesPerEsdeveniment(int esdevenimentID)
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT E.*, U.Nom AS NomUsuari, S.Nom AS NomEvent, S.Preu AS Preu FROM Entrades E " +
                    "JOIN Usuaris U ON E.UsuariID = U.UsuariID " +
                    "JOIN Esdeveniments S ON E.EsdevenimentID = S.EsdevenimentID " +
                    "WHERE E.EsdevenimentID = @EsdevenimentID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@EsdevenimentID", esdevenimentID);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aquest esdeveniment no té cap entrada venuda.");
                }
                else
                {
                    carregarEntrades(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar les entrades: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void carregarEntrades(DataTable dt)
        {
            bindingSource.DataSource = dt;

            dataGridViewEntrades.DataSource = bindingSource;
            bindingSource.ResetBindings(false);

            dataGridViewEntrades.RowHeadersVisible = false;
            dataGridViewEntrades.Columns["EntradaID"].Visible = false;
            dataGridViewEntrades.Columns["UsuariID"].Visible = false;
            dataGridViewEntrades.Columns["EsdevenimentID"].Visible = false;

            dataGridViewEntrades.Columns["NomUsuari"].HeaderText = "Usuari";
            dataGridViewEntrades.Columns["NomEvent"].HeaderText = "Esdeveniment";
            dataGridViewEntrades.Columns["NumeroButaca"].HeaderText = "Butaca";
            dataGridViewEntrades.Columns["Preu"].HeaderText = "Preu/Unitat";

            dataGridViewEntrades.Columns["Quantitat"].Width = 60;
            dataGridViewEntrades.Columns["NumeroButaca"].Width = 60;
            dataGridViewEntrades.Columns["NomEvent"].Width = 160;
            dataGridViewEntrades.Columns["Preu"].Width = 70;

            foreach (DataGridViewColumn column in dataGridViewEntrades.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void dataGridViewEntrades_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Evitem que aparegui el missatge d'error
            e.ThrowException = false;

            // Opcional: Mostrar missatge personalitzat
            MessageBox.Show("Error en carregar les dades. Revisa el format de la informació.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonAddEntrada_Click(object sender, EventArgs e)
        {
            if (usuariID.HasValue)
            {
                AddEntrada formAddEntrada = new AddEntrada(usuariID: usuariID);
                formAddEntrada.ShowDialog();

                carregarEntradesPerUsuari(usuariID.Value);
            }
            else if (esdevenimentID.HasValue)
            {
                AddEntrada formAddEntrada = new AddEntrada(esdevenimentID: esdevenimentID);
                formAddEntrada.ShowDialog();

                carregarEntradesPerEsdeveniment(esdevenimentID.Value);
            }
        }
        

        private void buttonDeleteEntrada_Click(object sender, EventArgs e)
        {
            if (dataGridViewEntrades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una entrada per eliminar!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewEntrades.SelectedRows[0];

            int entradaID = Convert.ToInt32(selectedRow.Cells["EntradaID"].Value);
            string nomUsuari = selectedRow.Cells["NomUsuari"].Value.ToString();
            string nomEsdeveniment = selectedRow.Cells["NomEvent"].Value.ToString();
            int numEntrades = Convert.ToInt32(selectedRow.Cells["Quantitat"].Value);
            decimal? preuEntrada = selectedRow.Cells["Preu"]?.Value as decimal?;
            string numeroButaca = selectedRow.Cells["NumeroButaca"].Value?.ToString() ?? "";

            using (DeleteEntrades formQuantitat = new DeleteEntrades(
                nomUsuari,
                nomEsdeveniment,
                numEntrades,
                preuEntrada,
                numeroButaca,
                entradaID,
                esdevenimentID))
            {
                if (formQuantitat.ShowDialog() == DialogResult.OK)
                {
                    comprovarOrigen();
                }
            }
        }
        private int getQuantitatEntrades(int entradaID)
        {
            // Comprovar quantes entrades hi ha per al registre seleccionat
            string query = "SELECT Quantitat FROM Entrades WHERE EntradaID = @EntradaID";
            SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
            command.Parameters.AddWithValue("@EntradaID", entradaID);

            dbConnection.OpenConnection();
            int quantitat = Convert.ToInt32(command.ExecuteScalar());
            dbConnection.CloseConnection();

            return quantitat;
        }
        private void eliminarEntrades(int entradaID, int quantitat, string nomEsdeveniment, string nomUsuari)
        {
            DialogResult result = MessageBox.Show(
                $"Estàs segur que vols eliminar {quantitat} entrada/es de l'esdeveniment {nomEsdeveniment} de l'usuari {nomUsuari}?",
                "Confirmació d'eliminació",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Entrades WHERE EntradaID = @EntradaID AND Quantitat = @Quantitat";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbConnection.GetConnection());
                deleteCommand.Parameters.AddWithValue("@EntradaID", entradaID);
                deleteCommand.Parameters.AddWithValue("@Quantitat", quantitat);

                dbConnection.OpenConnection();
                deleteCommand.ExecuteNonQuery();
                dbConnection.CloseConnection();

                MessageBox.Show($"S'han eliminat {quantitat} entrada/es correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comprovarOrigen();
            }
        }
        private void eliminarEntradesPerButaques(int entradaID, string butaquesSeleccionades)
        {
            List<string> butaquesAEliminar = butaquesSeleccionades.Split(',').ToList();

            List<string> butaquesActuals = trobarButaquesActuals(entradaID);

            butaquesActuals.RemoveAll(b => butaquesAEliminar.Contains(b));

            actualitzarColumnaEntrades(entradaID, butaquesActuals);

            MessageBox.Show("S'han eliminat les butaques seleccionades correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comprovarOrigen();
        }
        private List<string> trobarButaquesActuals(int entradaID)
        {
            string selectQuery = "SELECT NumeroButaca FROM Entrades WHERE EntradaID = @EntradaID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, dbConnection.GetConnection());
            selectCommand.Parameters.AddWithValue("@EntradaID", entradaID);

            dbConnection.OpenConnection();
            object result = selectCommand.ExecuteScalar();
            dbConnection.CloseConnection();

            return result.ToString().Split(',').ToList();
        }
        private void actualitzarColumnaEntrades(int entradaID, List <string> butaquesActuals)
        {
            string updateQuery = "UPDATE Entrades SET NumeroButaca = @NouNumeroButaca, Quantitat = @NovaQuantitat WHERE EntradaID = @EntradaID";
            SqlCommand updateCommand = new SqlCommand(updateQuery, dbConnection.GetConnection());
            updateCommand.Parameters.AddWithValue("@NouNumeroButaca", string.Join(",", butaquesActuals));
            updateCommand.Parameters.AddWithValue("@NovaQuantitat", butaquesActuals.Count);
            updateCommand.Parameters.AddWithValue("@EntradaID", entradaID);

            dbConnection.OpenConnection();
            updateCommand.ExecuteNonQuery();
            dbConnection.CloseConnection();
        }

    }
}
