// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Label.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Classe helper qui traite l'interaction avec les imprimantes de label de Brother
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Helpers
{
    using bpac;

    using LanSoft.DataObjects;

    /// <summary>
    /// Classe helper qui traite l'interaction avec les imprimantes de label de Brother
    /// </summary>
    public static class Label
    {
        /// <summary>
        /// URL qui va diriger vers le profil du joueur sur le QR Code qu'on imprime sur le badge.
        /// </summary>
        /// <remarks>Le {0} doit être présent et être en dernier, précédé d'un signe d'égalité (=)</remarks>
        private const string QrCode = "http://2011.lanets.ca/public_profile.php?uid={0}";

        /// <summary>
        /// URL qui va diriger vers un rickroll tout en gardant la compatibilité de la lecture des ID
        /// </summary>
        private const string QrCodeRickRoll = "http://go.spacebar.ca/nyqrg?id={0}";

        /// <summary>
        /// Imprime un collant avec les informations du participant
        /// </summary>
        /// <param name="id">ID du participant</param>
        /// <param name="nickname">Pseudonyme</param>
        /// <param name="adult">Si le participant est majeur</param>
        /// <param name="clan">Clan à afficher sur le tag</param>
        /// <param name="seat">Nom du siège</param>
        /// <param name="access">Type d'accès</param>
        public static void PrintRick(int id, string nickname, bool adult, string clan, string seat, AccessType access)
        {
            var url = string.Format(QrCodeRickRoll, id);

            var mineur = access == AccessType.Volunteer || access == AccessType.VIP || access == AccessType.Exec || access == AccessType.Sponsor ? string.Empty : "mineur";
            var majeur = access == AccessType.Volunteer || access == AccessType.VIP || access == AccessType.Exec || access == AccessType.Sponsor ? string.Empty : "majeur";

            Print(id.ToString(), nickname, adult ? majeur : mineur, clan, seat, Gamer.GetAccessString(access), url);
        }

        /// <summary>
        /// Imprime un collant avec les informations du participant
        /// </summary>
        /// <param name="id">ID du participant</param>
        /// <param name="nickname">Pseudonyme</param>
        /// <param name="adult">Si le participant est majeur</param>
        /// <param name="clan">Clan à afficher sur le tag</param>
        /// <param name="seat">Nom du siège</param>
        /// <param name="access">Type d'accès</param>
        public static void Print(int id, string nickname, bool adult, string clan, string seat, AccessType access)
        {
            var url = string.Format(QrCode, id);

            var mineur = access == AccessType.Volunteer || access == AccessType.VIP || access == AccessType.Exec || access == AccessType.Sponsor ? string.Empty : "mineur";
            var majeur = access == AccessType.Volunteer || access == AccessType.VIP || access == AccessType.Exec || access == AccessType.Sponsor ? string.Empty : "majeur";

            Print(id.ToString(), nickname, adult ? majeur : mineur, clan, seat, Gamer.GetAccessString(access), url);
        }

        /// <summary>
        /// Imprime un collant avec les informations du participant
        /// </summary>
        /// <param name="id">ID du participant</param>
        /// <param name="nickname">Pseudonyme</param>
        /// <param name="adult">Si le participant est majeur</param>
        /// <param name="clan">Clan à afficher sur le tag</param>
        /// <param name="seat">Nom du siège</param>
        /// <param name="access">Type d'accès</param>
        /// <param name="url">Url du QR Code</param>
        public static void Print(string id, string nickname, string adult, string clan, string seat, string access, string url)
        {
            // Créer l'objet du label
            var label = new bpac.DocumentClass();

            // Ouvrir le template
            label.Open(System.IO.Path.GetFullPath("joueur.lbx")); // CRITIQUEMENT IMPORTANT QUE CE JOUEUR.LBX SE TROUVE AVEC LE SOFTWARE

            // Changer le texte
            label.SetText(1, adult);
            label.SetText(2, seat == string.Empty ? string.Empty : "Siège " + seat);
            label.SetText(3, clan);
            label.SetText(4, nickname);
            label.SetText(5, access.ToUpper());
            label.SetText(0, "# " + id);

            label.SetBarcodeData(0, url); // Code barre

            // Presto!
            label.SetPrinter(Properties.Settings.Default.printer, true);

            label.StartPrint("Label", PrintOptionConstants.bpoDefault);

            label.PrintOut(1, PrintOptionConstants.bpoDefault);

            label.EndPrint();

            label.Close();
        }

        /// <summary>Converti un URL qui vient d'un QR code sur un badge en ID de joueur</summary>
        /// <param name="qr">
        /// Le QR Code lu par le lecteur
        /// </param>
        /// <returns>
        /// Le possible ID du joueur. Null si pas trouvé
        /// </returns>
        public static int? GetIdFromQRUrl(string qr)
        {
            try
            {
                return int.Parse(qr.Remove(0, qr.LastIndexOf("=") + 1));
            }
            catch
            {
                return null;
            }
        }
    }
}
