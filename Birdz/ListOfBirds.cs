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
            ImageUrl = "scarybird.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Wren",
            Color = "Brown",
            ImageUrl = "scarybird.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Blue Footed Boobie",
            Color = "Blue",
            ImageUrl = "scarybird.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Robin",
            Color = "Red",
            ImageUrl = "scarybird.jpeg"
        });
        BirdList.Add(new BirdInfo()
        {
            BirdName = "Blue Jay",
            Color = "Blue",
            ImageUrl = "scarybird.jpeg"
        });

    }
}
