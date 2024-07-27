using Maui.MockExam.Apresentation.Views.Users;

namespace Maui.MockExam.Apresentation.Views;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();

        var mocks = new List<Noticia>
            {
                new Noticia { Title = "Not�cia 1", Detail = "Conte�do da not�cia 1..." },
                new Noticia { Title = "Not�cia 2", Detail = "Conte�do da not�cia 2..." },
                new Noticia { Title = "Not�cia 3", Detail = "Conte�do da not�cia 3..." }
            };

        FeedMockExam.ItemsSource = mocks;

    }
    private async void OnCriarSimuladoClicked(object sender, EventArgs e)
    {
        // Navegar para a p�gina de Criar Simulado
        await Navigation.PushAsync(new ManageQuestions.MockExamPage());
    }

    private async void OnPerfilClicked(object sender, EventArgs e)
    {
        // Navegar para a p�gina de Perfil
        await Navigation.PushAsync(new PerfilPage());
    }

    private async void OnFaleConoscoClicked(object sender, EventArgs e)
    {
        // Navegar para a p�gina de Fale Conosco
        await Navigation.PushAsync(new ContactUs.ContactUsPage());
    }

    public class Noticia
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}