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
    public partial class AddEvent : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource;
        public AddEvent()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            bindingSource = new BindingSource();
            diseny();
            inicialitzarBinding();

        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);
        }
        private void inicialitzarBinding()
        {
            bindingSource.DataSource = new Esdeveniments();

            textBoxNom.DataBindings.Add("Text", bindingSource, "Nom", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDescripcio.DataBindings.Add("Text", bindingSource, "Descripcio", true, DataSourceUpdateMode.OnPropertyChanged);

            dateTimePickerDia.DataBindings.Add("Value", bindingSource, "DataInici", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePickerHoraInici.DataBindings.Add("Value", bindingSource, "DataInici", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePickerHoraFi.DataBindings.Add("Value", bindingSource, "DataFi", true, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownAforament.DataBindings.Add("Value", bindingSource, "Aforament", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxEstat.DataBindings.Add("Text", bindingSource, "Estat", true, DataSourceUpdateMode.OnPropertyChanged);
             
            checkBoxDePagament.DataBindings.Add("Checked", bindingSource, "DePagament", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownPreu.DataBindings.Add("Value", bindingSource, "Preu", true, DataSourceUpdateMode.OnPropertyChanged);

            comboBoxSala.DataBindings.Add("SelectedValue", bindingSource, "SalaID", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxOrganitzador.DataBindings.Add("SelectedValue", bindingSource, "OrganitzadorID", true, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {
            carregarSales();
            carregarOrganitzadors();
            carregarEstats();

            dateTimePickerHoraInici.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraInici.CustomFormat = "HH:mm";
            dateTimePickerHoraInici.ShowUpDown = true;

            dateTimePickerHoraFi.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraFi.CustomFormat = "HH:mm";
            dateTimePickerHoraFi.ShowUpDown = true;

            labelPreu.Visible = false;
            numericUpDownPreu.Visible = false;
            checkBoxDePagament.Checked = false;

        }
        private void actualitzarAforamentMaxim()
        {
            if (comboBoxSala.SelectedItem != null)
            {
                DataRowView selectedRow = comboBoxSala.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    bool teCadiresFixes = Convert.ToBoolean(selectedRow["CadiresFixes"]);

                    labelCadires.Text = teCadiresFixes ? "La sala té cadires fixes" : "La sala no té cadires fixes";

                    int aforamentMaxim = Convert.ToInt32(selectedRow["Aforament"]);
                    numericUpDownAforament.Maximum = aforamentMaxim;
                    labelAforamentMax.Text = "Aforament màxim: " + aforamentMaxim + " persones";
                }
            }
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

        private void comboBoxSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualitzarAforamentMaxim();
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
            if (dataFi < dataInici)
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

            // Comprovar si hi ha conflicte amb altres esdeveniments
            if (verificaDisponibilitat(salaID, dataInici, dataFi))
            {
                MessageBox.Show("Ja hi ha un esdeveniment programat en aquesta sala per a aquesta franja horària.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                // Inserció de l'esdeveniment
                string query = "INSERT INTO Esdeveniments (Nom, Descripcio, SalaID, DataInici, DataFi, Aforament, OrganitzadorID, Estat, DePagament, Preu, EntradesDisp) " +
                               "VALUES (@Nom, @Descripcio, @SalaID, @DataInici, @DataFi, @Aforament, @OrganitzadorID, @Estat, @DePagament, @Preu, @Entrades)";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@Nom", textBoxNom.Text);
                command.Parameters.AddWithValue("@Descripcio", textBoxDescripcio.Text);
                command.Parameters.AddWithValue("@SalaID", salaID);
                command.Parameters.AddWithValue("@DataInici", dataInici);
                command.Parameters.AddWithValue("@DataFi", dataFi);
                command.Parameters.AddWithValue("@Aforament", numericUpDownAforament.Value);
                command.Parameters.AddWithValue("@OrganitzadorID", comboBoxOrganitzador.SelectedValue);
                command.Parameters.AddWithValue("@Estat", comboBoxEstat.SelectedItem?.ToString() ?? "Pendent");
                command.Parameters.AddWithValue("@DePagament", checkBoxDePagament.Checked);
                command.Parameters.AddWithValue("@Preu", checkBoxDePagament.Checked ? numericUpDownPreu.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@Entrades", numericUpDownAforament.Value);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Esdeveniment guardat correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut guardar l'esdeveniment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en guardar l'esdeveniment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private bool verificaDisponibilitat(int salaID, DateTime dataInici, DateTime dataFi)
        {
            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT COUNT(*) FROM Esdeveniments " +
                               "WHERE SalaID = @SalaID AND " +
                               "((@DataInici BETWEEN DataInici AND DataFi) OR " +
                               "(@DataFi BETWEEN DataInici AND DataFi) OR " +
                               "(DataInici BETWEEN @DataInici AND @DataFi))";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@SalaID", salaID);
                command.Parameters.AddWithValue("@DataInici", dataInici);
                command.Parameters.AddWithValue("@DataFi", dataFi);

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

    }
}
