using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class GestioSales : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSourceSales;
        private BindingSource bindingSourceCaracteristiques;

        public GestioSales()
        {
            InitializeComponent();
            diseny();
            dataGridViewSales.CellClick += new DataGridViewCellEventHandler(dataGridViewSales_CellClick);
            dbConnection = new DatabaseConnection();
            bindingSourceSales = new BindingSource();
            bindingSourceCaracteristiques = new BindingSource();
            carregarSales();
            carregarCaracteristiques(1);
        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonAddChar, 8);
            UIHelper.SetRoundedCorners(buttonDeleteChar, 8);
            UIHelper.SetRoundedCorners(buttonEditChar, 8);
            UIHelper.SetRoundedCorners(buttonEditSala, 8);
        }
        private void carregarSales()
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT * FROM Sales";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hi ha sales a la base de dades.");
                }
                else
                {
                    // Assignem el DataTable a BindingSource
                    bindingSourceSales.DataSource = dt;

                    // Assignem el BindingSource al DataGridView
                    dataGridViewSales.DataSource = bindingSourceSales;

                    // Columnes
                    dataGridViewSales.Columns["SalaID"].Visible = false;
                    dataGridViewSales.RowHeadersVisible = false;

                    dataGridViewSales.Columns["CadiresFixes"].HeaderText = "Cadires fixes";
                    dataGridViewSales.Columns["MetresQuadrats"].HeaderText = "Metres quadrats";
                    dataGridViewSales.Columns["Descripcio"].HeaderText = "Descripció";

                    dataGridViewSales.Columns["Nom"].Width = 70;
                    dataGridViewSales.Columns["Aforament"].Width = 70;
                    dataGridViewSales.Columns["CadiresFixes"].Width = 70;
                    dataGridViewSales.Columns["MetresQuadrats"].Width = 70;
                    dataGridViewSales.Columns["Descripcio"].Width = 220;


                    foreach (DataGridViewColumn column in dataGridViewSales.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar les sales: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection(); 
            }
        }
        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Comprovar que no estem clicant a la capçalera
            {
                // Obtenir el SalaID de la fila seleccionada
                var salaID = Convert.ToInt32(dataGridViewSales.Rows[e.RowIndex].Cells["SalaID"].Value);

                // Carregar les característiques per aquesta sala
                carregarCaracteristiques(salaID);
            }
        }

        private void carregarCaracteristiques(int salaID)
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT * FROM CaracteristiquesSales WHERE SalaID = @SalaID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@SalaID", salaID);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    bindingSourceCaracteristiques.DataSource = null;
                    dataGridViewCaracteristiques.DataSource = bindingSourceCaracteristiques;
                }
                else
                {
                    // Assignem el DataTable al BindingSource
                    bindingSourceCaracteristiques.DataSource = dt;

                    // Assignem el BindingSource al DataGridView
                    dataGridViewCaracteristiques.DataSource = bindingSourceCaracteristiques;

                    dataGridViewCaracteristiques.Columns["CaracteristicaNom"].HeaderText = "Nom";
                    dataGridViewCaracteristiques.Columns["CaracteristicaValor"].HeaderText = "Valor";
                    dataGridViewCaracteristiques.Columns["DataModificacio"].HeaderText = "Modificació";

                    dataGridViewCaracteristiques.Columns["SalaID"].Visible = false;
                    dataGridViewCaracteristiques.Columns["CaracteristicaID"].Visible = false;
                    dataGridViewCaracteristiques.RowHeadersVisible = false;

                    foreach (DataGridViewColumn column in dataGridViewCaracteristiques.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar les característiques: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        

        private void buttonEditSala_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una sala per editar-la.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenim les dades de la sala seleccionada
            int salaID = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SalaID"].Value);

            // Obrim el formulari d'edició i li passem les dades
            EditSala editForm = new EditSala(salaID);

            if (editForm.ShowDialog() == DialogResult.OK) // Esperem a que l'usuari guardi els canvis
            {
                carregarSales(); // Tornem a carregar la taula després de l'edició
            }
        }

        private void buttonAddChar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una sala primer!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int salaIDSeleccionada = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SalaID"].Value);

            AddChar formCaracteristica = new AddChar(salaIDSeleccionada);
            
            if(formCaracteristica.ShowDialog() == DialogResult.OK)
            {
                carregarCaracteristiques(salaIDSeleccionada);
            }
        }

        private void buttonEditChar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCaracteristiques.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una característica primer!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int caracteristicaIDSeleccionada = Convert.ToInt32(dataGridViewCaracteristiques.SelectedRows[0].Cells["CaracteristicaID"].Value);

            int salaIDSeleccionada = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SalaID"].Value);

            EditChar formCaracteristica = new EditChar(caracteristicaIDSeleccionada);

            if (formCaracteristica.ShowDialog() == DialogResult.OK)
            {
                carregarCaracteristiques(salaIDSeleccionada);
            }
        }

        private void buttonDeleteChar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCaracteristiques.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una característica per eliminar!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int caracteristicaID = Convert.ToInt32(dataGridViewCaracteristiques.SelectedRows[0].Cells["CaracteristicaID"].Value);

            //Confirmació
            DialogResult result = MessageBox.Show("Estàs segur que vols eliminar aquesta característica?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbConnection.OpenConnection();

                    string deleteQuery = $"DELETE FROM CaracteristiquesSales WHERE CaracteristicaID = {caracteristicaID}";
                    dbConnection.ExecuteNonQuery(deleteQuery);

                    MessageBox.Show("Característica eliminada correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int salaIDSeleccionada = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SalaID"].Value);
                    carregarCaracteristiques(salaIDSeleccionada);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en eliminar la característica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        private void usuarisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestioUsuaris gestioUsuaris = new GestioUsuaris();
            this.Hide();
            gestioUsuaris.ShowDialog();
            this.Close();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn loginForm = new LogIn();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
