using Programare_Clinica.Models;


namespace Programare_Clinica;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ServiciuList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveServiciuListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ServiciuList)BindingContext;
        await App.Database.DeleteServiciuListAsync(slist);
        await Navigation.PopAsync();
    }

}