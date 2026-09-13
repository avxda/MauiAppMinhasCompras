namespace MauiAppMinhasCompras.Views;
using MauiAppMinhasCompras.Models;


public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        {
            try
            {
                Produto produto_anexado = (Produto)BindingContext;
                Produto p = new Produto
                {
                    Id = produto_anexado.Id,
                    Name = txt_nome.Text,
                    Description = txt_desc.Text,
                    Quantity = (int)Convert.ToDouble(txt_qtd.Text),
                    Price = (int)Convert.ToDouble(txt_preco.Text),
                    DataCadastro = DataCadastro.Date
                };
                await App.Db.Update(p);
                await DisplayAlert("Sucesso", "Produto atualizado com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayActionSheet("Erro", "OK", null, ex.Message);
            }
        }
    }
}
