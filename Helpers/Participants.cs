namespace LanSoft.Helpers
{
    /// <summary>
    /// Classe helper qui parse des informations des participants
    /// </summary>
    public static class Participants
    {
        /// <summary>
        /// Retourne le nom complet d'un participant à partir de son code barre.
        /// </summary>
        /// <param name="code">Code barre</param>
        /// <returns>Nom du participant</returns>
        public static string GetNomFromCode(int code)
        {
            var data = new DataSets.lanets2011TableAdapters.usersTableAdapter();
            return data.GetNom(code);
        }
    }
}
