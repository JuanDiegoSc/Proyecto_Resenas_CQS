using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp
{
    public static class UIConstants
    {
        public const string OnboardingShown = "onboarding-shown";

        public const string BDFileName = "Datos.db";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.ReadOnly |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                return Path
                    .Combine(FileSystem.AppDataDirectory, BDFileName);

            }

        }
    }

}
