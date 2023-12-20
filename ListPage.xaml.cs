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
        Serviciu selectedServiciu = (ServiciuPicker.SelectedItem as Serviciu);
        slist.ServiciuID = selectedServiciu.ID;
        await App.Database.SaveServiciuListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ServiciuList)BindingContext;
        await App.Database.DeleteServiciuListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramarePage((ServiciuList)
       this.BindingContext)
        {
            BindingContext = new Programare()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetServiciiAsync();
        ServiciuPicker.ItemsSource = (System.Collections.IList)items;
        ServiciuPicker.ItemDisplayBinding = new Binding("ServiciuDetails");

        var serviciul = (ServiciuList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProgramariAsync(serviciul.ID);
    }


}
