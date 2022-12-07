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
   
        public ObservableCollection<Pin> savedPins { get; set; }

        public Maps()
        {
            savedPins = new ObservableCollection<Pin>();

            void addPin(Pin pin){
                savedPins.Add(pin);
            }

        }
       
    }
}
