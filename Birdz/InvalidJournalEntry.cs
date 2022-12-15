using System;
namespace Birdz
{
    [Serializable]
    public class InvalidJournalEntry : Exception
    {
		public InvalidJournalEntry() {}

        public InvalidJournalEntry(string message) : base(message) { }

        public InvalidJournalEntry(string message, Exception inner) : base(message, inner) { }
    }
}

