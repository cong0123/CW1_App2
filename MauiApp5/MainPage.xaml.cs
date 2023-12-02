using System.Collections.ObjectModel;

namespace MauiApp5;

public partial class MainPage : ContentPage
{
    int count = 0;
    App thisApp = Microsoft.Maui.Controls.Application.Current as App;
    private MySQLiteDatabase Hiking_trip;
    public MainPage()
    {
        InitializeComponent();
       


        thisApp.HikeList = new ObservableCollection<Hike>();
        Hiking_trip = new MySQLiteDatabase();
    }
    private async void btnSubmit_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Confirmation", "Do you want to submit?", "OK", "Cancel");
        if (response)
        {
            Hike p = new Hike(count++,
                this.txtName.Text,
                this.txtLength.Text,
                this.dtpDate.Date,
                this.swtPA.SelectedItem.ToString(),
                this.cbxLevel.SelectedItem.ToString(),
                this.txtLocation.Text,
                this.txtDescriptions.Text);
            thisApp.HikeList.Add(p);
            Hiking_trip.insertHike(p);
            await DisplayAlert("Information", "Information submitted", "OK");
        }
        SemanticScreenReader.Announce(btnSubmit.Text);

        Navigation.PushModalAsync(new HikeList(), true);


    }
    private void btnView_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new HikeList(), true);
    }
    private void btnLoad_Hiking_Clicked(object sender, EventArgs e)
    {
        thisApp.HikeList = Hiking_trip.loadHike();
    }

}

