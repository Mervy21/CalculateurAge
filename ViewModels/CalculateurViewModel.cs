namespace CalculateurAge.ViewModels;
//contient l'etat de l'ecran et les actiosn possibles
public class CalculateurViewModel : BaseViewModel
{
    //champs privees:la vraie donnee
    private string _nom = "";
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;

    //proprietes publiques: ce que le xaml voit
    public string Nom
    {
        get => _nom;
        set { if (SetField(ref _nom, value)) calculerCommand.Rafraichir(); }
    }
    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }
    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }
    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }
    // Lies a Button.commande dans xaml
    public RelayCommand calculerCommand { get; }

    public CalculateurViewModel()
    {
        calculerCommand = new RelayCommand(Calculer, () =>!string.IsNullOrWhiteSpace(Nom));
    }
    //La logique metier:Aucun controle dinterface ici
    private void Calculer()
    {
        int age= DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date> DateTime.Today.AddYears(-age)) age--;

        Resultat = $"Bonjour {Nom}, vous avez {age} ans.";
        ResultatVisible = true;
    }
}