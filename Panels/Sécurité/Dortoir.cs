// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dortoir.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Gère l'entrée et la sortie des participants au dortoir
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Panels.Sécurité
{
    using System;
    using System.Windows.Forms;

    using LanSoft.Helpers;

    /// <summary>Gère l'entrée et la sortie des participants au dortoir</summary>
    public partial class Dortoir : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dortoir"/> class.
        /// </summary>
        public Dortoir()
        {
            InitializeComponent();
        }

        private void searchToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si c'est ENTER
            {
                Search();
            }
        }

        private void Search()
        {
            try
            {
                this.actionsTableAdapter.FillBySearch(lanets2011.actions, "%" + searchToolStripTextBox.Text + "%");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void UpdateNombre()
        {
            lblNombre.Text = this.actionsTableAdapter.CountDortoir().ToString();
            this.actionsTableAdapter.Fill(this.lanets2011.actions);
        }

        private void btnEntreeSortie_Click(object sender, EventArgs e)
        {
            EntreeSortie();
        }

        private void EntreeSortie()
        {
            // J'aurais ben aimé pouvoir logger et garder toutes les entrées et sorties mais la version de MySQL qu'on a d'installé est trop retardé 

            try
            {
                // Parser l'ID du joueur
                int id;
                int.TryParse(txtID.Text, out id);

                if (id == 0)
                {
                    var pid = Helpers.Label.GetIdFromQRUrl(txtID.Text);
                    if (pid != null)
                        id = (int)pid;
                    else
                        return;
                }

                var name = Participants.GetNomFromCode(id);

                // Déterminer si c'est une entrée ou une sortie
                var action = this.actionsTableAdapter.GetLastActionFromUser(id);

                //switch (action)
                //{
                //    case "Entrée":
                //        // Faut le faire sortir
                //        //LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                //        //    String.Format(
                //        //        "INSERT INTO dortoirs (user_id, date_action, action, commentaires) VALUES (@1, '@2', '@3', \"@4\")",
                //        //        id,
                //        //        DateTime.Now.ToLongTimeString(),
                //        //        "Sortie",
                //        //        name));

                //        this.actionsTableAdapter.Insert(id, DateTime.Now, "Sortie", name);
                //        this.actionsTableAdapter.Update(lanets2011);
                //        break;
                //    case "Sortie":
                //    case null:
                //        // Faut le faire entrer
                //        //LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                //        //    String.Format(
                //        //        "INSERT INTO dortoirs (user_id, date_action, action, commentaires) VALUES (@1, '@2', '@3', \"@4\")",
                //        //        id,
                //        //        DateTime.Now.ToLongTimeString(),
                //        //        "Entrer",
                //        //        name));

                //        this.actionsTableAdapter.Insert(id, DateTime.Now, "Entrée", name);
                //        this.actionsTableAdapter.Update(lanets2011);
                //        break;
                //}

                if (this.actionsTableAdapter.IsParticipantDodo(id).ToString() == "0")
                {
                    if (name == null)
                        name = "";

                    // Non: le gamer n'est pas déjà entré
                    actionsTableAdapter.Insert(id, DateTime.Now, "Entrée", name);
                }
                else
                {
                    actionsTableAdapter.DeleteId(id);
                }
                actionsTableAdapter.Update(lanets2011.actions);

                lblParticipant.Text = name;
                this.UpdateNombre();
                txtID.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite.\nDétails de l'erreur: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si c'est ENTER
            {
                EntreeSortie();
            }
        }

        private void btnAfficherTout_Click(object sender, EventArgs e)
        {
            this.actionsTableAdapter.Fill(this.lanets2011.actions);
        }

        private void Dortoir_Load(object sender, EventArgs e)
        {
            UpdateNombre();
            txtID.Focus();
        }

        private void dortoirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string link = Application.StartupPath + "\\Resources\\Processus\\Sécurité\\Dortoirs.png";
            System.Diagnostics.Process.Start(link);
        }

    }
}
