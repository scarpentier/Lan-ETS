namespace LanSoft
{
    using LanSoft.Panels.Joueur;

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using LanSoft.DataObjects;

    public partial class GamerProfile : Form
    {
        public GamerProfile()
        {
            InitializeComponent();
        }

        private Gamer gamer;

        private RegistrationProcess registrationProcess;

        /// <summary>
        /// Loads the profile of the sent user id
        /// </summary>
        /// <param name="userid">User ID</param>
        public void LoadProfile(int userid)
        {
            this.Text = String.Format(this.Text, userid);

            gamer = new Gamer(userid);

            // Reconstruire le usercontrol
            panel3.Controls.Clear();
            registrationProcess = new RegistrationProcess();
            registrationProcess.WantsRefresh += new EventHandler(registrationProcess_WantsRefresh);
            panel3.Controls.Add(registrationProcess);
            
            registrationProcess.Load(gamer);

            if (gamer.IsUserExist)
            {
                lblNickname.Text = gamer.Nickname;
                lblName.Text = gamer.FullName;

                dtpAdult.Value = gamer.Birthday;
                this.CheckAdult();
                this.CheckNote();

                lblAccess.Text = Gamer.GetAccessString(this.gamer.Access);

                lblClan.Text = gamer.Clan;
            }
        }

        void registrationProcess_WantsRefresh(object sender, EventArgs e)
        {
            this.LoadProfile(this.gamer.UserId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Vérifie si le participant est adulte et ajoute un cue visuel si c'est le cas
        /// </summary>
        private void CheckAdult()
        {
            if (gamer.IsAdult)
            {
                lblAdult.ForeColor = Color.Red;
            }
            else
            {
                lblAdult.ForeColor = Color.Blue;
            }
        }

        /// <summary>
        /// Vérifie si le participant a une note à son dossier et ajoute un cue visuel si c'est le cas
        /// </summary>
        private void CheckNote()
        {
            // Vérifier si on peut ajouter des notes à ce joueur
            if (gamer.IsUserExist)
            {
                if (gamer.Notes != "" && gamer.Notes != "na") // Ben oui, la valeur par défaut dans la BD, c'est "na"
                {
                    // Mettre le font du bouton en gras s'il y a une note associée au joueur
                    btnNotes.Font = new Font(btnNotes.Font.FontFamily, btnNotes.Font.Size, FontStyle.Bold);
                }
            }
        }

        private void dtpAdult_ValueChanged(object sender, EventArgs e)
        {
            gamer.Birthday = dtpAdult.Value;
            CheckAdult();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            var gamerNotes = new GamerNotes();
            gamerNotes.LoadPanel(gamer);
            this.CheckNote();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadProfile(gamer.UserId);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var link = "http://2011.lanets.ca/admin_useredit.php?uid=" + gamer.UserId;
            System.Diagnostics.Process.Start(link);
        }
    }
}
