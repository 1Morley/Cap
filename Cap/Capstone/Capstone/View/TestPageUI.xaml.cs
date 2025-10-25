namespace Capstone.View;

public partial class TestPageUI : ContentPage
{
	public TestPageUI()
	{
		InitializeComponent();

	}

    private void Test_Page_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    private void Test_Full_Click(object sender, EventArgs e)
    {
        //var thing = DeviceDisplay.Current.MainDisplayInfo;
        var height = Window.Height;
        var width = Window.Width;

        var x = Window.X;
        var y = Window.Y;

        Window.MinimumHeight = height;
        Window.MaximumHeight = height;

        Window.MinimumWidth = width;
        Window.MaximumWidth = width;

        Button thing = (Button)sender;
        thing.Text = $"{x} {y}";
    }
}