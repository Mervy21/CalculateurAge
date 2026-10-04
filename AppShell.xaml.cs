using CalculateurAge.Views;
namespace CalculateurAge
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Declare la route: sans cette ligne , GoToAsync
            //leve une exception "Route inconue"
            Routing.RegisterRoute(nameof(Views.ResultatPage), typeof(Views.ResultatPage));
        }
    }
}
