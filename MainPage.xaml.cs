namespace noteApp
{
    public partial class MainPage : ContentPage
    {
        private const string CorrectPin = "1234";
        private string EnteredPin = "";

        public MainPage()
        {
            InitializeComponent();
        }
        private async void getStartButton_Clicked(object sender, EventArgs e)
        {
            if (!PinEntryFrame.IsVisible)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Access Denied", "Please enter the correct PIN first.", "OK");
            }
        }


        private void PinButton_Clicked(object sender, EventArgs e)
        {
            if (EnteredPin.Length < 4)
            {
                Button button = sender as Button;
                EnteredPin += button.Text;

                UpdatePinDisplay();
            }
        }

        private void PinButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (EnteredPin.Length > 0)
            {
                EnteredPin = EnteredPin.Substring(0, EnteredPin.Length - 1);
                UpdatePinDisplay();
            }
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if (EnteredPin == CorrectPin)
            {
                // If PIN is correct, dismiss PIN entry UI
                PinEntryFrame.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Incorrect PIN", "Please try again.", "OK");
                ClearPinFields();
            }
        }
        private void UpdatePinDisplay()
        {
            PinDigit1.Text = EnteredPin.Length > 0 ? "●" : "_";
            PinDigit2.Text = EnteredPin.Length > 1 ? "●" : "_";
            PinDigit3.Text = EnteredPin.Length > 2 ? "●" : "_";
            PinDigit4.Text = EnteredPin.Length > 3 ? "●" : "_";
        }
        private void ClearPinFields()
        {
            EnteredPin = string.Empty;
            UpdatePinDisplay();
        }

    }

}
