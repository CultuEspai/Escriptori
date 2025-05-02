namespace CultuEspai
{
    partial class GestioEsdeveniments
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
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gestioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esdevenimentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.buttonEntrades = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddEvent.Location = new System.Drawing.Point(47, 52);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(75, 25);
            this.buttonAddEvent.TabIndex = 20;
            this.buttonAddEvent.Text = "Add";
            this.buttonAddEvent.UseVisualStyleBackColor = false;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestioToolStripMenuItem,
            this.exitsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(981, 27);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gestioToolStripMenuItem
            // 
            this.gestioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarisToolStripMenuItem,
            this.esdevenimentsToolStripMenuItem});
            this.gestioToolStripMenuItem.Name = "gestioToolStripMenuItem";
            this.gestioToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.gestioToolStripMenuItem.Text = "Gestió";
            // 
            // usuarisToolStripMenuItem
            // 
            this.usuarisToolStripMenuItem.Name = "usuarisToolStripMenuItem";
            this.usuarisToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.usuarisToolStripMenuItem.Text = "Usuaris";
            this.usuarisToolStripMenuItem.Click += new System.EventHandler(this.usuarisToolStripMenuItem_Click);
            // 
            // esdevenimentsToolStripMenuItem
            // 
            this.esdevenimentsToolStripMenuItem.Name = "esdevenimentsToolStripMenuItem";
            this.esdevenimentsToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.esdevenimentsToolStripMenuItem.Text = "Esdeveniments";
            // 
            // exitsToolStripMenuItem
            // 
            this.exitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.exitsToolStripMenuItem.Name = "exitsToolStripMenuItem";
            this.exitsToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.exitsToolStripMenuItem.Text = "Exit";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteEvent.Location = new System.Drawing.Point(858, 52);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(70, 25);
            this.buttonDeleteEvent.TabIndex = 18;
            this.buttonDeleteEvent.Text = "Delete";
            this.buttonDeleteEvent.UseVisualStyleBackColor = false;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonEditEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditEvent.Location = new System.Drawing.Point(138, 52);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(70, 25);
            this.buttonEditEvent.TabIndex = 17;
            this.buttonEditEvent.Text = "Edit";
            this.buttonEditEvent.UseVisualStyleBackColor = false;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            this.dataGridViewEvents.AllowUserToDeleteRows = false;
            this.dataGridViewEvents.AllowUserToResizeRows = false;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(35, 93);
            this.dataGridViewEvents.MultiSelect = false;
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.ReadOnly = true;
            this.dataGridViewEvents.RowHeadersWidth = 47;
            this.dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvents.Size = new System.Drawing.Size(914, 331);
            this.dataGridViewEvents.TabIndex = 16;
            // 
            // buttonEntrades
            // 
            this.buttonEntrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonEntrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrades.Location = new System.Drawing.Point(226, 52);
            this.buttonEntrades.Name = "buttonEntrades";
            this.buttonEntrades.Size = new System.Drawing.Size(70, 25);
            this.buttonEntrades.TabIndex = 21;
            this.buttonEntrades.Text = "Entrades";
            this.buttonEntrades.UseVisualStyleBackColor = false;
            this.buttonEntrades.Click += new System.EventHandler(this.buttonEntrades_Click);
            // 
            // GestioEsdeveniments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(981, 465);
            this.Controls.Add(this.buttonEntrades);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.buttonDeleteEvent);
            this.Controls.Add(this.buttonEditEvent);
            this.Controls.Add(this.dataGridViewEvents);
            this.Name = "GestioEsdeveniments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esdeveniments";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gestioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esdevenimentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonDeleteEvent;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Button buttonEntrades;
    }
}