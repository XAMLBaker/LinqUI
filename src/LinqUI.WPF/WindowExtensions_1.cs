using System.ComponentModel;

namespace LinqUI.WPF
{
    public static partial class WindowExtensions
    {
        public static T WindowStartupLocation<T>(this T window, WindowStartupLocation WindowStartupLocation) where T : Window
        {
            window.WindowStartupLocation = WindowStartupLocation;
            return window;
        }

        public static T OnActivated<T>(this T window, EventHandler handler) where T : Window
        {
            window.Activated += handler;
            return window;
        }

        public static T OnClosed<T>(this T window, EventHandler handler) where T : Window
        {
            window.Closed += handler;
            return window;
        }

        public static T OnClosing<T>(this T window, CancelEventHandler handler) where T : Window
        {
            window.Closing += handler;
            return window;
        }

        public static T OnContentRendered<T>(this T window, EventHandler handler) where T : Window
        {
            window.ContentRendered += handler;
            return window;
        }

        public static T OnDeactivated<T>(this T window, EventHandler handler) where T : Window
        {
            window.Deactivated += handler;
            return window;
        }

        public static T OnDpiChanged<T>(this T window, DpiChangedEventHandler handler) where T : Window
        {
            window.DpiChanged += handler;
            return window;
        }

        public static T OnLocationChanged<T>(this T window, EventHandler handler) where T : Window
        {
            window.LocationChanged += handler;
            return window;
        }

        public static T OnSourceInitialized<T>(this T window, EventHandler handler) where T : Window
        {
            window.SourceInitialized += handler;
            return window;
        }

        public static T OnStateChanged<T>(this T window, EventHandler handler) where T : Window
        {
            window.StateChanged += handler;
            return window;
        }
    }
}
