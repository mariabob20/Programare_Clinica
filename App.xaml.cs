using System;
using Programare_Clinica.Data;
using System.IO;


namespace Programare_Clinica;

public partial class App : Application
{
    static ServiciuListDatabase database;
    public static ServiciuListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ServiciuListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ServiciuList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
