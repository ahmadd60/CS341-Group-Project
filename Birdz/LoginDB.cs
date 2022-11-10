﻿using System;
using Npgsql;
using System.Data;
using System.Collections.ObjectModel;

namespace Birdz
{
    public class LoginDB
    {
        const String table = "Users";
        String cs;
        Dictionary<string, string> Usernames = new Dictionary<string, string>();

        public LoginDB()
        {
            var bitHost = "db.bit.io";
            var bitApiKey = "v2_3vT6r_3hj5CFNwmiQ9DeintbZMdi3"; 

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
            var sql = $"INSERT INTO {table} VALUES ({username}, {password});";

            using var cmd = new NpgsqlCommand(sql, con);
        }

        public bool VerifyUsernameUnique(String username)
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
