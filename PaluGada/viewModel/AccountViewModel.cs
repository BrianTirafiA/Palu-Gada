using System.ComponentModel;
using System.Runtime.CompilerServices;
using PaluGada.model;
using Npgsql;

namespace PaluGada.view
{
    public class AccountViewModel : INotifyPropertyChanged
    {
        private string _nama;
        private string _email;

        public string Nama
        {
            get => _nama;
            set
            {
                _nama = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public AccountViewModel()
        {
            using (var conn = new NpgsqlConnection(Session.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT name, email FROM appuser WHERE user_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Session.UserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Nama = reader["name"].ToString();
                            Email = reader["email"].ToString();
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
