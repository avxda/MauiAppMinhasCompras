using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> Lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();
		list_produtos.ItemsSource = Lista;
    }
	protected async override void OnAppearing()
	{
		List<Produto> tmp = await App.Db.GetAll();
		tmp.ForEach(x => Lista.Add(x));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());

        } catch (Exception ex)
		{
			DisplayAlert("Erro", ex.Message, "OK");
        }

    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;
		Lista.Clear();
        List<Produto> tmp = await App.Db.Search(q);
        tmp.ForEach(x => Lista.Add(x));
    }

private void ToolbarItem_Clicked_Soma(object sender, EventArgs e)
	{
		double soma = Lista.Sum(x => x.Total);
		string msg = $"A soma total é: {soma:C}";
        DisplayAlert("Soma Total", msg, "OK");
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}