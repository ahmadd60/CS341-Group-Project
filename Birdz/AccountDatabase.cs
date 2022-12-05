using Npgsql;
using System.Data;

// Primary Author: DA
// Reviewer: AR
namespace Birdz
{
    public class AccountDatabase
    {

        const String table = "users";
        String cs;
        Dictionary<string, string> Usernames = new Dictionary<string, string>();

        public AccountDatabase()
        {
            var bitHost = "db.bit.io";
            var bitApiKey = "v2_3wAsN_6fH5FtrJ45CyhB4Ux8Vim6V";

            var bitUser = "ahmadd60";
            var bitDbName = $"{bitUser}/Birdz";

            cs = $"Host={bitHost};Username={bitUser};Password={bitApiKey};Database={bitDbName}";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            Usernames = InitializeUsernames();
        }



        public void AddEntry(String username, String password)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"INSERT INTO {table} VALUES ('{username}', '{password}');";

            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            con.Close();

            Usernames.Add(username, password);
        }

        public String GetPassword(String username)
        {
            return Usernames[username];
        }

        public bool UsernameExists(String username)
        {
            return !(Usernames.ContainsKey(username));
        }

        public Dictionary<string, string> GetEntries()
        {
            return Usernames;
        }

        private Dictionary<string, string> InitializeUsernames()
        {
            Usernames.Clear();
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = $"SELECT * FROM {table}";

            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            // Show all data
            while (reader.Read())
            {
                Usernames.Add(reader[0] as String, reader[1] as String);
            }

            return Usernames;
        }



        //String sql = $"SELECT * FROM \"{table}\"";
        //Usernames.Clear();

        //using var con = new NpgsqlConnection(cs);
        //con.Open();

        //using var cmd = new NpgsqlCommand(sql, con);

        //using NpgsqlDataReader reader = cmd.ExecuteReader();

        //// Columns are clue, answer, difficulty, date, id in that order ...
        //// Show all data
        //while (reader.Read())
        //{
        //    for (int colNum = 0; colNum < reader.FieldCount; colNum++)
        //    {
        //        Console.Write(reader.GetName(colNum) + "=" + reader[colNum] + " ");
        //    }
        //    Console.Write("\n");
        //    Usernames.Add(reader[0] as String, reader[1] as String);
        //}

        //con.Close();

        //return Usernames;
        //}
    }
}

