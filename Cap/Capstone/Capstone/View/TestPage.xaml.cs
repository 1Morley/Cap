using System.Diagnostics;
using System.Threading.Tasks;

namespace Capstone;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
	}


    private void Test_Page_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private async void Test_Click(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            {
                DevicePlatform.WinUI, new[]
                {
                    "txt","png","doc","docx"
                }
            },
        });
        //FileResult result = await FilePicker.PickAsync();
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "TEST TEST TEST TEST",
            FileTypes = customFileTypes
        });

        if (result != null)
        {
            var fileName = result.FileName;
            var fullPath = result.FullPath;

            //TestLabel.Text = $"File Name: {fileName}, Full Path: {fullPath}";
            TestLabel.Text = fullPath;


        }
    }

    private async void Test_File_Path(object sender, EventArgs e)
    {
        //string result = Path.GetFileName(TestLabel.Text);

        //TestLabel.Text = result;

        string path = TestLabel.Text;
        if (File.Exists(path))
        {
            string read = File.ReadAllText(path);
            TestLabel.Text = read;


            if (DeviceInfo.Platform == DevicePlatform.WinUI) {

                //Process.Start(new ProcessStartInfo
                //{
                //    FileName = "notepad.exe",
                //    Arguments = path,
                //    UseShellExecute = true
                //});
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });


            }
        }


    }
}