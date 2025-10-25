#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
#endif

using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Capstone
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureLifecycleEvents(events =>
                {
//#if WINDOWS
//    events.AddWindows(w =>
//    {
//        w.OnWindowCreated(window =>
//        {
//            window.ExtendsContentIntoTitleBar = true; //If you need to completely hide the minimized maximized close button, you need to set this value to false.
//            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
//            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
//            var _appWindow = AppWindow.GetFromWindowId(myWndId);
//            _appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
//        });
//    });
//#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
