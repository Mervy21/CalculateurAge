using System;

namespace CalculateurAge.ViewModels;
//contient l'etat de l'ecran et les actiosn possibles
public class CalculateurViewModel : BaseViewModel
{
    //champs privees:la vraie donnee
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = string.Empty;
    private bool _resultatVisible;
    private string _statusAge = string.Empty;
    private string _joursAvantAnniversaire = string.Empty;

    public RelayCommand EffacerCommand { get; }
    public RelayCommand CalculerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand= new RelayCommand(Calculer, () => !string.IsNullOrWhiteSpace(Nom));
        EffacerCommand = new RelayCommand(Effacer);
    }

    //proprietes publiques: ce que le xaml voit
    public string Nom
    {
        get => _nom;
        set { if (SetField(ref _nom, value)) CalculerCommand.RaiseCanExecuteChanged(); }
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

    public string StatusAge
    {
        get => _statusAge;
        set => SetField(ref _statusAge, value);
    }

    public string JourAvantAnniversaire
    {
        get => _joursAvantAnniversaire;
        set => SetField(ref _joursAvantAnniversaire, value);
    }

    //La logique metier:Aucun controle dinterface ici
    private void Calculer()
    {
        int age= DateTime.Today.Year - DateNaissance.Year;
        if (DateTime.Today.Date < DateNaissance.AddYears(age))
        {
            age--;
        }

        Resultat = $"Bonjour {Nom}, vous avez {age} ans.";
        ResultatVisible = true;

        //Fonctionalite majeur/mineur
        if(age >=18)
        {
            StatusAge = "Vous êtes majeur.";
        }
        else
        {
            StatusAge = "Vous êtes mineur.";
        }

        //Fonctionalite prochain anniversaire
        DateTime prochainAnniversaire;
        try
        {
            prochainAnniversaire = new DateTime(DateTime.Today.Year, DateNaissance.Month, DateNaissance.Day);
        }
        catch
        {
            // Cas particulier pour les anniversaires le 29 février
            prochainAnniversaire = new DateTime(DateTime.Today.Year, 2, 28);
        }
        if(prochainAnniversaire.Date<DateTime.Today.Date)
        {
            prochainAnniversaire = prochainAnniversaire.AddYears(1);
        }
        int jours=(prochainAnniversaire.Date - DateTime.Today.Date).Days;

        JourAvantAnniversaire=$"Il reste {jours} jours avant votre prochain anniversaire.";
    }

    //Fonctionalite effacer
    private void Effacer()
    {
        Nom = string.Empty;
        DateNaissance = DateTime.Today;
        Resultat = string.Empty;
        ResultatVisible = false;
        StatusAge = string.Empty;
        JourAvantAnniversaire = string.Empty;
        CalculerCommand.RaiseCanExecuteChanged();
    }
}