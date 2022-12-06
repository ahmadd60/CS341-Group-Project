namespace Birdz;

public partial class JournalEntry : ContentPage
{
    private Journal Journal = new Journal();

	public JournalEntry()
	{
		InitializeComponent();
	}

    public void Save(object sender, EventArgs e)
    {
        String title;
        String name;
        String date;
        String location;
        String notes;

        try
        {
            title = Title.Text;
            name = Name.Text;
            date = Date.Text;
            location = Location.Text;
            notes = Notes.Text;

            Journal.AddEntry(title, name, date, location, notes);

            DisplayAlert("Entry Added!", "", "Ok");
        }
        catch (InvalidJournalEntry)
        {
            DisplayAlert("Invalid parameters", "Make sure all required fields are entered, journal title is unique, and date is valid", "Ok");
        }
    }
}