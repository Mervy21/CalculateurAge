using CalculateurAge.ViewModels;
namespace CalculateurAge;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        //objet dans le quel tout les {binding} de la page vont chercher leur valeur
        BindingContext = new CalculateurViewModel();
    }
}
