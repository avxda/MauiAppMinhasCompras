using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_desc.Text,
                Quantidade = (int)Convert.ToDouble(txt_qtd.Text),
				Preco = (int)Convert.ToDouble(txt_preco.Text)
            };
			await App.Db.Insert(p);
			await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

        } catch (Exception ex)
		{
			await DisplayActionSheet("Erro", "OK", null, ex.Message);
        }
    }
}