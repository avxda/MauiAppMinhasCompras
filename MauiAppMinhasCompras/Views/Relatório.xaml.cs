using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class Relatório : ContentPage
{
	public Relatório()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.Relatório());
    }

        private List<Produto> produtos;

    private async void OnFiltrarClicked(object sender, EventArgs e)
    {
        DateTime inicio = DataInicioPicker.Date;
        DateTime fim = DataFimPicker.Date;

        var produtos = await App.Db.GetAll() ?? new List<Produto>();
        var filtrados = produtos
            .Where(p => p.DataCadastro >= inicio && p.DataCadastro <= fim)
            .ToList();

        ProdutosCollectionView.ItemsSource = filtrados;
    }
}
