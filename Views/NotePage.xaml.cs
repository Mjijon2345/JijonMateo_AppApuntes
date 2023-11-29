namespace JijonMateo_AppApuntes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.MJ_Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.MJ_Date = File.GetCreationTime(fileName);
            noteModel.MJ_Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.MJ_Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.MJ_Filename))
                File.Delete(note.MJ_Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    
}
   

