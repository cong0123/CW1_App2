using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class App : Application
{
    public ObservableCollection<Hike> HikeList;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
