using Programare_Clinica.Models;

namespace Programare_Clinica;

public partial class ServiciuPage : ContentPage
{
	public ServiciuPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(shop);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(serviciu);
        await Navigation.PopAsync();
    }
}