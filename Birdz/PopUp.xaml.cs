using CommunityToolkit.Maui.Views;

namespace Birdz
{
    public partial class PopUp : Popup
    {
        public PopUp()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        void Close_Button(object sender,EventArgs e)
        {
            Close();
        }
        async void Add_Pin(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new EntryInfoPage());
        }
    }
}