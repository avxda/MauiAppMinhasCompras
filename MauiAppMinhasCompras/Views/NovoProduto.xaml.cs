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
			Produto produto_anexado = BindingContext as Produto;
            Produto p = new Produto
			{
				Id = produto_anexado?.Id ?? 0,
                Name = txt_nome.Text,
                Description = txt_desc.Text,
                Quantity = (int)Convert.ToDouble(txt_qtd.Text),
                DataCadastro = DataCadastro.Date,
                Price = (int)Convert.ToDouble(txt_preco.Text)
            };
			await App.Db.Insert(p);
			await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");
			await Navigation.PopAsync();
        } catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}