using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using MauiAppMinhasCompras.Views;

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
        try
        {
            Lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(x => Lista.Add(x));
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }

    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
        string q = e.NewTextValue;
        Lista.Clear();
        List<Produto> tmp = await App.Db.Search(q);
        tmp.ForEach(x => Lista.Add(x));
    } catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked_Soma(object sender, EventArgs e)
    {
        double soma = Lista.Sum(x => x.Total);
        string msg = $"A soma total é: {soma:C}";
        DisplayAlert("Soma Total", msg, "OK");
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {

        try
        {
            MenuItem selected = (MenuItem)sender;
            Produto produto = (Produto)selected.BindingContext;
            bool answer = await DisplayAlert("Confirmação", $"Deseja excluir o produto {produto.Name}?", "Sim", "Não");
            if (answer)
                {
                await App.Db.Delete(produto.Id);
                Lista.Remove(produto);
            }

        } catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void list_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto produto = e.SelectedItem as Produto;
            {
                Navigation.PushAsync(new Views.EditarProduto
                {
                    BindingContext = produto,
                });
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}