using Programare_Clinica.Models;

namespace Programare_Clinica;

public partial class ServiciuEntryPage : ContentPage
{
    public ServiciuEntryPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    async void OnServiciuAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage
        {
            BindingContext = new Serviciu()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ServiciuPage
            {
                BindingContext = e.SelectedItem as Serviciu
            });
        }
    }

}