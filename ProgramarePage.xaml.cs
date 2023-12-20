using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Programare_Clinica.Models;


namespace Programare_Clinica;

public partial class ProgramarePage : ContentPage
{
    ServiciuList sl;
    public ProgramarePage(ServiciuList slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var programare = (Programare)BindingContext;
        await App.Database.SaveProgramareAsync(programare);
        listView.ItemsSource = await App.Database.GetProgramariAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var programare = (Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(programare);
        listView.ItemsSource = await App.Database.GetProgramariAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProgramariAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Programare p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Programare;
            var lp = new ListProgramare()
            {
                ServiciuListID = sl.ID,
                ProgramareID = p.ID
            };
            await App.Database.SaveListProgramareAsync(lp);
            p.ListProgramari = new List<ListProgramare> { lp };
            await Navigation.PopAsync();
        }
    }
}