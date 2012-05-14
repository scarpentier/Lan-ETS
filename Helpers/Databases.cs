// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Databases.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Instance de connexion MySQL pour la base de données du Lan ETS
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Database
{
    using System.Configuration;

    using MySql.Data.MySqlClient;

    using SPACEBAR.Database;

    /// <summary>Instance de connexion MySQL pour la base de données du Lan ETS</summary>
    public class lanets2011 : MySQL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="lanets2011"/> class.
        /// </summary>
        public lanets2011()
        {
            this.SQLCon = new MySqlConnection(ConfigurationManager.ConnectionStrings["LanSoft.Properties.Settings.lan2011ConnectionString"].ToString());
        }
    }
}