using System.Collections.ObjectModel;

namespace Birdz;

public class ListOfBirds
{
    public ObservableCollection<BirdInfo> BirdList { get; set; }
    public ListOfBirds()
    {
        BirdList = new ObservableCollection<BirdInfo>();
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Eagle",
            Color = "White",
            ImageUrl = "birdzmascot.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Wren",
            Color = "Brown",
            ImageUrl = "birdzmascot.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Blue Footed Boobie",
            Color = "Blue",
            ImageUrl = "birdzmascot.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Robin",
            Color = "Red",
            ImageUrl = "birdzmascot.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Blue Jay",
            Color = "Blue",
            ImageUrl = "birdzmascot.jpeg"
        });

    }
}
