using CultuEspai.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultuEspai
{
    public partial class AddEntrada : Form
    {
        private DatabaseConnection dbConnection;
        private BindingSource bindingSource = new BindingSource();
        private BindingSource esdevenimentsBindingSource = new BindingSource();
        private BindingSource usuarisBindingSource = new BindingSource();
        private List<string> butaquesOcupades = new List<string>();
        private int? usuariID;
        private int? esdevenimentID;
        private string nomUsuari;
        private int maxEntradesPerPers = 4;
        private bool? salaTeCadiresFixes = null;
        public AddEntrada(int? usuariID = null, int? esdevenimentID = null, string nomUsuari = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.usuariID = usuariID;
            this.esdevenimentID = esdevenimentID;
            this.nomUsuari = nomUsuari;
            diseny();
        }
        private void diseny()
        {
            UIHelper.SetRoundedCorners(buttonGuardar, 8);
            UIHelper.SetRoundedCorners(buttonCancelar, 8);
        }

        private void AddEntrada_Load(object sender, EventArgs e)
        {
            if (usuariID != null)
            {
                comboBoxUsuaris.Visible = false;
                labelNomEsdeveniment.Visible = false;

                labelNomUsuari.Text = nomUsuari;
                
                labelDePagament.Visible = false;
                labelPreu.Visible = false;
                labelEntrades.Visible = false;
                numericUpDownQuantitat.Visible = false;
                labelButaques.Visible = false;
                listBoxButaques.Visible = false;

                comboBoxEsdeveniments.Visible = true;

                esdevenimentsBindingSource.DataSource = obtenirEsdevenimentsDisponibles();
                comboBoxEsdeveniments.SelectedIndexChanged -= comboBoxNomEsdeveniment_SelectedIndexChanged;
                comboBoxEsdeveniments.DataSource = esdevenimentsBindingSource;
                comboBoxEsdeveniments.DisplayMember = "Nom";
                comboBoxEsdeveniments.ValueMember = "EsdevenimentID";
                comboBoxEsdeveniments.SelectedIndex = -1;
                comboBoxEsdeveniments.SelectedIndexChanged += comboBoxNomEsdeveniment_SelectedIndexChanged;
            }
            else
            {
                labelNomUsuari.Visible = false;
                comboBoxEsdeveniments.Visible = false;
                comboBoxUsuaris.Visible = true;

                usuarisBindingSource.DataSource = obtenirUsuarisDisponibles();
                comboBoxUsuaris.SelectedIndexChanged -= comboBoxUsuaris_SelectedIndexChanged;
                comboBoxUsuaris.DataSource = usuarisBindingSource;
                comboBoxUsuaris.DisplayMember = "Nom";
                comboBoxUsuaris.ValueMember = "UsuariID";
                comboBoxUsuaris.SelectedIndex = -1;
                comboBoxUsuaris.SelectedIndexChanged += comboBoxUsuaris_SelectedIndexChanged;

                carregarEsdeveniment((int)esdevenimentID);
            }
        }        
        private void carregarEsdeveniment(int esdevenimentID)
        {
            Esdeveniments esdeveniment = carregarDadesEsdevenimentDesdeBBDD(esdevenimentID);
            labelNomEsdeveniment.Text = esdeveniment.Nom;

            Sales sala = carregarDadesSala((int)esdeveniment.SalaID);

            listBoxButaques.Items.Clear();
            listBoxButaques.Visible = true;
            labelButaques.Visible = true;
            numericUpDownQuantitat.Visible = true;
            labelEntrades.Visible = true;

            if (sala.CadiresFixes && !string.IsNullOrEmpty(sala.ButacaMax))
            {
                carregarButaques(sala, esdevenimentID);
            }
            else
            {
                listBoxButaques.Visible = false;
                labelButaques.Visible = false;
                numericUpDownQuantitat.Maximum = maxEntradesPerPers;
            }

            labelDePagament.Visible = false;
            labelPreu.Visible = false;

            if (esdeveniment.DePagament)
            {
                labelDePagament.Visible = true;
                labelPreu.Visible = true;
                labelPreu.Text = esdeveniment.Preu.ToString() + "€ per entrada";
            }

        }
        private Esdeveniments carregarDadesEsdevenimentDesdeBBDD(int? id)
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
                        EntradesDisp = (int)reader["EntradesDisp"],
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
        private Sales carregarDadesSala(int id)
        {
            Sales sala = null;

            try
            {
                dbConnection.OpenConnection();

                string query = "SELECT * FROM Sales WHERE SalaID = @SalaID";

                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                command.Parameters.AddWithValue("@SalaID", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    sala = new Sales
                    {
                        SalaID = (int)reader["SalaID"],
                        Nom = (string)reader["Nom"],
                        Aforament = (int)reader["Aforament"],
                        CadiresFixes = (bool)reader["CadiresFixes"],
                        MetresQuadrats = (int)reader["MetresQuadrats"],
                        ButacaMax = (string)reader["ButacaMax"]
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en carregar la sala: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return sala;
        }
        private void carregarButaques(Sales sala, int esdevenimentID)
        {
            if (sala.CadiresFixes && !string.IsNullOrEmpty(sala.ButacaMax))
            {
                numericUpDownQuantitat.Visible = false;
                labelEntrades.Visible = false;

                char ultimaLletra = sala.ButacaMax[0];
                int ultimNumero = int.Parse(sala.ButacaMax.Substring(1));

                List<string> butaquesGenerades = new List<string>();

                for (char lletra = 'A'; lletra <= ultimaLletra; lletra++)
                {
                    for (int num = 1; num <= ultimNumero; num++)
                    {
                        butaquesGenerades.Add($"{lletra}{num}");
                    }
                }

                butaquesOcupades = obtenirButaquesOcupades(esdevenimentID);

                listBoxButaques.DrawMode = DrawMode.OwnerDrawFixed;
                listBoxButaques.DrawItem -= listBoxButaques_DrawItem;
                listBoxButaques.DrawItem += listBoxButaques_DrawItem;

                listBoxButaques.Items.Clear();
                listBoxButaques.Items.AddRange(butaquesGenerades.ToArray());

                listBoxButaques.DrawMode = DrawMode.OwnerDrawFixed;
                listBoxButaques.DrawItem += new DrawItemEventHandler(listBoxButaques_DrawItem);
            }
        }
        private void listBoxButaques_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string item = listBoxButaques.Items[e.Index].ToString();
            bool ocupada = butaquesOcupades.Contains(item);

            Color textColor = ocupada ? Color.Gray : listBoxButaques.ForeColor;
            Brush textBrush = new SolidBrush(textColor);

            e.DrawBackground();

            Font font = listBoxButaques.Font;
            if (ocupada)
                font = new Font(font, FontStyle.Italic);

            e.Graphics.DrawString(item, font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private List<string> obtenirButaquesOcupades(int esdevenimentID)
        {
            List<string> ocupades = new List<string>();
            string query = "SELECT NumeroButaca FROM Entrades WHERE EsdevenimentID = @EsdevenimentID AND NumeroButaca IS NOT NULL";

            using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
            {
                command.Parameters.AddWithValue("@EsdevenimentID", esdevenimentID);
                dbConnection.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        string[] butaques = reader.GetString(0).Split(',');
                        foreach (string butaca in butaques)
                        {
                            if (!string.IsNullOrWhiteSpace(butaca))
                                ocupades.Add(butaca.Trim());
                        }
                    }
                }

                reader.Close();
                dbConnection.CloseConnection();
            }

            return ocupades;
        }

        private List<Esdeveniments> obtenirEsdevenimentsDisponibles()
        {
            List<Esdeveniments> esdeveniments = new List<Esdeveniments>();

            string query = "SELECT EsdevenimentID, Nom FROM Esdeveniments";

            SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());

            dbConnection.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Esdeveniments esdeveniment = new Esdeveniments
                {
                    EsdevenimentID = reader.GetInt32(0),
                    Nom = reader.GetString(1)
                };

                esdeveniments.Add(esdeveniment);
            }

            reader.Close();
            dbConnection.CloseConnection();

            return esdeveniments;
        }
        private List<Usuaris> obtenirUsuarisDisponibles()
        {
            List<Usuaris> usuaris = new List<Usuaris>();

            string query = "SELECT UsuariID, Nom FROM Usuaris";

            SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());

            dbConnection.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Usuaris usuari = new Usuaris
                {
                    UsuariID = reader.GetInt32(0),
                    Nom = reader.GetString(1)
                };

                usuaris.Add(usuari);
            }

            reader.Close();
            dbConnection.CloseConnection();


            return usuaris;
        }
        private void comboBoxNomEsdeveniment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEsdeveniments.Visible && comboBoxEsdeveniments.SelectedItem != null)
            {
                if (comboBoxEsdeveniments.SelectedValue != null && int.TryParse(comboBoxEsdeveniments.SelectedValue.ToString(), out int esdevenimentSeleccionatID))
                {
                    carregarEsdeveniment(esdevenimentSeleccionatID);
                    esdevenimentID = esdevenimentSeleccionatID;
                }
            }
        }
        private void comboBoxUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUsuaris.SelectedItem != null)
            {
                if (comboBoxUsuaris.SelectedValue != null && int.TryParse(comboBoxUsuaris.SelectedValue.ToString(), out int usuariSeleccionatID))
                {
                    usuariID = usuariSeleccionatID;
                }
            }
        }
        private void listBoxButaques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxButaques.SelectedItem != null)
            {
                string seleccionada = listBoxButaques.SelectedItem.ToString();
                if (butaquesOcupades.Contains(seleccionada))
                {
                    // Desselecciona l'item si està ocupat
                    listBoxButaques.ClearSelected();
                }

            }

            if (listBoxButaques.SelectedItems.Count > maxEntradesPerPers)
            {
                MessageBox.Show($"Només pots seleccionar fins a {maxEntradesPerPers} butaques.");

                int lastIndex = listBoxButaques.SelectedIndices[listBoxButaques.SelectedIndices.Count - 1];
                listBoxButaques.SetSelected(lastIndex, false);
            }
        }        
        private bool comprovarEntrades(int eventID, int userID, int quantitatAfegir)
        {
            string query = "SELECT ISNULL(SUM(Quantitat), 0)  FROM Entrades WHERE EsdevenimentID = @EsdevenimentID AND UsuariID = @UsuariID";

            using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
            {
                command.Parameters.AddWithValue("@EsdevenimentID", eventID);
                command.Parameters.AddWithValue("@UsuariID", userID);

                dbConnection.OpenConnection();
                object result = command.ExecuteScalar();
                dbConnection.CloseConnection();

                int? quantitat = result as int?;

                if (quantitat.HasValue)
                {
                    int entradesExistents = Convert.ToInt32(result);
                    int entradesTotal = entradesExistents + quantitatAfegir;
                    if (entradesExistents > 0)
                    {
                        if (entradesTotal <= maxEntradesPerPers) 
                        {
                            DialogResult resposta = MessageBox.Show(
                                $"L'usuari seleccionat ja té {entradesExistents} entrades per a l'esdeveniment.\nDesitja sumar-ne més?",
                                "Entrades Existents",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (resposta == DialogResult.Yes)
                            {
                                afegirEntrades(eventID, userID, quantitatAfegir);
                                return true;
                            }
                            else return true;
                        }
                        else
                        {
                            MessageBox.Show("Un usuari pot comprar com a màxim " + maxEntradesPerPers + " entrades. El total d'entrades actual son " + entradesTotal + ". Elimina alguna entrada.");
                            return false;
                        }
                    }
                    else
                    {
                        afegirEntrades(eventID, userID, quantitatAfegir);
                        return true;
                    }
                }
                return false;
            }
        }
        private void afegirEntrades(int eventID, int userID, int quantitatAfegir)
        {
            if ((bool)salaTeCadiresFixes)
            {
                afegirButaca(eventID, userID, quantitatAfegir);
            }
            else
            {
                afegirQuantitat(eventID, userID, quantitatAfegir);
            }
        }
        private bool comprovarCadires(int eventID)
        {
            int salaID = -1;

            // Primer: Obtenir la sala de l'esdeveniment
            string querySalaID = "SELECT SalaID FROM Esdeveniments WHERE EsdevenimentID = @EsdevenimentID";
            using (SqlCommand commandSalaID = new SqlCommand(querySalaID, dbConnection.GetConnection()))
            {
                commandSalaID.Parameters.AddWithValue("@EsdevenimentID", eventID);

                dbConnection.OpenConnection();
                object resultSala = commandSalaID.ExecuteScalar();
                dbConnection.CloseConnection();

                if (resultSala != null && resultSala != DBNull.Value)
                {
                    salaID = Convert.ToInt32(resultSala);
                }
                else
                {
                    MessageBox.Show("No s'ha trobat la sala associada a l'esdeveniment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return false;
                }
            }

            // Segon: Comprovar si la sala té cadires fixes
            string queryCadires = "SELECT CadiresFixes FROM Sales WHERE SalaID = @SalaID";
            using (SqlCommand commandCadires = new SqlCommand(queryCadires, dbConnection.GetConnection()))
            {
                commandCadires.Parameters.AddWithValue("@SalaID", salaID);

                dbConnection.OpenConnection();
                object resultCadires = commandCadires.ExecuteScalar();
                dbConnection.CloseConnection();

                if (resultCadires != null && resultCadires != DBNull.Value)
                {
                    return Convert.ToBoolean(resultCadires);
                }
                else
                {
                    MessageBox.Show("No s'ha pogut determinar si la sala té cadires fixes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return false;
                }
            }
        }

        private void afegirButaca(int eventID, int userID, int quantitatAfegir)
        {
            string querySelect = "SELECT Quantitat, NumeroButaca FROM Entrades WHERE EsdevenimentID = @EsdevenimentID AND UsuariID = @UsuariID AND NumeroButaca IS NOT NULL";

            using (SqlCommand commandSelect = new SqlCommand(querySelect, dbConnection.GetConnection()))
            {
                commandSelect.Parameters.AddWithValue("@EsdevenimentID", eventID);
                commandSelect.Parameters.AddWithValue("@UsuariID", userID);

                dbConnection.OpenConnection();
                SqlDataReader reader = commandSelect.ExecuteReader();

                int quantitatActual = 0;
                string butaquesActuals = "";

                if (reader.Read())
                {
                    quantitatActual = Convert.ToInt32(reader["Quantitat"]);
                    butaquesActuals = reader["NumeroButaca"].ToString();
                }
                reader.Close();
                dbConnection.CloseConnection();

                List<string> butaquesSeleccionades = listBoxButaques.SelectedItems.Cast<string>().ToList();
                string novaStringButaques = string.Join(",", butaquesSeleccionades);
                int totalSeleccionades = butaquesSeleccionades.Count;

                int novaQuantitat = quantitatActual + totalSeleccionades;

                if (quantitatActual == 0)
                {
                    // 🔹 INSERT amb les noves butaques
                    if (totalSeleccionades <= maxEntradesPerPers)
                    {
                        string queryInsert = "INSERT INTO Entrades (EsdevenimentID, UsuariID, Quantitat, NumeroButaca) VALUES (@EsdevenimentID, @UsuariID, @Quantitat, @NumeroButaca)";
                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, dbConnection.GetConnection()))
                        {
                            commandInsert.Parameters.AddWithValue("@EsdevenimentID", eventID);
                            commandInsert.Parameters.AddWithValue("@UsuariID", userID);
                            commandInsert.Parameters.AddWithValue("@Quantitat", totalSeleccionades);
                            commandInsert.Parameters.AddWithValue("@NumeroButaca", novaStringButaques);

                            dbConnection.OpenConnection();
                            commandInsert.ExecuteNonQuery();
                            dbConnection.CloseConnection();
                        }
                        MessageBox.Show("Entrades amb butaques afegides correctament.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Superes el límit de {maxEntradesPerPers} entrades per persona.");
                    }
                }
                else
                {
                    // 🔹 UPDATE si no es supera el límit
                    if (novaQuantitat <= maxEntradesPerPers)
                    {
                        string butaquesCombinades = $"{butaquesActuals},{novaStringButaques}";

                        string queryUpdate = "UPDATE Entrades SET Quantitat = @NovaQuantitat, NumeroButaca = @NumeroButaca WHERE EsdevenimentID = @EsdevenimentID AND UsuariID = @UsuariID";
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, dbConnection.GetConnection()))
                        {
                            commandUpdate.Parameters.AddWithValue("@NovaQuantitat", novaQuantitat);
                            commandUpdate.Parameters.AddWithValue("@NumeroButaca", butaquesCombinades);
                            commandUpdate.Parameters.AddWithValue("@EsdevenimentID", eventID);
                            commandUpdate.Parameters.AddWithValue("@UsuariID", userID);

                            dbConnection.OpenConnection();
                            commandUpdate.ExecuteNonQuery();
                            dbConnection.CloseConnection();
                        }
                        MessageBox.Show("Entrades actualitzades correctament.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"No pots afegir tantes butaques. El màxim és {maxEntradesPerPers}.");
                    }
                }
            }
        }

        private void afegirQuantitat(int eventID, int userID, int quantitatAfegir)
        {
            string querySelect = "SELECT Quantitat FROM Entrades WHERE EsdevenimentID = @EsdevenimentID AND UsuariID = @UsuariID AND NumeroButaca IS NULL";

            using (SqlCommand commandSelect = new SqlCommand(querySelect, dbConnection.GetConnection()))
            {
                commandSelect.Parameters.AddWithValue("@EsdevenimentID", eventID);
                commandSelect.Parameters.AddWithValue("@UsuariID", userID);

                dbConnection.OpenConnection();
                object result = commandSelect.ExecuteScalar();
                dbConnection.CloseConnection();

                int quantitatActual = Convert.ToInt32(result);
                int novaQuantitat = quantitatActual + quantitatAfegir;

                if (quantitatActual > 0 && novaQuantitat <= maxEntradesPerPers)
                {
                    // 🔹 Si ja té entrades, fem UPDATE sumant les entrades noves

                    string queryUpdate = "UPDATE Entrades SET Quantitat = @NovaQuantitat WHERE EsdevenimentID = @EsdevenimentID AND UsuariID = @UsuariID AND NumeroButaca IS NULL";

                    using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, dbConnection.GetConnection()))
                    {
                        commandUpdate.Parameters.AddWithValue("@NovaQuantitat", novaQuantitat);
                        commandUpdate.Parameters.AddWithValue("@EsdevenimentID", eventID);
                        commandUpdate.Parameters.AddWithValue("@UsuariID", userID);

                        dbConnection.OpenConnection();
                        commandUpdate.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }
                    MessageBox.Show($"Entrades afegides correctament.");
                    this.Close();
                }
                else if (quantitatAfegir <= maxEntradesPerPers)
                {
                    // 🔹 Si no té entrades, fem INSERT
                    string queryInsert = "INSERT INTO Entrades (EsdevenimentID, UsuariID, Quantitat, NumeroButaca) VALUES (@EsdevenimentID, @UsuariID, @Quantitat, NULL)";

                    using (SqlCommand commandInsert = new SqlCommand(queryInsert, dbConnection.GetConnection()))
                    {
                        commandInsert.Parameters.AddWithValue("@EsdevenimentID", eventID);
                        commandInsert.Parameters.AddWithValue("@UsuariID", userID);
                        commandInsert.Parameters.AddWithValue("@Quantitat", quantitatAfegir);

                        dbConnection.OpenConnection();
                        commandInsert.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }
                    MessageBox.Show($"Entrades afegides correctament.");
                    this.Close();
                }
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (esdevenimentID.HasValue && usuariID.HasValue)
            {
                salaTeCadiresFixes = comprovarCadires((int)esdevenimentID);

                bool entradesAfegides;
                if ((bool)salaTeCadiresFixes)
                {
                    if (listBoxButaques.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Esculli quina butaca vol.", "Butaca requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    entradesAfegides = comprovarEntrades(esdevenimentID.Value, usuariID.Value, listBoxButaques.SelectedItems.Count);
                }
                else
                {
                    entradesAfegides = comprovarEntrades(esdevenimentID.Value, usuariID.Value, (int)numericUpDownQuantitat.Value);
                }
                
                if (entradesAfegides)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Falten dades per continuar. Assegura't que s'ha seleccionat un usuari i un esdeveniment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
