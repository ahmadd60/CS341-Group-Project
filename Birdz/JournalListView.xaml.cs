using Javax.Microedition.Khronos.Opengles;
using static Android.Security.Identity.CredentialDataResult;

namespace Birdz;

public partial class JournalListView : ContentPage
{
    Journal Journal = new Journal();
    public JournalListView()
    {
        InitializeComponent();
        JournalEntries.ItemsSource = MauiProgram.Journal.GetEntries();
    }

    public async void AddEntry(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JournalEntry());
    }

    public async void DeleteEntry(object sender, EventArgs e)
    {
        bool wantToDelete = await DisplayAlert("Delete this entry", "Are you sure you want to delete this entry?", "Yes", "No");

        if (wantToDelete)
        {
            Journal.DeleteEntry((Entry)JournalEntries.SelectedItem);
        }

    }

    public async void UpdateEntry(object sender, EventArgs e)
    {
        bool wantToEdit = await DisplayAlert("Update Entry", "Are you sure you want to update this entry?", "Yes", "No");

        Entry selectedEntry = (Entry)JournalEntries.SelectedItem;

        if (wantToEdit)
        {
            Entry hold = (Entry)(JournalEntries.SelectedItem);
            Journal.DeleteEntry(hold);

            await Navigation.PushAsync(new JournalEntry(selectedEntry.Title, selectedEntry.Name, selectedEntry.Date, selectedEntry.Location, selectedEntry.Notes));
        }
    }
}
