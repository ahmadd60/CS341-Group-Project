namespace Birdz;

public partial class JournalEntry : ContentPage
{
    private Journal Journal = new Journal();

    private String title;
    private String name;
    private String date;
    private String location;
    private String notes;

    public JournalEntry()
	{
		InitializeComponent();
	}

    public JournalEntry(String title, String name, String date, String location, String notes)
    {
        InitializeComponent();

        this.title = title;
        this.name = name;
        this.date = date;
        this.location = location;
        this.notes = notes;

        Title.Text = title;
        Name.Text = name;
        Date.Text = date;
        Location.Text = location;
        Notes.Text = notes;
    }

    public void Save(object sender, EventArgs e)
    {
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