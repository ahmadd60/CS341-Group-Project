using System.Collections.ObjectModel;
// Primary Author: DH
// Reviewer: AR
namespace Birdz
{
    class ListOfJournals
    {
        public ObservableCollection<JournalEntryClass> JournalList { get; set; }
        public ListOfJournals()
        {
            JournalList = new ObservableCollection<JournalEntryClass>
            {
                new JournalEntryClass()
                {
                    BirdName = "Eagle",
                    JournalTitle = "Pretty Bird",
                    Date = "10/22/22",
                    Entry = "I saw a pretty bird",
                    ImageUrl = "birdzmascot.jpeg"

                },
                new JournalEntryClass()
                {
                    BirdName = "Wren",
                    JournalTitle = "Pretty Bird",
                    Date = "10/22/22",
                    Entry = "I saw a pretty bird",
                    ImageUrl = "birdzmascot.jpeg"
                },
                new JournalEntryClass()
                {
                    BirdName = "Blue Footed Boobie",
                    JournalTitle = "Pretty Bird",
                    Date = "10/22/22",
                    Entry = "I saw a pretty bird",
                    ImageUrl = "birdzmascot.jpeg"
                },
                new JournalEntryClass()
                {
                    BirdName = "Robin",
                    JournalTitle = "Pretty Bird",
                    Date = "10/22/22",
                    Entry = "I saw a pretty bird",
                    ImageUrl = "birdzmascot.jpeg"
                },
                new JournalEntryClass()
                {
                    BirdName = "Blue Jay",
                    JournalTitle = "Pretty Bird",
                    Date = "10/22/22",
                    Entry = "I saw a pretty bird",
                    ImageUrl = "birdzmascot.jpeg"
                }
            };
        }
    }
}
