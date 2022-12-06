using System;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace Birdz
{
	public class Journal
	{
		private JournalDatabase Database = new JournalDatabase();
		public Journal() {}

		public void AddEntry(String title, String name, String date, String location, String notes)
		{
			title = CheckValidTitle(title);
			name = CheckValidParam(name);
			date = CheckValidDate(date);
			location = CheckValidParam(location);

			Database.AddEntry(title, name, date, location, notes);
		}

		private String CheckValidParam(String param)
		{
			return param.Length > 0 ? param : throw new InvalidJournalEntry();
		}

		private String CheckValidTitle(String title)
		{
			CheckValidParam(title);
			return Database.CheckUniqueTitle(title) ? title : throw new InvalidJournalEntry();
		}

        private String CheckValidDate(String dateString)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dateString);
                return $"{date}";

            }
            catch (Exception e) when (e is FormatException || e is InvalidJournalEntry)
            {
                throw new InvalidJournalEntry();
            }
        }
    }
}

