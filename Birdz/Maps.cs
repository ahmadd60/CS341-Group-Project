using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using System.Collections.ObjectModel;

// Primary Author : DH
// Reviewer : 
namespace Birdz
{
    class Maps
    {
   
        public ObservableCollection<Pin> SavedPins { get; set; }

        public Maps()
        {
            SavedPins = new ObservableCollection<Pin>();

            void addPin(Pin pin){
                SavedPins.Add(pin);
            }

        }
       
    }
}
