namespace CultuEspai
{
    partial class EditChar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.textBoxValChar = new System.Windows.Forms.TextBox();
            this.textBoxNomChar = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.labelValorChar = new System.Windows.Forms.Label();
            this.labelNomChar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(108, 131);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 15;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Location = new System.Drawing.Point(270, 131);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 14;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // dtpData
            // 
            this.dtpData.Enabled = false;
            this.dtpData.Location = new System.Drawing.Point(108, 86);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(237, 20);
            this.dtpData.TabIndex = 13;
            this.dtpData.Value = new System.DateTime(2025, 3, 23, 12, 30, 24, 0);
            // 
            // textBoxValChar
            // 
            this.textBoxValChar.Location = new System.Drawing.Point(108, 53);
            this.textBoxValChar.Name = "textBoxValChar";
            this.textBoxValChar.Size = new System.Drawing.Size(237, 20);
            this.textBoxValChar.TabIndex = 12;
            // 
            // textBoxNomChar
            // 
            this.textBoxNomChar.Location = new System.Drawing.Point(108, 21);
            this.textBoxNomChar.Name = "textBoxNomChar";
            this.textBoxNomChar.Size = new System.Drawing.Size(237, 20);
            this.textBoxNomChar.TabIndex = 11;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelData.Location = new System.Drawing.Point(12, 86);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(53, 22);
            this.labelData.TabIndex = 10;
            this.labelData.Text = "Data:";
            // 
            // labelValorChar
            // 
            this.labelValorChar.AutoSize = true;
            this.labelValorChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorChar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelValorChar.Location = new System.Drawing.Point(12, 53);
            this.labelValorChar.Name = "labelValorChar";
            this.labelValorChar.Size = new System.Drawing.Size(57, 22);
            this.labelValorChar.TabIndex = 9;
            this.labelValorChar.Text = "Valor:";
            // 
            // labelNomChar
            // 
            this.labelNomChar.AutoSize = true;
            this.labelNomChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomChar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNomChar.Location = new System.Drawing.Point(12, 19);
            this.labelNomChar.Name = "labelNomChar";
            this.labelNomChar.Size = new System.Drawing.Size(52, 22);
            this.labelNomChar.TabIndex = 8;
            this.labelNomChar.Text = "Nom:";
            // 
            // EditChar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(357, 166);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.textBoxValChar);
            this.Controls.Add(this.textBoxNomChar);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelValorChar);
            this.Controls.Add(this.labelNomChar);
            this.Name = "EditChar";
            this.Text = "EditChar";
            this.Load += new System.EventHandler(this.EditChar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.TextBox textBoxValChar;
        private System.Windows.Forms.TextBox textBoxNomChar;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelValorChar;
        private System.Windows.Forms.Label labelNomChar;
    }
}