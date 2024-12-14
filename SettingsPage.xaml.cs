namespace noteApp;

public partial class SettingsPage : ContentPage
{
    private Button _activebutton;
	public SettingsPage()
	{
		InitializeComponent();

        _activebutton = timesnewromanButton;
        timesnewromanButton.BackgroundColor = (Color)Application.Current.Resources["ActiveButtonBackgroundColor"];
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        App.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void arialButton_Clicked(object sender, EventArgs e)
    {
        ChangeAppFont("Arial", sender as Button);
    }

    private void timesnewromanButton_Clicked(object sender, EventArgs e)
    {
        ChangeAppFont("Times New Roman", sender as Button);
    }

    private void garamondButtonn_Clicked(object sender, EventArgs e)
    {
        ChangeAppFont("Garamond", sender as Button);
    }
    private void ChangeAppFont(string fontFamily, Button clickedButton)
    {
        Application.Current.Resources["AppFontStyle"] = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.FontFamilyProperty, Value = fontFamily }
            }
        };

        if (_activebutton != null)
            _activebutton.BackgroundColor = (Color)Application.Current.Resources["DefaultButtonBackgroundColor"];

        clickedButton.BackgroundColor = (Color)Application.Current.Resources["ActiveButtonBackgroundColor"];
        _activebutton = clickedButton;
    }

    private async void recentButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeletedNotesPages());
    }

    private async void backButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}