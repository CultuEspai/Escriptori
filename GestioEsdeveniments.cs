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
    public partial class GestioEsdeveniments : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;
        public GestioEsdeveniments()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();
            diseny();
            carregarEsdeveniments();
        }
        private void carregarEsdeveniments()
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT E.*, S.Nom AS NomSala, U.Nom NomOrganitzador FROM Esdeveniments E " +
                    "JOIN Sales S ON E.SalaID = S.SalaID JOIN Usuaris U ON E.OrganitzadorID = U.UsuariID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hi ha esdeveniments a la base de dades.");
                }
                else
                {
                    // Assignem el DataTable a BindingSource
                    bindingSource.DataSource = dt;

                    // Assignem el BindingSource al DataGridView
                    dataGridViewEvents.DataSource = bindingSource;

                    bindingSource.ResetBindings(false);

                    // Columnes
                    dataGridViewEvents.DataBindingComplete += (s, e) =>
                    {
                        // Amagar la columna EsdevenimentID
                        dataGridViewEvents.Columns["EsdevenimentID"].Visible = false;
                    };

                    dataGridViewEvents.RowHeadersVisible = false;
                    dataGridViewEvents.Columns["SalaID"].Visible = false;
                    dataGridViewEvents.Columns["OrganitzadorID"].Visible = false;
                    dataGridViewEvents.Columns["DePagament"].Visible = false;


                    dataGridViewEvents.Columns["Descripcio"].HeaderText = "Descripció";
                    dataGridViewEvents.Columns["DataInici"].HeaderText = "Inici";
                    dataGridViewEvents.Columns["DataFi"].HeaderText = "Final";
                    dataGridViewEvents.Columns["NomSala"].HeaderText = "Sala";
                    dataGridViewEvents.Columns["NomOrganitzador"].HeaderText = "Organitzador";
                    dataGridViewEvents.Columns["EntradesDisp"].HeaderText = "Entrades";

                    dataGridViewEvents.Columns["Nom"].Width = 120;
                    dataGridViewEvents.Columns["Estat"].Width = 60;
                    dataGridViewEvents.Columns["Aforament"].Width = 66;
                    dataGridViewEvents.Columns["Preu"].Width = 40;
                    dataGridViewEvents.Columns["NomSala"].Width = 50;
                    dataGridViewEvents.Columns["NomOrganitzador"].Width = 75;
                    dataGridViewEvents.Columns["Descripcio"].Width = 220;
                    dataGridViewEvents.Columns["EntradesDisp"].Width = 60;

                    if (dataGridViewEvents.Columns["DataInici"] != null)
                    {
                        dataGridViewEvents.Columns["DataInici"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
                    }
                    if (dataGridViewEvents.Columns["DataFi"] != null)
                    {
                        dataGridViewEvents.Columns["DataFi"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
                    }

                    if (dataGridViewEvents.Columns["Preu"] != null)
                    {
                        foreach (DataGridViewRow row in dataGridViewEvents.Rows)
                        {
                            bool dePagamentBool = row.Cells["DePagament"].Value != DBNull.Value && (bool)row.Cells["DePagament"].Value;
                            int dePagament = dePagamentBool ? 1 : 0;

                            if (dePagament == 1)
                            {
                                // De pagament, si no hi ha preu surt 0
                                if (row.Cells["Preu"].Value == DBNull.Value)
                                {
                                    row.Cells["Preu"].Value = 0;
                                }
                            }
                            else
                            {
                                // No és de pagament, preu surt buit
                                row.Cells["Preu"].Value = DBNull.Value;
                            }
                        }
                    }                    

                    foreach (DataGridViewColumn column in dataGridViewEvents.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar els esdeveniments: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonAddEvent, 8);
            UIHelper.SetRoundedCorners(buttonEditEvent, 8);
            UIHelper.SetRoundedCorners(buttonDeleteEvent, 8);
            dataGridViewEvents.DataError += dataGridViewEsdeveniments_DataError;
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            AddEvent formEvent = new AddEvent();

            if (formEvent.ShowDialog() == DialogResult.OK)
            {
                carregarEsdeveniments();
                dataGridViewEvents.ClearSelection();
            }
        }

        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un esdeveniment per editar-lo.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EsdevenimentID"].Value);

            EditEvent editForm = new EditEvent(eventID);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                carregarEsdeveniments();
            }
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un esdeveniment per eliminar!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EsdevenimentID"].Value);

            try
            {
                dbConnection.OpenConnection();

                if (comprovarEntrades(eventID))
                {
                    MessageBox.Show("Aquest esdeveniment té entrades venudes! Elimina primer les entrades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dbConnection.CloseConnection();
                    return;
                }

                DialogResult result = MessageBox.Show("Estàs segur que vols eliminar aquest esdeveniment?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM Esdeveniments WHERE EsdevenimentID = {eventID}";
                    dbConnection.ExecuteNonQuery(deleteQuery);

                    MessageBox.Show("Esdeveniment eliminat correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregarEsdeveniments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en eliminar l'esdeveniment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private bool comprovarEntrades(int eventID)
        {
            string checkQuery = "SELECT COUNT(*) FROM Entrades WHERE EsdevenimentID = @EsdevenimentID";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetConnection()))
            {
                checkCommand.Parameters.AddWithValue("@EsdevenimentID", eventID);

                object result = checkCommand.ExecuteScalar();
                int entradesCount = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 0;

                return entradesCount > 0;
            }
        }


        private void buttonEntrades_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un esdeveniment per veure les entrades.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EsdevenimentID"].Value);

            GestioEntrades form = new GestioEntrades(esdevenimentID: eventID);
            form.ShowDialog();
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
        private void dataGridViewEsdeveniments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Evitem que aparegui el missatge d'error
            e.ThrowException = false;

            // Opcional: Mostrar missatge personalitzat
            MessageBox.Show("Error en carregar les dades. Revisa el format de la informació.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
