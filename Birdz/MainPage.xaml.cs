namespace Birdz;

// Primary Author : DH
// Reviewer : AR
public partial class MainPage : Microsoft.Maui.Controls.ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    public class BirdInfo
    {
        public string BirdName { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
    }



}


