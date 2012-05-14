// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gamer.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Classe représentant un Participant dans la logique d'affaire. Contient toutes les données de ce participant et offre un niveau d'abstraction de la base de données.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.DataObjects
{
    using System;
    using System.Web;

    using LanSoft.DataSets.lanets2011TableAdapters;
    using LanSoft.Helpers;

    using SPACEBAR.Patterns.Singleton;

    using lanets2011 = LanSoft.Database.lanets2011;

    /// <summary>
    /// Classe représentant un Participant dans la logique d'affaire. Contient toutes les données de ce participant et offre un niveau d'abstraction de la base de données.
    /// </summary>
    public class Gamer
    {
        /// <summary>
        /// Données du participant
        /// </summary>
        public DataSets.lanets2011 Data { get; private set; }

        #region Scalar

                /// <summary>
        /// ID du Participant sur le forum
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Pseudonyme du participant, tel que spécifié dans le forum du Lan
        /// </summary>
        public string Nickname
        {
            get
            {
                return this.Data.users[0]["nickname"].ToString();
            }

            set
            {
                if (this.Nickname != value)
                {
                    // Lan ETS 2011
                    LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                        "UPDATE users SET nickname = '" + HttpUtility.HtmlEncode(value) + "' WHERE id = " + this.UserId);

                    this.Data.users[0]["nickname"] = value;
                }
            }
        }

        /// <summary>
        /// Prénom du participant
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.Data.users[0]["first_name"].ToString();
            }

            set
            {
                // TODO
            }
        }

        /// <summary>
        /// Nom de famille du participant
        /// </summary>
        public string LastName
        {
            get
            {
                return this.Data.users[0]["last_name"].ToString();
            }

            set
            {
                // TODO
            }
        }

        /// <summary>
        /// Nom complet du participant
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// Nom du clan du participant
        /// </summary>
        public string Clan
        {
            get
            {
                // Si c'est un bénévole, le nom du clan va être son nom complet
                if (this.Access == AccessType.Volunteer) return this.FullName;

                if (this.Access == AccessType.Exec) return this.FullName;

                return this.Data.users[0]["clan_name"].ToString();
            }

            set
            {
                if (this.Clan != value)
                {
                    // TODO
                    // Lan ETS 2010
                    // LazySingleton<lanets2010>.Instance.ExecuteNonQuery("UPDATE participants SET clan = '" + HttpUtility.HtmlEncode(value) + "' WHERE uid = " + UserId.ToString());
                    // _Clan = value;

                    // Lan ETS WCG 2010
                    // Pas possible de changer le nom du clan à partir du software
                }
            }
        }

        /// <summary>
        /// Si le joueur a accepté les termes et conditions
        /// </summary>
        public bool IsUserAcceptedTerms
        {
            get
            {
                // TODO
                return this.Data.users.Rows[0]["termsaccept_timestamp"].ToString() != "0";
            }
            set
            {
                LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                    String.Format(
                        "UPDATE users SET termsaccept_timestamp = {0} WHERE id = {1}", DateTime.Now.ToUnixDate(), this.UserId));

                this.Data.users.Rows[0]["termsaccept_timestamp"] = DateTime.Now.ToUnixDate();
            }
        }

        #endregion

        /// <summary>
        /// Type d'accès du joueur (joueur, vip, exec, media, ...)
        /// </summary>
        public AccessType? Access
        {
            get
            {
                // Si le champ is_volunteer est à true, c'est un bénévole point final
                if (this.Data.users[0]["is_volunteer"].ToString() == "True") return AccessType.Volunteer;

                // On doit vérifier le groupe dont fait parti l'utilisateur
                var groupe = this.Data.users[0]["id_group"].ToString();

                switch (groupe)
                {
                    case "1":
                        return AccessType.Exec;
                    case "2":
                        return AccessType.Sponsor;
                    case "3": case "4":
                        // Ça se peut que l'utilisateur a plusieurs tickets. On va retourner le premier ticket payé

                        for (int i = 0; i < this.Data.tickets.Count; i++)
                        {
                            if (this.Data.tickets[i]["paid"].ToString() == "True")
                            {
                                var ticket = this.Data.tickets[i]["type"].ToString();
                                if (ticket == "1") return AccessType.GamerBYOC;
                                if (ticket == "2") return AccessType.GamerConsole;
                                if (ticket == "3") return AccessType.Accompagnator;
                            }
                        }

                        // TODO: Ça se peut que l'utilisateur soit juste pas payé mais qu'il ait son ticket quand même

                        break;
                    case "5":
                        return AccessType.VIP;
                    case "6":
                        return AccessType.Volunteer;
                }

                // Si y'a rien de ça qui marche, ben y'a pas de ticket,
                return null;
            }
        }

        /// <summary>
        /// Retourne si l'utilisateur existe dans la base de données
        /// </summary>
        public bool IsUserExist
        {
            get
            {
                return this.Data.users.Count > 0;
            }
        }

        /// <summary>
        /// Retounre si l'utilisateur a un ticket
        /// </summary>
        public bool IsUserHasTicket 
        { 
            get
            {
                return this.Data.tickets.Count > 0;
            }
        }

        /// <summary>
        /// Retourne si l'utilisateur a un ticket payé
        /// </summary>
        public bool IsUserTicketPaid
        {
            get
            {
                if (this.IsUserHasTicket)
                {
                    // C'est possible qu'un utilisateur ait plusieurs tickets, on va alors vérifier si y'en a au moins un
                    for (int i = 0; i < this.Data.tickets.Count; i++)
                    {
                        if (this.Data.tickets[i]["paid"].ToString() == "True")
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Retourne si l'utilisateur est un participant qui paie
        /// </summary>
        public bool IsPayingGamer
        {
            get
            {
                var access = this.Access;
                return access == AccessType.GamerBYOC || access == AccessType.GamerConsole ||
                       access == AccessType.Accompagnator || access == null;
            }
        }

        /// <summary>
        /// Retourne l'objet Gamer de la personne qui a payé pour la personne. Null autrement
        /// </summary>
        public Gamer Benefactor
        {
            get
            {
                try
                {
                    // Si quelque chose chie ici, c'est que Rioux a modifié des affaires manuellement (ex: bannir des gens). Dans ce cas, on va retourner null.

                    // C'est possible qu'un utilisateur ait plusieurs tickets, on va alors vérifier si y'en a au moins un
                    for (int i = 0; i < this.Data.tickets.Count; i++)
                    {
                        // Sélectionner le billet payé
                        if (this.Data.tickets[i]["paid"].ToString() == "True")
                        {
                            var transactionId = this.Data.tickets[i]["txn_id"].ToString();

                            var userId =
                                LazySingleton<lanets2011>.Instance.ExecuteScalar(
                                    String.Format(
                                        "SELECT user_id FROM transactions WHERE txn_id = '{0}'", transactionId)).
                                    ToString();

                            // Vérifier si c'est pas le même user
                            if (userId != this.UserId.ToString())
                            {
                                return new Gamer(int.Parse(userId));
                            }
                        }
                    }
                }
                catch
                {
                    // On s'en calisse
                }
                return null;
            }
        }

        /// <summary>
        /// Retourne l'état de la transaction du joueur
        /// </summary>
        public TransactionState? TransactionState
        {
            get
            {
                if (this.Data.transactions.Count == 0) 
                    return null;

                // On va vouloir prendre la dernière transaction effectuée
                var t = this.Data.transactions.Count - 1;

                var state = this.Data.transactions[t]["state"].ToString();

                if (state == "Initialized" || state == "AccesD-Pending" || state == "Pending")
                {
                    return DataObjects.TransactionState.Pending;
                }

                if (state == "AccesD-Completed" || state == "Completed")
                {
                    return DataObjects.TransactionState.Completed;
                }

                return DataObjects.TransactionState.None;
            }
        }

        /// <summary>
        /// Retourne le type de transaction du joueur. Null si il n'y a pas de transaction
        /// </summary>
        public TransactionType? TransactionType
        {
            get
            {
                if (this.Data.transactions.Count == 0)
                {
                    // Si y'a pas de transaction et qu'il a un ticket payé, c'est qu'il a payé cash
                    if (IsUserTicketPaid) return DataObjects.TransactionType.Cash;
                    return null;
                }

                // On va vouloir prendre la dernière transaction effectuée
                var t = this.Data.transactions.Count - 1;

                var type = this.Data.transactions[t]["state"].ToString();
                if (type == "Initialized" || type == "Completed" || type == "Pending")
                    return DataObjects.TransactionType.Paypal;

                if (type == "AccesD-Pending" || type == "AccesD-Completed")
                    return DataObjects.TransactionType.AccesD;

                if (type == "Cash")
                    return DataObjects.TransactionType.Cash;

                return DataObjects.TransactionType.Other;
            }
        }

        /// <summary>
        /// Si le participant est entré au Lan
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return this.Data.users.Rows[0]["checkin_timestamp"].ToString() != "0";
            }
            set
            {
                if (value != IsLoggedIn) // On UPDATE juste dans le cas FALSE -> TRUE
                {
                    LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                        String.Format("UPDATE users SET checkin_timestamp = {0} WHERE id = {1}", DateTime.Now.ToUnixDate(), this.UserId));

                    this.Data.users.Rows[0]["checkin_timestamp"] = DateTime.Now.ToUnixDate();
                }
            }
        }

        /// <summary>
        /// Si le participant est majeur
        /// </summary>
        public bool IsAdult
        {
            get
            {
                return this.Birthday.AddYears(18) < DateTime.Now;
            }
        }

        private int? SeatId
        {
            get
            {
                if (this.Data.seatreservations.Count > 0)
                {
                    return int.Parse(this.Data.seatreservations[0]["seatId"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Nom du siège du joueur (ex: A22)
        /// </summary>
        public string SeatName
        {
            get
            {
                if (this.SeatId != null)
                {
                    return this.Data.seatreferences[0]["Reference"].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Si le participant a sélectionné sa place
        /// </summary>
        public bool IsSeated
        {
            get
            {
                return this.SeatId != null;
            }
        }

        /// <summary>
        /// Date d'anniversaire du participant
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                var strDateNaissance = this.Data.users.Rows[0]["birthday"].ToString().Split('-');

                // Attention la date de fête peut être ""
                if (strDateNaissance[0] == string.Empty)
                {
                    return DateTime.Now;
                }

                var annee = int.Parse(strDateNaissance[2].Trim());
                var mois = int.Parse(strDateNaissance[1].Trim());
                var jour = int.Parse(strDateNaissance[0].Trim());

                // Attention la date de fête peut être 0-0-0
                if (annee == 0 && mois == 0 && jour == 0)
                {
                    return DateTime.Now;
                }

                return new DateTime(annee, mois, jour);
            }
            set
            {
                if (this.Birthday != value) // UPDATE juste si la valeur a changée
                {
                    // Convert to dd-mm-yyyy
                    var date = String.Format(
                        "{0}-{1}-{2}",
                        value.Day < 10 ? "0" + value.Day : value.Day.ToString(),
                        value.Month < 10 ? "0" + value.Month : value.Month.ToString(),
                        value.Year);

                    LazySingleton<lanets2011>.Instance.ExecuteNonQuery(String.Format("UPDATE users SET birthday = '{0}' WHERE id = {1}", date, this.UserId));

                    this.Data.users.Rows[0]["birthday"] = date;
                }
            }
        }

        /// <summary>
        /// Notes ou commentaires sur le participant
        /// </summary>
        public string Notes
        {
            get
            {
                return this.Data.users[0]["commentaires"].ToString();
            }

            set
            {
                if (this.Notes != value)
                {
                    LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                        String.Format(
                            "UPDATE users SET commentaires = \"{0}\" WHERE id = {1};",
                            value.Replace("\"", "\\\""),
                            this.UserId));
                }
            }
        }

        /// <summary>
        /// Constructeur standard qui prend l'ID d'un participant et récupère ses informations
        /// </summary>
        /// <param name="UserId">ID du participant dans le forum</param>
        public Gamer(int UserId)
        {
            this.Load(UserId);
        }

        /// <summary>
        /// Méthode privé qui récupère les informations du participant
        /// </summary>
        /// <param name="userid">ID du participant dans le forum</param>
        private void Load(int userid)
        {
            this.UserId = userid;

            this.Data = new DataSets.lanets2011();

            // Loader le différent data
            new usersTableAdapter().FillById(this.Data.users, this.UserId);
            new ticketsTableAdapter().FillByUserId(this.Data.tickets, this.UserId);
            new transactionsTableAdapter().FillByUserId(this.Data.transactions, this.UserId);
            new seatreservationsTableAdapter().FillByUserId(this.Data.seatreservations, this.UserId);
            if (this.IsSeated)
            {
                new seatreferencesTableAdapter().FillBySeatId(this.Data.seatreferences, (int)this.SeatId);
            }
        }

        public static string GetAccessString(AccessType? accessType)
        {
            switch (accessType)
            {
                case AccessType.GamerBYOC:
                    return "Joueur BYOC";
                case AccessType.GamerConsole:
                    return "Joueur Console";
                case AccessType.Accompagnator:
                    return "Accompagnateur";
                case AccessType.Exec:
                    return "Exec";
                case AccessType.Sponsor:
                    return "Commanditaire";
                case AccessType.VIP:
                    return "VIP";
                case AccessType.Volunteer:
                    return "Bénévole";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Ajoute un ticket BYOC vendu à la porte pour le gamer
        /// </summary>
        public void AddTicketBYOC()
        {
            LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                String.Format("INSERT INTO tickets (user_id, type, paid, commentaires) VALUES ({0}, 1, 1, 'Payé à la porte')", this.UserId));
        }

        /// <summary>
        /// Ajoute un ticket console vendu à la porte pour le gamer
        /// </summary>
        public void AddTicketConsole()
        {
            LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                String.Format("INSERT INTO tickets (user_id, type, paid, commentaires) VALUES ({0}, 2, 1, 'Payé à la porte')", this.UserId));
        }

        /// <summary>
        /// Ajoute un ticket accompagnateur vendu à la porte pour le gamer
        /// </summary>
        public void AddTicketAccompagnateur()
        {
            LazySingleton<lanets2011>.Instance.ExecuteNonQuery(
                String.Format("INSERT INTO tickets (user_id, type, paid, commentaires) VALUES ({0}, 3, 1, 'Payé à la porte')", this.UserId));
        }
    }

    /// <summary>
    /// Types d'accès d'une personne au Lan
    /// </summary>
    public enum AccessType
    {
        /// <summary>Participant qui apporte son ordinateur et qui a une place assise</summary>
        GamerBYOC,

        /// <summary>Participant qui participe aux tournois consoles, sans ordinateur et sans place assise</summary>
        GamerConsole,

        /// <summary>Bénévole</summary>
        Volunteer,

        /// <summary>Exec</summary>
        Exec,

        /// <summary>VIP</summary>
        VIP,

        /// <summary>Participant accompagnateur</summary>
        Accompagnator,

        /// <summary>Autre</summary>
        Other,

        /// <summary>Commanditaire</summary>
        Sponsor
    }

    public enum TransactionType
    {
        Paypal,
        AccesD,
        Cash,
        Other
    }

    public enum TransactionState
    {
        None,
        Pending,
        Completed
    }
}