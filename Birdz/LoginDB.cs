using Npgsql;
//Primary Author: DA
//Reviewer: AR
namespace Birdz
{
    public class LoginDB
    {

        const String table = "users";
        String cs;
        Dictionary<string, string> Usernames = new Dictionary<string, string>();

        public LoginDB()
        {
            var bitHost = "db.bit.io";
            var bitApiKey = "v2_3wVrq_5kEqP6eKMQScKJrfZtfKXd8";

            var bitUser = "ahmadd60";
            var bitDbName = $"{bitUser}/Birdz";

            cs = $"Host={bitHost};Username={bitUser};Password={bitApiKey};Database={bitDbName}";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            Usernames = GetEntries();
        }

        public void AddEntry(String username, String password)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "INSERT INTO users VALUES('duaaahmad', '1234567890');";

            using var cmd = new NpgsqlCommand(sql, con);
        }

        public bool UsernameTaken(String username)
        {
            return !(Usernames.ContainsKey(username));
        }

        private Dictionary<string, string> GetEntries()
        {
            String sql = $"SELECT * FROM \"{table}\"";
            Usernames.Clear();

            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader reader = cmd.ExecuteReader();

            // Columns are clue, answer, difficulty, date, id in that order ...
            // Show all data
            while (reader.Read())
            {
                for (int colNum = 0; colNum < reader.FieldCount; colNum++)
                {
                    Console.Write(reader.GetName(colNum) + "=" + reader[colNum] + " ");
                }
                Console.Write("\n");
                Usernames.Add(reader[0] as String, reader[1] as String);
            }

            con.Close();

            return Usernames;
        }
    }
}

