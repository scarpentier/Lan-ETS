// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Printers.cs" company="Lan ETS">
//   Touts droits réservés
// </copyright>
// <summary>
//   Usercontrol qui permet de configurer l'imprimante Brother
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Panels.Config
{
    using System;
    using System.Diagnostics;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    /// <summary>
    /// Usercontrol qui permet de configurer l'imprimante Brother
    /// </summary>
    public partial class Printers : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Printers"/> class.
        /// </summary>
        public Printers()
        {
            InitializeComponent();

            this.RefreshPrinters();
            this.RefreshClient();
        }

        /// <summary>
        /// Dirige vers le téléchargement de l'installation des composantes Brother
        /// </summary>
        private static void DownloadComponents()
        {
            const string Link = "http://dl.dropbox.com/u/164698/bcciw30012.msi";

            var p = new Process { StartInfo = { FileName = "msiexec.exe", Arguments = "/i " + Link + " /passive" } };
            p.Start();
        }

        /// <summary>
        /// Rafraîchit la liste des imprimantes disponibles
        /// </summary>
        private void RefreshPrinters()
        {
            cbPrinters.Items.Clear();

            // Fill the printers combo box
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbPrinters.Items.Add(printer);
            }

            // Select the saved item
            try
            {
                var printer = Properties.Settings.Default.printer;
                cbPrinters.SelectedItem = printer;
            }
            catch
            {
                // L'imprimante existe pas au pire c'est pas vraiment grave
            }
        }

        /// <summary>
        /// Détermine si les composantes Brother sont installées
        /// </summary>
        private void RefreshClient()
        {
            if (Helpers.Prerequisites.IsBrotherClientInstalled())
            {
                pbClientStatus.Image = Properties.Resources.accept;
                lblClientStatus.Text = "Les composantes de l'imprimante sont installées";
                linkLabel1.Visible = false;
            }
            else
            {
                pbClientStatus.Image = Properties.Resources.exclamation;
                lblClientStatus.Text = "Les composantes de l'imprimante ne sont pas installées";
                var result = MessageBox.Show("Les composantes nécessaires à l'impression des billets sont manquants. Voulez-vous les installer maintenant?", "Composant manquant", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    DownloadComponents();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.printer = cbPrinters.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadComponents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPrinters();
            RefreshClient();
        }
    }
}
