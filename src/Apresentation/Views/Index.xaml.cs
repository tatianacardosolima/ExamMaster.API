using Maui.MockExam.Apresentation.Views.Users;

namespace Maui.MockExam.Apresentation.Views;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();

        var mocks = new List<Noticia>
            {
                new Noticia { Title = "Notícia 1", Detail = "Conteúdo da notícia 1..." },
                new Noticia { Title = "Notícia 2", Detail = "Conteúdo da notícia 2..." },
                new Noticia { Title = "Notícia 3", Detail = "Conteúdo da notícia 3..." }
            };

        FeedMockExam.ItemsSource = mocks;

    }
    private async void OnCriarSimuladoClicked(object sender, EventArgs e)
    {
        // Navegar para a página de Criar Simulado
        await Navigation.PushAsync(new ManageQuestions.MockExamPage());
    }

    private async void OnPerfilClicked(object sender, EventArgs e)
    {
        // Navegar para a página de Perfil
        await Navigation.PushAsync(new PerfilPage());
    }

    private async void OnFaleConoscoClicked(object sender, EventArgs e)
    {
        // Navegar para a página de Fale Conosco
        await Navigation.PushAsync(new ContactUs.ContactUsPage());
    }

    public class Noticia
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}