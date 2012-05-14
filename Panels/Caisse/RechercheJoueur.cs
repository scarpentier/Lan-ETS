using System;
using System.Windows.Forms;

namespace LanSoft.Panels.Caisse
{
    public partial class RechercheJoueur : UserControl
    {
        public RechercheJoueur()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the gamer profile pane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Be sure one row is selected
            //if (dataGridView1.SelectedRows.Count != 1)
            //    break;

            var gp = new GamerProfile();
            gp.LoadProfile(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            gp.Show();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                // TODO
                this.usersTableAdapter.FillBy(this.lanets2011.users, "%" + searchToolStripTextBox.Text + "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnAfficherTout_Click(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.lanets2011.users);
        }

        private void searchToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si c'est ENTER
            {
                Search();
            }
        }

        private void RechercheJoueur_Load(object sender, EventArgs e)
        {
            searchToolStripTextBox.Focus();
        }

        private void caisseLenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Caisse lente.png";
            System.Diagnostics.Process.Start(link);
        }

        private void vérifierLidentitéDuParticipantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Vérifier l'identité du participant.png";
            System.Diagnostics.Process.Start(link);
        }

        private void ouvrirLeDossierDunJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Ouvrir le dossier d'un joueur.png";
            System.Diagnostics.Process.Start(link);
        }

        private void payerÀLaPorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Payer à la porte.png";
            System.Diagnostics.Process.Start(link);
        }

        private void choisirUnePlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Choisir une place.png";
            System.Diagnostics.Process.Start(link);
        }

        private void remettreLidentificationAuParticipantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Remettre l'indentification au participant.png";
            System.Diagnostics.Process.Start(link);
        }

        private void accepterLesConditionsÀLaCaisseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Accepter les conditions à la caisse.png";
            System.Diagnostics.Process.Start(link);
        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
