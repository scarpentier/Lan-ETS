namespace LanSoft.Panels.Caisse
{
    partial class IdentificationRapide
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.caisseRapideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vérifierLidentitéDuParticipantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remettreLidentificationAuParticipantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(35, 63);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(168, 22);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Code barre";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 91);
            this.label1.TabIndex = 5;
            this.label1.Text = "Veuillez scanner le code barre ou entrer le numéro d\'identification unique du jou" +
                "eur et appuyez sur ENTER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LanSoft.Properties.Resources.barcode_scan;
            this.pictureBox1.Location = new System.Drawing.Point(245, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 351);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHelp});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(768, 27);
            this.fillByToolStrip.TabIndex = 10;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caisseRapideToolStripMenuItem,
            this.toolStripSeparator1,
            this.vérifierLidentitéDuParticipantToolStripMenuItem,
            this.remettreLidentificationAuParticipantToolStripMenuItem});
            this.btnHelp.Image = global::LanSoft.Properties.Resources.help_icon;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 24);
            this.btnHelp.Text = "Processus";
            // 
            // caisseRapideToolStripMenuItem
            // 
            this.caisseRapideToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.caisseRapideToolStripMenuItem.Name = "caisseRapideToolStripMenuItem";
            this.caisseRapideToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.caisseRapideToolStripMenuItem.Text = "Caisse rapide";
            this.caisseRapideToolStripMenuItem.Click += new System.EventHandler(this.caisseRapideToolStripMenuItem_Click);
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
            // remettreLidentificationAuParticipantToolStripMenuItem
            // 
            this.remettreLidentificationAuParticipantToolStripMenuItem.Name = "remettreLidentificationAuParticipantToolStripMenuItem";
            this.remettreLidentificationAuParticipantToolStripMenuItem.Size = new System.Drawing.Size(334, 24);
            this.remettreLidentificationAuParticipantToolStripMenuItem.Text = "Remettre l\'identification au participant";
            this.remettreLidentificationAuParticipantToolStripMenuItem.Click += new System.EventHandler(this.remettreLidentificationAuParticipantToolStripMenuItem_Click);
            // 
            // IdentificationRapide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label2);
            this.Name = "IdentificationRapide";
            this.Size = new System.Drawing.Size(768, 412);
            this.Load += new System.EventHandler(this.IdentificationRapide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnHelp;
        private System.Windows.Forms.ToolStripMenuItem caisseRapideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem vérifierLidentitéDuParticipantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remettreLidentificationAuParticipantToolStripMenuItem;
    }
}
