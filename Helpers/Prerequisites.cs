// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Prerequisites.cs" company="Lan ETS">
//   Touts droits réservés
// </copyright>
// <summary>
//   Aide dans la détection des logiciels et composants 3rd party requis au bon fonctionnement du LanSoft
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Helpers
{
    using System;

    using Microsoft.Win32;

    /// <summary>
    /// Aide dans la détection des logiciels et composants 3rd party requis au bon fonctionnement du LanSoft
    /// </summary>
    public static class Prerequisites
    {
        /// <summary>
        /// Détermine si le Brother b-PAC Client Component est installé
        /// </summary>
        /// <returns>True si il est installé</returns>
        /// <remarks>Ça marche aussi si c'est le SDK</remarks>
        public static bool IsBrotherClientInstalled()
        {
            // The registry key:
            const string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                // Let's go through the registry keys and get the info we need:
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            var value = sk.GetValue("DisplayName");

                            if (value != null)
                            {
                                if (value.ToString() == "b-PAC 3.0 Client Component") return true;

                                if (value.ToString() == "Brother b-PAC3 SDK") return true;
                            }                              
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
            }

            return false;

        }
    }
}
