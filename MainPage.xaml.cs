namespace CalculateurAge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       // Gestionnaire appele au clic du button calculer
       //sender=le controle clique;e= donees de l'evenement

        public void onCalculerClicked (object sender, EventArgs e)
        {
            //validation ;on refuse un nom vide
            if(string.IsNullOrWhiteSpace(entryNom.Text))
            {
                DisplayAlert("Erreur", "Entrez un nom", "Ok");
                return;// on sors sans rien calculer
            }
            DateTime d = pickerDate.Date;
            int age = DateTime.Today.Year - d.Year;
            if (d.Date > DateTime.Today.AddYears(-age)) age--;

            lblResultat.Text = $"{entryNom.Text}, vous avez {age} ans";
            lblResultat.IsVisible = true ;
        }
       
    }
}
