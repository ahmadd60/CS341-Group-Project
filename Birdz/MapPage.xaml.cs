using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Maps;
using static Microsoft.Maui.Controls.Maps.MapClickedEventArgs;
using Pin = Microsoft.Maui.Controls.Maps.Pin;
using PinType = Microsoft.Maui.Controls.Maps.PinType;

namespace Birdz;
// Primary Author: DH
// Reviewer: AR
public partial class MapPage : Microsoft.Maui.Controls.ContentPage
{
    public MapPage()
    {
        InitializeComponent();

    }
    private static double lat;
    private static double lng;
    static String BirdName;
    static String Brief;

    Maps map = new Maps();
    Pin pin;
    void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        lat = e.Location.Latitude;
        lng = e.Location.Longitude;
        BirdName = bird.Text;
        Brief = brief.Text;
            addPins(lat,lng,BirdName,Brief);
    }

    void addPins(double lat, double lng, String name,String brief)
    {
        pin = new Pin
        {
            Label = name,
            Address = brief,
            Type = PinType.Place,
            Location = new Location(lat, lng)
        };
        mappy.Pins.Add(pin);
        map.SavedPins.Add(pin);
    }

    
}
