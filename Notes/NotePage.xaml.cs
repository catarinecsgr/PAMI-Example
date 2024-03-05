namespace Notes;
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    //Método Construtor
    public NotePage()
    {
        InitializeComponent();
        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(_fileName, TextEditor.Text);
        await DisplayAlert(nameof(NotePage), "Arquivo criado com sucesso", "OK");
    }
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (!File.Exists(_fileName))
        {
            await DisplayAlert("Deletar Arquivo",
                "Arquivo não encontrado",
                "OK");
        }
            File.Delete(_fileName);
        TextEditor.Text = string.Empty;
    }
}