namespace CalculateurAge.Views;

//Relie le parametre "nom" de l'url a la propriete Nom de la page
[QueryProperty(nameof(Nom), "nom")]
[QueryProperty(nameof(Age), "age")]
public partial class ResultatPage : ContentPage
{
    //ces proprietes sont remplies par la navigation
    //Apres le constructeur
    public string Nom { get; set; }
    public string Age { get; set; }  

    // Contruit larbre visuel decrit par le xaml
        public ResultatPage()=> InitializeComponent();
    //appelle a chaque affichage de la page

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMessage.Text = $"{Nom}, vous avez {Age} ans";
    }

    //".." = revenir a la page precedente
    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}