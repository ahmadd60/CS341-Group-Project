using System;
using System.Data;
using Npgsql;

namespace Birdz
{
	public class JournalDatabase
	{
        private const String TABLE = "journal_entries";
        private String cs;
        private Dictionary<String, List<String>> Journal = new Dictionary<String, List<String>>();

		public JournalDatabase()
		{
            var bitHost = "db.bit.io";
            var bitApiKey = "v2_3wVrq_5kEqP6eKMQScKJrfZtfKXd8"; 

            var bitUser = "ahmadd60";
            var bitDbName = $"{bitUser}/Birdz";

            cs = $"Host={bitHost};Username={bitUser};Password={bitApiKey};Database={bitDbName}";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            LoadJournal();
        }

        public void AddEntry(String title, String name, String date, String location, String notes)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"INSERT INTO {TABLE} VALUES ('{title}', '{name}', '{date}', '{location}','{notes}')";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            LoadJournal();
        }

        public bool CheckUniqueTitle(String title)
        {
            return !Journal.ContainsKey(title);
        }

        private void LoadJournal()
        {
            List<String> entry;

            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"SELECT * FROM {TABLE}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();

            Journal.Clear();

            while (reader.Read())
            {
                entry = new List<String>();

                entry.Add(reader[1] as String);
                entry.Add(reader[2] as String);
                entry.Add(reader[3] as String);
                entry.Add(reader[4] as String);

                Journal.Add(reader[0] as String, entry);
            }
        }
	}
}

