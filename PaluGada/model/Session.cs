using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada.model
{
    public static class Session
    {
        public static string ConnectionString { get; } = "Host=junpro.postgres.database.azure.com;Port=5432;Username=junproadmin;Password=Usti12345;Database=palugada";
        // ID pengguna yang sedang login
        public static int UserId { get; set; }

        // Nama pengguna yang sedang login (opsional, jika diperlukan)
        public static string UserName { get; set; }

        // Email pengguna yang sedang login (opsional, jika diperlukan)
        public static string UserEmail { get; set; }

        // Reset session data (opsional, untuk logout atau membersihkan sesi)
        public static void ResetSession()
        {
            UserId = 0;
            UserName = null;
            UserEmail = null;
        }
    }
}
