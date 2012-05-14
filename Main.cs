// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Lan ETS">
//   Touts droits réservés
// </copyright>
// <summary>
//   Point d'entré de l'application
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft
{
    using System;
    using System.Windows.Forms;

    /// <summary>Point d'entré de l'application</summary>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>Affiche les nodes dans le menu que le user a le droit de voir</summary>
        /// <param name="user">L'utilisateur (caisse, sécurité, lanets)</param>
        public void LoadUser(string user)
        {
            switch (user.ToLower())
            {
                case "caisse":
                    treeView1.Nodes.RemoveByKey("NodeSecurite");
                    lblUser.Text = "Utilisateur caisse";
                    lblUserAccess.Text = "Caissière";
                    break;
                case "sécurité":
                    treeView1.Nodes.RemoveByKey("NodeCaisse");
                    lblUser.Text = "Utilisateur sécurité";
                    lblUserAccess.Text = "Sécurité";
                    break;
                case "lanets":
                    lblUser.Text = "Administrateur";
                    lblUserAccess.Text = "EXEC";
                    break;
                default:
                    break;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();

            // Show config screen on first run
            if (Properties.Settings.Default.FirstRun)
            {
                ShowPanel(new Panels.Config.Printers());

                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                // Show scan interface
                ShowPanel(new Panels.Caisse.IdentificationRapide());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl uc = null;
            
            switch (e.Node.Name)
            {
                case "IdentificationRapide":
                    uc = new Panels.Caisse.IdentificationRapide();
                    break;
                case "RechercheJoueur":
                    uc = new Panels.Caisse.RechercheJoueur();
                    break;
                case "Dortoirs":
                    uc = new Panels.Sécurité.Dortoir();
                    break;
                case "IdCraft":
                    uc = new Panels.Caisse.IdCraft();
                    break;
                case "Printers":
                    uc = new Panels.Config.Printers();
                    break;
                case "CreateUser":
                    uc = new Panels.Caisse.CreateUser();
                    break;
                default:
                    break;
            }

            this.ShowPanel(uc);
        }

        /// <summary>Affiche un usercontrol dans l'interface</summary>
        /// <param name="uc">Le usercontrol à afficher</param>
        private void ShowPanel(UserControl uc)
        {
            if (uc == null)
            {
                return;
            }

            if (this.panel1.Controls.Count == 1)
            {
                this.panel1.Controls[0].Dispose();
            }

            uc.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(uc);
        }
    }
}
