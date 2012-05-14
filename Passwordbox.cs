using System;
using System.Windows.Forms;

namespace LanSoft
{
    public partial class Passwordbox : Form
    {
        public bool IsPasswordValid { get; private set; }
        public string User { get { return txtUsername.Text; } }

        public Passwordbox()
        {
            this.IsPasswordValid = false;
            InitializeComponent();
        }

        private void Passwordbox_Load(object sender, EventArgs e)
        {
            this.IsPasswordValid = false;
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Identification();
        }

        private void Identification()
        {
            // TODO: Meilleure façon de stoquer les mots de passe 
            if (txtUsername.Text.ToLower() == "caisse" && txtPassword.Text == "")
            {
                this.IsPasswordValid = true;
                this.Close();
            } else if (txtUsername.Text.ToLower() == "sécurité" && txtPassword.Text == "") {
                this.IsPasswordValid = true;
                this.Close();
            }
            else if (txtUsername.Text.ToLower() == "lanets" && txtPassword.Text == "")
            {
                this.IsPasswordValid = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Le mot de passe que vous avez entré est invalide", "Mot de passe invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Si c'est ENTER
            {
                Identification();
            }
        }

        private void btnForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://forums.lanets.ca/ucp.php?mode=sendpassword");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
