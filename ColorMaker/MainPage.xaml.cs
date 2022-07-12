using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorMaker;

public partial class MainPage : ContentPage
{

	bool isRamdon = false;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (isRamdon)
			return;

		var red = sldRed.Value;
		var green = sldGreen.Value;
		var blue = sldBlue.Value;

		Color color = Color.FromRgb(red, green, blue);
		SetColor(color);
	}

	private void SetColor(Color color)
	{		
		Container.BackgroundColor = color;
        imageButton.BackgroundColor = color;
        btnRandom.BackgroundColor = color;

        hexValue = color.ToHex();
		lblHex.Text = hexValue;	
    }

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRamdon = true;

		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;

		isRamdon = false;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color copied", ToastDuration.Short, 12);
		await toast.Show();
	}
}