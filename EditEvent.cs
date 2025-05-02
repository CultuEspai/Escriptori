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
    public partial class EditEvent : Form
    {
        private DatabaseConnection dbConnection;
        private int eventID;
        private BindingSource bindingSource;
        private bool carregant = true;
        private int? salaOriginalID;


        public EditEvent(int id)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.eventID = id;
            diseny();
            bindingSource = new BindingSource();
        }

        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);
        }
        private void EditEvent_Load(object sender, EventArgs e)
        {
            Esdeveniments esdeveniment = carregarEsdevenimentDesDeBD(eventID);

            if (esdeveniment == null)
            {
                MessageBox.Show("No s'ha trobat l'esdeveniment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bindingSource.DataSource = esdeveniment;

            textBoxNom.DataBindings.Add("Text", bindingSource, "Nom");
            textBoxDescripcio.DataBindings.Add("Text", bindingSource, "Descripcio");

            dateTimePickerDia.DataBindings.Add("Value", bindingSource, "DataInici", true, DataSourceUpdateMode.OnPropertyChanged, null, "d");
            dateTimePickerHoraInici.DataBindings.Add("Value", bindingSource, "DataInici", true, DataSourceUpdateMode.OnPropertyChanged, null, "HH:mm");
            dateTimePickerHoraFi.DataBindings.Add("Value", bindingSource, "DataFi", true, DataSourceUpdateMode.OnPropertyChanged, null, "HH:mm");

            carregarSales();
            salaOriginalID = esdeveniment.SalaID;
            comboBoxSala.SelectedItem = salaOriginalID;
            comboBoxSala.DataBindings.Add("SelectedValue", bindingSource, "SalaID", true, DataSourceUpdateMode.OnPropertyChanged);
            
            numericUpDownAforament.DataBindings.Add("Value", bindingSource, "Aforament", true, DataSourceUpdateMode.OnPropertyChanged);
            
            carregarOrganitzadors();
            comboBoxOrganitzador.SelectedItem = esdeveniment.OrganitzadorID;
            comboBoxOrganitzador.DataBindings.Add("SelectedValue", bindingSource, "OrganitzadorID", true, DataSourceUpdateMode.OnPropertyChanged);

            carregarEstats();
            comboBoxEstat.SelectedItem = esdeveniment.Estat;
            comboBoxEstat.DataBindings.Add("SelectedValue", bindingSource, "Estat", true, DataSourceUpdateMode.OnPropertyChanged);

            checkBoxDePagament.DataBindings.Add("Checked", bindingSource, "DePagament", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownPreu.DataBindings.Add("Value", bindingSource, "Preu", true, DataSourceUpdateMode.OnPropertyChanged);

            mostrarNumEntradesVenudes();

            dateTimePickerHoraInici.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraInici.CustomFormat = "HH:mm";
            dateTimePickerHoraInici.ShowUpDown = true;

            dateTimePickerHoraFi.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraFi.CustomFormat = "HH:mm";
            dateTimePickerHoraFi.ShowUpDown = true;

            if (checkBoxDePagament.Checked)
            {
                labelPreu.Visible = true;
                numericUpDownPreu.Visible = true;
            }
            else
            {
                labelPreu.Visible = false;
                numericUpDownPreu.Visible = false;
            }

            carregant = false;
        }
        private Esdeveniments carregarEsdevenimentDesDeBD(int id)
        {
            Esdeveniments esdeveniment = null;

            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT * FROM Esdeveniments WHERE EsdevenimentID = @EsdevenimentID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@EsdevenimentID", id); 

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    esdeveniment = new Esdeveniments
                    {
                        EsdevenimentID = (int)reader["EsdevenimentID"],
                        Nom = (string)reader["Nom"],
                        Descripcio = (string)reader["Descripcio"],
                        DataInici = (DateTime)reader["DataInici"],
                        DataFi = (DateTime)reader["DataFi"],
                        Aforament = (int)reader["Aforament"],
                        SalaID = (int)reader["SalaID"],
                        OrganitzadorID = (int)reader["OrganitzadorID"],
                        Estat = (string)reader["Estat"],
                        DePagament = (bool)reader["DePagament"],
                        Preu = reader["Preu"] == DBNull.Value ? 0 : (int)reader["Preu"]
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar l'esdeveniment: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return esdeveniment;
        }
        private void carregarSales()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT SalaID, Nom, Aforament, CadiresFixes FROM Sales";
                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Assignem el DataTable com a font de dades del ComboBox
                comboBoxSala.DataSource = dt;
                comboBoxSala.DisplayMember = "Nom";
                comboBoxSala.ValueMember = "SalaID";

                // Estableix la primera sala com a seleccionada
                if (dt.Rows.Count > 0)
                {
                    comboBoxSala.SelectedIndex = 0;
                    actualitzarAforamentMaxim();
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


        private void carregarOrganitzadors()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT UsuariID, Nom FROM Usuaris WHERE TipusUsuari = 'Organitzador'";
                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Assignem el DataTable com a font de dades del ComboBox
                comboBoxOrganitzador.DataSource = dt;
                comboBoxOrganitzador.DisplayMember = "Nom";
                comboBoxOrganitzador.ValueMember = "UsuariID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar els organitzadors: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void carregarEstats()
        {
            try
            {
                comboBoxEstat.Items.Clear();

                comboBoxEstat.Items.Add("Pendent");
                comboBoxEstat.Items.Add("Realitzat");
                comboBoxEstat.Items.Add("Cancel·lat");

                // Seleccionar un estat per defecte
                comboBoxEstat.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en carregar els diferents estats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBoxDePagament_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDePagament.Checked)
            {
                labelPreu.Visible = true;
                numericUpDownPreu.Visible = true;
            }
            else
            {
                labelPreu.Visible = false;
                numericUpDownPreu.Visible = false;
            }
        }
        private bool verificaDisponibilitat(int salaID, DateTime dataInici, DateTime dataFi, int eventID)
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT COUNT(*) FROM Esdeveniments " +
                               "WHERE SalaID = @SalaID AND " +
                               "EsdevenimentID <> @EventID AND " +
                               "((@DataInici BETWEEN DataInici AND DataFi) OR " +
                               "(@DataFi BETWEEN DataInici AND DataFi) OR " +
                               "(DataInici BETWEEN @DataInici AND @DataFi))";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@SalaID", salaID);
                command.Parameters.AddWithValue("@DataInici", dataInici);
                command.Parameters.AddWithValue("@DataFi", dataFi);
                command.Parameters.AddWithValue("@EventID", eventID);

                int count = (int)command.ExecuteScalar();
                return count > 0; // Si count > 0, hi ha conflicte
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en comprovar disponibilitat de la sala: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

            private void comboBoxSala_SelectedIndexChanged(object sender, EventArgs e)
            {

                if (carregant) return;
                if (comprovarEntrades(eventID))
                {
                    MessageBox.Show("No pots canviar la sala perquè ja s'han venut entrades per aquest esdeveniment. Elimina primer les entrades per poder modificar la sala.", "Canvi de sala no permès", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Tornar a la sala original
                    comboBoxSala.SelectedIndexChanged -= comboBoxSala_SelectedIndexChanged;
                    comboBoxSala.SelectedValue = salaOriginalID;
                    comboBoxSala.SelectedIndexChanged += comboBoxSala_SelectedIndexChanged;

                return;
                }
                actualitzarAforamentMaxim();
            }
            private bool comprovarEntrades(int eventID)
            {
                bool hiHaEntrades = false;

                try
                {
                    dbConnection.OpenConnection();
                    string query = "SELECT COUNT(*) FROM Entrades WHERE EsdevenimentID = @EsdevenimentID";

                    using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@EsdevenimentID", eventID);
                        int count = (int)command.ExecuteScalar();
                        hiHaEntrades = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en comprovar les entrades: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }

                return hiHaEntrades;
            }

        private void actualitzarAforamentMaxim()
        {
            if (comboBoxSala.SelectedItem != null)
            {
                DataRowView selectedRow = comboBoxSala.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    if (selectedRow.DataView.Table.Columns.Contains("CadiresFixes"))
                    {
                        bool teCadiresFixes = Convert.ToBoolean(selectedRow["CadiresFixes"]);
                        labelCadires.Text = teCadiresFixes ? "La sala té cadires fixes" : "La sala no té cadires fixes";
                    }
                    else
                    {
                        labelCadires.Text = "Error: columna CadiresFixes no trobada.";
                    }

                    int aforamentMaxim = Convert.ToInt32(selectedRow["Aforament"]);
                    numericUpDownAforament.Maximum = aforamentMaxim;
                    labelAforamentMax.Text = "Aforament màxim: " + aforamentMaxim + " persones";
                }
            }
        }

        //TO DO Actualitzar per a que mostri el num d'entrades venudes
        //Això modificarà el numericUpDownAforament.Minimum
        private void mostrarNumEntradesVenudes()
        {
            labelEntradesVenudes.Text = "Num. entrades venudes: xxx";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Estàs segur que vols cancel·lar els canvis?", "Confirmació", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validació de camps obligatoris
            if (string.IsNullOrEmpty(textBoxNom.Text) || string.IsNullOrEmpty(textBoxDescripcio.Text))
            {
                MessageBox.Show("El nom i la descripció són camps obligatoris.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownAforament.Value < 1)
            {
                MessageBox.Show("L'aforament ha de ser com a mínim d'una persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Combinar data i hora
            DateTime dataInici = dateTimePickerDia.Value.Date + dateTimePickerHoraInici.Value.TimeOfDay;
            DateTime dataFi = dateTimePickerDia.Value.Date + dateTimePickerHoraFi.Value.TimeOfDay;

            // Si la hora de fi és abans de la de inici, considerem que la data de fi és al dia següent
            if (dataFi <= dataInici)
            {
                dataFi = dataFi.AddDays(1);
            }

            // Validació de durada mínima (15 minuts)
            if ((dataFi - dataInici).TotalMinutes < 15)
            {
                MessageBox.Show("L'esdeveniment ha de durar com a mínim 15 minuts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int salaID = Convert.ToInt32(comboBoxSala.SelectedValue);

            Esdeveniments esdevenimentActual = (Esdeveniments)bindingSource.Current;
            int eventID = esdevenimentActual.EsdevenimentID;

            // Comprovar si hi ha conflicte amb altres esdeveniments
            if (verificaDisponibilitat(salaID, dataInici, dataFi, eventID))
            {
                MessageBox.Show("Ja hi ha un esdeveniment programat en aquesta sala per a aquesta franja horària.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                Esdeveniments eventActualitzat = (Esdeveniments)bindingSource.Current;

                string query = "UPDATE Esdeveniments SET Nom = @Nom, Descripcio = @Descripcio, DataInici = @DataInici, DataFi = @DataFi, Aforament = @Aforament, SalaID = @SalaID, OrganitzadorID = @OrganitzadorID, DePagament = @DePagament, Preu = @Preu WHERE EsdevenimentID = @EsdevenimentID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());

                command.Parameters.AddWithValue("@EsdevenimentID", eventActualitzat.EsdevenimentID);
                command.Parameters.AddWithValue("@Nom", eventActualitzat.Nom);
                command.Parameters.AddWithValue("@Descripcio", eventActualitzat.Descripcio);
                command.Parameters.AddWithValue("@DataInici", eventActualitzat.DataInici);
                command.Parameters.AddWithValue("@DataFi", eventActualitzat.DataFi);
                command.Parameters.AddWithValue("@Aforament", eventActualitzat.Aforament);
                command.Parameters.AddWithValue("@SalaID", eventActualitzat.SalaID);
                command.Parameters.AddWithValue("@OrganitzadorID", eventActualitzat.OrganitzadorID);
                command.Parameters.AddWithValue("@DePagament", eventActualitzat.DePagament);
                command.Parameters.AddWithValue("@Preu", eventActualitzat.Preu);
                /*
                 gestionar les entrades disponibles segons el nombre d'entrades venudes i l'aforamnet total
                ex: no poder reduir l'aforament total per sota del numero d'entrades venudes fins ara
                -> poser un text amb el numero d'entrades venudes fins ara.
                 */

                command.ExecuteNonQuery();

                MessageBox.Show("Esdeveniment actualitzat correctament!", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en actualitzar l'esdeveniment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
