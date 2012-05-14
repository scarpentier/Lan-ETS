using LanSoft.DataSets;
namespace LanSoft.Panels.Caisse
{
    partial class RechercheJoueur
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechercheJoueur));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lanets2011 = new LanSoft.DataSets.lanets2011();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.searchToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnAfficherTout = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.caisseLenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vérifierLidentitéDuParticipantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirLeDossierDunJoueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payerÀLaPorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choisirUnePlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remettreLidentificationAuParticipantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersTableAdapter = new LanSoft.DataSets.lanets2011TableAdapters.usersTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nicknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clannameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanets2011)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.nicknameDataGridViewTextBoxColumn,
            this.clannameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.usersBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(795, 389);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.lanets2011;
            // 
            // lanets2011
            // 
            this.lanets2011.DataSetName = "lanets2011";
            this.lanets2011.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Location = new System.Drawing.Point(438, 14);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(0, 17);
            this.lblSearchResults.TabIndex = 4;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripLabel,
            this.searchToolStripTextBox,
            this.fillByToolStripButton,
            this.btnAfficherTout,
            this.btnHelp});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(795, 27);
            this.fillByToolStrip.TabIndex = 6;
            this.fillByToolStrip.Text = "fillByToolStrip";
            this.fillByToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fillByToolStrip_ItemClicked);
            // 
            // searchToolStripLabel
            // 
            this.searchToolStripLabel.Name = "searchToolStripLabel";
            this.searchToolStripLabel.Size = new System.Drawing.Size(80, 24);
            this.searchToolStripLabel.Text = "Recherche:";
            // 
            // searchToolStripTextBox
            // 
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.searchToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchToolStripTextBox_KeyPress);
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(36, 24);
            this.fillByToolStripButton.Text = "Go!";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // btnAfficherTout
            // 
            this.btnAfficherTout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAfficherTout.Image = ((System.Drawing.Image)(resources.GetObject("btnAfficherTout.Image")));
            this.btnAfficherTout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAfficherTout.Name = "btnAfficherTout";
            this.btnAfficherTout.Size = new System.Drawing.Size(96, 24);
            this.btnAfficherTout.Text = "Afficher tout";
            this.btnAfficherTout.Click += new System.EventHandler(this.btnAfficherTout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caisseLenteToolStripMenuItem,
            this.toolStripSeparator1,
            this.vérifierLidentitéDuParticipantToolStripMenuItem,
            this.ouvrirLeDossierDunJoueurToolStripMenuItem,
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem,
            this.payerÀLaPorteToolStripMenuItem,
            this.choisirUnePlaceToolStripMenuItem,
            this.remettreLidentificationAuParticipantToolStripMenuItem});
            this.btnHelp.Image = global::LanSoft.Properties.Resources.help_icon;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 24);
            this.btnHelp.Text = "Processus";
            // 
            // caisseLenteToolStripMenuItem
            // 
            this.caisseLenteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.caisseLenteToolStripMenuItem.Name = "caisseLenteToolStripMenuItem";
            this.caisseLenteToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.caisseLenteToolStripMenuItem.Text = "Caisse lente";
            this.caisseLenteToolStripMenuItem.Click += new System.EventHandler(this.caisseLenteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(331, 6);
            // 
            // vérifierLidentitéDuParticipantToolStripMenuItem
            // 
            this.vérifierLidentitéDuParticipantToolStripMenuItem.Name = "vérifierLidentitéDuParticipantToolStripMenuItem";
            this.vérifierLidentitéDuParticipantToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.vérifierLidentitéDuParticipantToolStripMenuItem.Text = "Vérifier l\'identité du participant";
            this.vérifierLidentitéDuParticipantToolStripMenuItem.Click += new System.EventHandler(this.vérifierLidentitéDuParticipantToolStripMenuItem_Click);
            // 
            // ouvrirLeDossierDunJoueurToolStripMenuItem
            // 
            this.ouvrirLeDossierDunJoueurToolStripMenuItem.Name = "ouvrirLeDossierDunJoueurToolStripMenuItem";
            this.ouvrirLeDossierDunJoueurToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.ouvrirLeDossierDunJoueurToolStripMenuItem.Text = "Ouvrir le dossier d\'un joueur";
            this.ouvrirLeDossierDunJoueurToolStripMenuItem.Click += new System.EventHandler(this.ouvrirLeDossierDunJoueurToolStripMenuItem_Click);
            // 
            // accepterLesConditionsÀLaCaisseToolStripMenuItem
            // 
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem.Name = "accepterLesConditionsÀLaCaisseToolStripMenuItem";
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem.Text = "Accepter les conditions à la caisse";
            this.accepterLesConditionsÀLaCaisseToolStripMenuItem.Click += new System.EventHandler(this.accepterLesConditionsÀLaCaisseToolStripMenuItem_Click);
            // 
            // payerÀLaPorteToolStripMenuItem
            // 
            this.payerÀLaPorteToolStripMenuItem.Name = "payerÀLaPorteToolStripMenuItem";
            this.payerÀLaPorteToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.payerÀLaPorteToolStripMenuItem.Text = "Payer à la porte";
            this.payerÀLaPorteToolStripMenuItem.Click += new System.EventHandler(this.payerÀLaPorteToolStripMenuItem_Click);
            // 
            // choisirUnePlaceToolStripMenuItem
            // 
            this.choisirUnePlaceToolStripMenuItem.Name = "choisirUnePlaceToolStripMenuItem";
            this.choisirUnePlaceToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.choisirUnePlaceToolStripMenuItem.Text = "Choisir une place";
            this.choisirUnePlaceToolStripMenuItem.Click += new System.EventHandler(this.choisirUnePlaceToolStripMenuItem_Click);
            // 
            // remettreLidentificationAuParticipantToolStripMenuItem
            // 
            this.remettreLidentificationAuParticipantToolStripMenuItem.Name = "remettreLidentificationAuParticipantToolStripMenuItem";
            this.remettreLidentificationAuParticipantToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.remettreLidentificationAuParticipantToolStripMenuItem.Text = "Remettre l\'identification au participant";
            this.remettreLidentificationAuParticipantToolStripMenuItem.Click += new System.EventHandler(this.remettreLidentificationAuParticipantToolStripMenuItem_Click);
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "#";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 60;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "Prénom";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Nom de famille";
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // nicknameDataGridViewTextBoxColumn
            // 
            this.nicknameDataGridViewTextBoxColumn.DataPropertyName = "nickname";
            this.nicknameDataGridViewTextBoxColumn.HeaderText = "Pseudonyme";
            this.nicknameDataGridViewTextBoxColumn.Name = "nicknameDataGridViewTextBoxColumn";
            this.nicknameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nicknameDataGridViewTextBoxColumn.Width = 120;
            // 
            // clannameDataGridViewTextBoxColumn
            // 
            this.clannameDataGridViewTextBoxColumn.DataPropertyName = "clan_name";
            this.clannameDataGridViewTextBoxColumn.HeaderText = "Clan";
            this.clannameDataGridViewTextBoxColumn.Name = "clannameDataGridViewTextBoxColumn";
            this.clannameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clannameDataGridViewTextBoxColumn.Width = 150;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Courriel";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 225;
            // 
            // RechercheJoueur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RechercheJoueur";
            this.Size = new System.Drawing.Size(795, 419);
            this.Load += new System.EventHandler(this.RechercheJoueur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanets2011)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripLabel searchToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.ToolStripButton btnAfficherTout;
        private System.Windows.Forms.ToolStripDropDownButton btnHelp;
        private System.Windows.Forms.ToolStripMenuItem caisseLenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem vérifierLidentitéDuParticipantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirLeDossierDunJoueurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payerÀLaPorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choisirUnePlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remettreLidentificationAuParticipantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accepterLesConditionsÀLaCaisseToolStripMenuItem;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private lanets2011 lanets2011;
        private DataSets.lanets2011TableAdapters.usersTableAdapter usersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nicknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clannameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
    }
}
