using CultuEspai.Models;
using System;
using System.Collections;
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
    public partial class GestioUsuaris : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;
        public GestioUsuaris()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();
            diseny();
            comprovarTipusUsuari();
            carregarUsuaris();
        }

        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonAddUsuari, 8);
            UIHelper.SetRoundedCorners(buttonEditUsuari, 8);
            UIHelper.SetRoundedCorners(buttonDeleteUsuari, 8);
            dataGridViewUsuaris.DataError += dataGridViewUsuaris_DataError;
        }
        private void carregarUsuaris()
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT * FROM Usuaris";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hi ha usuaris a la base de dades.");
                }
                else
                {
                    // Assignem el DataTable al BindingSource
                    bindingSource.DataSource = dt;

                    // Vinculem el BindingSource amb el DataGridView
                    dataGridViewUsuaris.DataSource = bindingSource;

                    // Neteja les columnes existents i personalitza
                    dataGridViewUsuaris.Columns["UsuariID"].Visible = false;
                    dataGridViewUsuaris.Columns["Contrasenya"].Visible = false;
                    dataGridViewUsuaris.Columns["ContrasenyaHash"].Visible = false;

                    dataGridViewUsuaris.RowHeadersVisible = false;

                    dataGridViewUsuaris.Columns["TipusUsuari"].HeaderText = "Tipus d'usuari";
                    dataGridViewUsuaris.Columns["Actiu"].Width = 70;

                    foreach (DataGridViewColumn column in dataGridViewUsuaris.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar els usuaris: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private void buttonAddUsuari_Click(object sender, EventArgs e)
        {
            AddUser formUsuari = new AddUser();

            if (formUsuari.ShowDialog() == DialogResult.OK)
            {
                carregarUsuaris();
            }
        }

        private void buttonEditUsuari_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuaris.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuari per editar-lo.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userID = Convert.ToInt32(dataGridViewUsuaris.SelectedRows[0].Cells["UsuariID"].Value);

            EditUser editForm = new EditUser(userID);

            if(editForm.ShowDialog() == DialogResult.OK)
            {
                carregarUsuaris();
            }

        }

        private void buttonDeleteUsuari_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuaris.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuari per eliminar!", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DataRowView currentRow = (DataRowView)bindingSource.Current;

            Usuaris usuariAEliminar = new Usuaris   
            {
                UsuariID = (int)currentRow["UsuariID"],
                Nom = currentRow["Nom"].ToString(),
                Correu = currentRow["Correu"].ToString(),
                TipusUsuari = currentRow["TipusUsuari"].ToString(),
                Actiu = (bool)currentRow["Actiu"]
            };


            // Confirmació abans d'eliminar
            DialogResult result = comprovarUsuari(usuariAEliminar);

            if (result == DialogResult.Yes)
            {
                comprovarEntrades(usuariAEliminar.UsuariID);
                eliminarUsuari(usuariAEliminar.UsuariID);
            }

        }
        //error
        private void comprovarEntrades(int usuariID)
        {
            // Comprovar si l'esdeveniment té entrades venudes
            string checkQuery = "SELECT COUNT(*) FROM Entrades WHERE UsuariID = @UsuariID";
            SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetConnection());
            checkCommand.Parameters.AddWithValue("@UsuariID", usuariID);

            int entradesCount = (int)checkCommand.ExecuteScalar();

            if (entradesCount > 0)
            {
                MessageBox.Show("Aquest usuari té entrades comprades! Elimina primer les entrades.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private DialogResult comprovarUsuari(Usuaris usuariAEliminar)
        {

            if (usuariAEliminar == null)
            {
                MessageBox.Show("No s'ha seleccionat cap usuari per eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.No;
            }

            // Comprovar s'intenta eliminar l'usuari actual
            if (LogIn.UsuariActual.UsuariID == usuariAEliminar.UsuariID)
            {
                MessageBox.Show("No es pot eliminar l'usuari actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return DialogResult.No;
            }

            // Comprovar si l'usuari que s'intenta eliminar és un superadmin
            if (usuariAEliminar.TipusUsuari == "Superadmin")
            {
                MessageBox.Show("No es pot eliminar un Superadmin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return DialogResult.No;
            }

            // Comprovar el tipus d'usuari que està connectat
            if (LogIn.UsuariActual.TipusUsuari == "Organitzador" && usuariAEliminar.TipusUsuari == "Organitzador")
            {
                MessageBox.Show("Els organitzadors no poden eliminar altres organitzadors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return DialogResult.No;
            }

            return DialogResult.Yes;
        }

        private void eliminarUsuari(int usuariID)
        {
            // Confirmació
            DialogResult result = MessageBox.Show("Estàs segur que vols eliminar aquest usuari?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dbConnection.OpenConnection();

                    string query = $"DELETE FROM Usuaris WHERE UsuariID = {usuariID}";
                    using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@UsuariID", usuariID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuari eliminat correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            carregarUsuaris();
                        }
                        else
                        {
                            MessageBox.Show("No s'ha pogut eliminar l'usuari.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en eliminar l'usuari: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }

        private void comprovarTipusUsuari()
        {
            if(LogIn.UsuariActual.TipusUsuari == "Organitzador")
            {
                salesToolStripMenuItem.Visible = false;
            }
            else if(LogIn.UsuariActual.TipusUsuari == "Superadmin")
            {
                esdevenimentsToolStripMenuItem.Visible = false;
            }
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestioSales gestioSales = new GestioSales();
            this.Hide();
            gestioSales.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn loginForm = new LogIn();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
        private void esdevenimentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestioEsdeveniments gestioEsdeveniments = new GestioEsdeveniments();
            this.Hide();
            gestioEsdeveniments.ShowDialog();
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridViewUsuaris_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Evitem que aparegui el missatge d'error
            e.ThrowException = false;

            // Opcional: Mostrar missatge personalitzat
            MessageBox.Show("Error en carregar les dades. Revisa el format de la informació.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonEntrades_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuaris.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuari per veure les entrades.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userID = Convert.ToInt32(dataGridViewUsuaris.SelectedRows[0].Cells["UsuariID"].Value);
            string nomUsuari = dataGridViewUsuaris.SelectedRows[0].Cells["Nom"].Value.ToString();

            GestioEntrades form = new GestioEntrades(usuariID: userID, nomUsuari: nomUsuari);
            form.ShowDialog();
        }
    }
}
