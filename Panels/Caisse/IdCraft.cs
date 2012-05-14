// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdCraft.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Permet d'imprimer un label complètement custom
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Panels.Caisse
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Permet d'imprimer un label complètement custom
    /// </summary>
    public partial class IdCraft : UserControl
    {
        public IdCraft()
        {
            InitializeComponent();
        }

        private void btnPrintBadge_Click(object sender, EventArgs e)
        {
            Helpers.Label.Print(txtId.Text, txtNickname.Text, txtAdult.Text, txtClan.Text, txtSeat.Text, txtAccess.Text, txtUrl.Text);
        }
    }
}
