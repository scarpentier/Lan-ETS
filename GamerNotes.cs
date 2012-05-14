// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GamerNotes.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Affiche et sauvegarde les notes d'un participant
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft
{
    using System;
    using System.Windows.Forms;

    using LanSoft.DataObjects;

    /// <summary>
    /// Affiche et sauvegarde les notes d'un participant
    /// </summary>
    public partial class GamerNotes : Form
    {
        public GamerNotes()
        {
            InitializeComponent();
        }

        private Gamer _gamer;

        public void LoadPanel(Gamer gamer)
        {
            this._gamer = gamer;

            // Si le joueur n'est pas inscrit à l'évènement, il n'y a pas de notes de disponible (ni possible d'en ajouter)
            if (!gamer.IsUserExist)
            {
                MessageBox.Show("Ce joueur n'est pas encore inscrit à l'évènement. Il doit être inscrit avant de pouvoir ajouter des notes.", "Impossible de lire ou modifier les notes de ce joueur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                txtNotes.Text = gamer.Notes;
                this.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Save the note
            _gamer.Notes = txtNotes.Text;
            this.Close();
        }
    }
}
