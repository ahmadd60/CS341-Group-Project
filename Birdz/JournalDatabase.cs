using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using Npgsql;
namespace Birdz
{
	public class JournalDatabase
    {
        private const String TABLE = "journal_entries";
        private String cs;
        public ObservableCollection<Entry> Journal = new ObservableCollection<Entry>();


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
            Entry entry;

            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"INSERT INTO {TABLE} VALUES ('{title}', '{name}', '{date}', '{location}','{notes}')";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();

            entry = new Entry(title, name, date, location, notes);
            Journal.Add(entry);
        }

        public void DeleteEntry(Entry entry)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"DELETE FROM {TABLE} WHERE title = '{entry.Title}'";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            Journal.Remove(entry);
        }

        public void UpdateEntry(Entry entry)
        {

        }

        public bool CheckUniqueTitle(String title)
        {
            for(int i = 0; i < Journal.Count; i++)
            {
                if (Journal[i].Title.Equals(title)) { return false; }
            }

            return true;
        }

        private void LoadJournal()
        {
            Entry entry;
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = $"SELECT * FROM {TABLE}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            Journal.Clear();

            while (reader.Read())
            {
                entry = new Entry(reader[0] as String, reader[1] as String, reader[2] as String, reader[3] as String, reader[4] as String);
                Journal.Add(entry);
            }
        }
	}
}

