namespace LanSoft.Panels.Caisse
{
    using System;
    using System.Windows.Forms;

    public partial class IdentificationRapide : UserControl
    {
        public IdentificationRapide()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si c'est ENTER
            {
                // Faut vérifier l'input
                int id;
                if (int.TryParse(maskedTextBox1.Text,out id))
                {
                    this.AfficheJoueur(id);
                }

                // C'est pte un qr code
                var code = Helpers.Label.GetIdFromQRUrl(maskedTextBox1.Text);

                if (code != null)
                {
                    this.AfficheJoueur((int)code);
                }
            }
        }

        private void AfficheJoueur(int id)
        {
            // Clear and focus textbox
            maskedTextBox1.Text = string.Empty;

            // Show player profile
            var gp = new GamerProfile();
            gp.LoadProfile(id);
            gp.Show();
        }


        private void IdentificationRapide_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Focus();
        }

        private void caisseRapideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Caisse rapide.png";
            System.Diagnostics.Process.Start(link);
        }

        private void vérifierLidentitéDuParticipantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Vérifier l'identité du participant.png";
            System.Diagnostics.Process.Start(link);
        }

        private void remettreLidentificationAuParticipantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath +
                          "\\Resources\\Processus\\Caisses\\Niveau 2\\Remettre l'indentification au participant.png";
            System.Diagnostics.Process.Start(link);
        }
    }
}
