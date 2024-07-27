namespace Maui.MockExam.Apresentation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Index());
        }
    }
}
