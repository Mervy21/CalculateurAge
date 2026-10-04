using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CalculateurAge.ViewModels;
    public class BaseViewModel : INotifyPropertyChanged
    {

        //L"EVENEMENT : Le moteur de blinding s y abonne
        public event PropertyChangedEventHandler? PropertyChanged;

        //Previent la vue qu une propriété a changé
        // ?.: ne fait rien si personne nest abonne
        protected void OnPropertyChanged([CallerMemberName] string nom = null!)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));
        // affecte une valeur et notifie en une seule ligne
        // renvoie tru si la valeur a changé
        protected bool SetField<T>(ref T champ, T valeur, [CallerMemberName] string nom = null!)
        {
            //Garde fou: evite les notifications inutiles
            //et les boucles infinies en mode TwoWay
            if (EqualityComparer<T>.Default.Equals(champ, valeur)) return false;
            champ = valeur;
            OnPropertyChanged(nom);
            return true;
        }
    }