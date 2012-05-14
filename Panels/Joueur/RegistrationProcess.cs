namespace LanSoft.Panels.Joueur
{
    using System;
    using System.Windows.Forms;
    using LanSoft.DataObjects;

    public partial class RegistrationProcess : UserControl
    {
        private Gamer gamer;

        private bool vip = false;

        public event EventHandler WantsRefresh;

        new public void Load(Gamer gamer)
        {
            this.InitializeComponent();

            this.gamer = gamer;

            btnSelectionPlaceForce.Visible = false;

            // Calcul de ou on est rendu
            // Étape 1 - Inscription sur les forums
            if (!gamer.IsUserExist)
            {
                lblEtape1.Text = "Le joueur n'est pas présent dans la base de donnée";
            }
            else
            {
                pbEtape1.Image = Properties.Resources.success;

                // Étape 2 - Accepter les terms
                // Cette étape n'est pas obligatoire et va seulement produire un warning
                lblEtape2.Visible = true;
                if (!gamer.IsUserAcceptedTerms)
                {
                    lblEtape2.Visible = false;
                    pbEtape2.Image = Properties.Resources.warning;
                    btnAccepterTermes.Visible = true;
                }
                else
                {
                    lblEtape2.Visible = true;
                    pbEtape2.Image = Properties.Resources.success;
                    btnAccepterTermes.Visible = false;
                }

                // Étape 3 - Paiement
                if (!gamer.IsUserTicketPaid && gamer.IsPayingGamer && !vip)
                {
                    pbEtape3.Image = Properties.Resources.warning;

                    // Ça se peut que le paiement soit juste pas passé
                    if (gamer.IsPayingGamer && gamer.IsUserHasTicket &&
                        gamer.TransactionState == TransactionState.Pending)
                    {
                        // Le billet n'est juste pas passé
                        lblEtape3.Visible = true;
                        lblEtape3.Text = string.Format(
                            "La transaction {0} du joueur n'est pas complétée", gamer.TransactionType);
                        llTransactionDetails.Text = "Détails de la transaction";
                        llTransactionDetails.Visible = true;
                        btnForcePorte.Visible = true;
                    }
                    else
                    {
                        groupPayerPorte.Visible = true;
                        btnSetVip.Visible = true;
                    }
                }
                else
                {
                    if (!gamer.IsPayingGamer)
                    {
                        lblEtape3.Text = "Il n'y a pas de paiement pour ce genre d'accès";
                    }
                    groupPayerPorte.Visible = false;
                    btnSetVip.Visible = false;
                    pbEtape3.Image = Properties.Resources.success;
                    lblEtape3.Visible = true;

                    var benefactor = gamer.Benefactor;
                    if (benefactor != null)
                    {
                        // Quelqu'un d'autre a payé pour lui
                        lblEtape3.Text = string.Format("{0} a payé pour ce joueur", benefactor.FullName);
                        llTransactionDetails.Visible = true;
                        llTransactionDetails.Text = string.Format("Plus de détails sur {0}", benefactor.FullName);
                    }
                    else
                    {
                        lblEtape3.Text = string.Format(lblEtape3.Text, gamer.TransactionType);
                    }

                    // Étape 4 - Sélection de la place
                    if (!gamer.IsSeated && gamer.Access == AccessType.GamerBYOC)
                    {
                        btnSelectionPlace.Visible = true;
                        pbEtape4.Image = Properties.Resources.warning;
                    }
                    else
                    {
                        if (gamer.Access != AccessType.GamerBYOC && !gamer.IsSeated)
                        {
                            lblEtape4.Text = "Il n'y a pas de place assise pour ce genre d'accès";
                            pbEtape4.Image = Properties.Resources.success;
                            btnSelectionPlaceForce.Visible = true;
                            lblEtape4.Visible = true;
                        }
                        else
                        {
                            btnSelectionPlace.Visible = false;
                            pbEtape4.Image = Properties.Resources.success;
                            lblEtape4.Visible = true;

                            btnSelectionPlaceForce.Visible = true;
                            btnSelectionPlaceForce.Text = "Changer de place";

                            // C'est quoi sa place?
                            lblEtape4.Text = string.Format("Le joueur a choisi la place {0}", gamer.SeatName);
                        }

                    }

                    // Étape 5 - Impression de la badge
                    if (!gamer.IsLoggedIn)
                    {
                        btnImprimerBadge.Visible = true;
                        btnFinish.Visible = true;
                    }
                    else
                    {
                        pbEtape5.Image = Properties.Resources.success;
                        lblEtape5.Visible = true;
                        btnFinish.Visible = false;
                        btnImprimerBadge.Visible = false;
                        btnRePrint.Visible = true;
                    }
                }
            }
        }

        private void btnSelectionPlace_Click(object sender, EventArgs e)
        {
            string link = "http://lanets.ca/floorplan.php?userId=" + gamer.UserId;
            System.Diagnostics.Process.Start(link);
        }

        new private void Refresh()
        {
            WantsRefresh(this, null);
            var gamer = new Gamer(this.gamer.UserId);
            Load(gamer);
        }

        private void btnImprimerBadge_Click(object sender, EventArgs e)
        {
            var keys = ModifierKeys;

            var result = MessageBox.Show("Veuillez vérifier l'âge de la personne. Les informations sont-elles correctes?", "Vérification de l'âge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (keys == Keys.Shift)
                {
                    Helpers.Label.PrintRick(gamer.UserId, gamer.Nickname, gamer.IsAdult, gamer.Clan, gamer.SeatName, (AccessType)this.gamer.Access);
                }
                else
                {
                    Helpers.Label.Print(
                        gamer.UserId,
                        gamer.Nickname,
                        gamer.IsAdult,
                        gamer.Clan,
                        gamer.SeatName,
                        (AccessType)this.gamer.Access);
                }
            }
            else
            {
                MessageBox.Show("Le joueur doit changer lui-même sa date de naissance avant de pouvoir poursuivre.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.gamer.IsLoggedIn = true;

            pbEtape5.Image = Properties.Resources.success;
            lblEtape5.Visible = true;
            btnFinish.Visible = false;
            btnImprimerBadge.Visible = false;
            btnRePrint.Visible = true;
        }

        private void pbEtape1_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Caisse lente.png";
            System.Diagnostics.Process.Start(link);
        }

        private void pbEtape2_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Accepter les conditions à la caisse.png";
            System.Diagnostics.Process.Start(link);
        }

        private void pbEtape3_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Payer à la porte.png";
            System.Diagnostics.Process.Start(link);
        }

        private void pbEtape4_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Choisir une place.png";
            System.Diagnostics.Process.Start(link);
        }

        private void pbEtape5_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Caisses\\Niveau 2\\Remettre l'indentification au participant.png";
            System.Diagnostics.Process.Start(link);
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            var keys = ModifierKeys;
            
            if (keys == Keys.Shift)
            {
                Helpers.Label.PrintRick(gamer.UserId, gamer.Nickname, gamer.IsAdult, gamer.Clan, gamer.SeatName, (AccessType)this.gamer.Access);
            }
            else
            {
                Helpers.Label.Print(
                    gamer.UserId,
                    gamer.Nickname,
                    gamer.IsAdult,
                    gamer.Clan,
                    gamer.SeatName,
                    (AccessType)this.gamer.Access);
            }
        }

        private void btnAccepterTermes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Est-ce que le joueur accepte les termes et conditions du Lan ETS?", "Acceptation des conditions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                gamer.IsUserAcceptedTerms = true;
                lblEtape2.Visible = true;
                pbEtape2.Image = Properties.Resources.success;
                btnAccepterTermes.Visible = false;
            }
        }

        private void btnSelectionPlaceForce_Click(object sender, EventArgs e)
        {
            var link = "http://lanets.ca/floorplan.php?userId=" + gamer.UserId.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void btnPaiementBYOC_Click(object sender, EventArgs e)
        {
            // Fenêtre de confirmation
            DialogResult result = MessageBox.Show("Le paiement à la porte est de 55$", "Paiement à la porte", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                gamer.AddTicketBYOC();
                Refresh();
            }
        }

        private void btnPaiementConsole_Click(object sender, EventArgs e)
        {
            // Fenêtre de confirmation
            DialogResult result = MessageBox.Show("Le paiement à la porte est de 25$", "Paiement à la porte", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                gamer.AddTicketConsole();
                Refresh();
            }
        }

        private void btnPaiementAccompagnateur_Click(object sender, EventArgs e)
        {
            // Fenêtre de confirmation
            DialogResult result = MessageBox.Show("Le paiement à la porte est de 10$", "Paiement à la porte", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                gamer.AddTicketAccompagnateur();
                Refresh();
            }
        }

        private void llTransactionDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.gamer.Benefactor == null)
            {
                var link = "http://2011.lanets.ca/admin_useredit.php?uid=" + gamer.UserId;
                System.Diagnostics.Process.Start(link);
            }
            else
            {
                var gp = new GamerProfile();
                gp.LoadProfile(this.gamer.Benefactor.UserId);
                gp.Show();
            }
        }

        private void btnForcePorte_Click(object sender, EventArgs e)
        {
            btnForcePorte.Visible = false;
            groupPayerPorte.Visible = true;
            btnSetVip.Visible = true;
            lblEtape3.Visible = false;
            llTransactionDetails.Visible = false;
        }

        /// <summary>
        /// Quand on clique sur le piton "Entrée VIP"
        /// </summary>
        private void btnSetVip_Click(object sender, EventArgs e)
        {
            // Petit conseil d'ami
            MessageBox.Show("N'oubliez pas d'entrer un commentaire.", "Entrée VIP", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Réponse UI
            pbEtape3.Image = Properties.Resources.success;
            btnForcePorte.Visible = false;
            groupPayerPorte.Visible = false;
            btnSetVip.Visible = false;
            lblEtape3.Text = "Le participant est VIP";
            lblEtape3.Visible = true;
            llTransactionDetails.Visible = false;

            // Réponse backend
            vip = true;
            this.Refresh();
        }
    }
}
