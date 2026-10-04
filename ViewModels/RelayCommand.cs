using System.Windows.Input;
namespace CalculateurAge.ViewModels;
//transforme une methode en objet liable  a un button
public class RelayCommand : ICommand
{
    private readonly Action _execute;//quoi faire
    private readonly Func<bool>? _peutExecute;//si possible
    public RelayCommand(Action execute, Func<bool>? peutExecute = null)
    {
        _execute = execute;
        _peutExecute = peutExecute;
    }
    //le button appelle ceci et se grise si faux
    public bool CanExecute(object p)
        => _peutExecute?.Invoke() ?? true;
    //Execute laction au clic
    public void Execute(object p)
        => _execute();
    public event EventHandler CanExecuteChanged;
    //a appeler pour forcer le button a reposer la question
    public void Rafraichir()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}