using System.Windows.Shell;

namespace LinqUI.WPF
{
    public static class WindowExtensions
    {
        public static T AllowsTransparencyProperty<T>(this T window, bool allowsTransparency) where T : Window
        {
            window.SetValue (Window.AllowsTransparencyProperty, allowsTransparency);
            return window;
        }
        public static T WindowStyle<T>(this T window, WindowStyle windowStyle) where T : Window
        {
            window.SetValue (Window.WindowStyleProperty, windowStyle);
            return window;
        }
        public static T Top<T>(this T window, double top) where T : Window
        {
            window.SetValue (Window.TopProperty, top);
            return window;
        }
        public static T Topmost<T>(this T window, bool topMost) where T : Window
        {
            window.SetValue (Window.TopmostProperty, topMost);
            return window;
        }
        public static T Title<T>(this T window, string title) where T : Window
        {
            window.SetValue (Window.TitleProperty, title);
            return window;
        }
        public static T TaskbarItemInfo<T>(this T window, TaskbarItemInfo taskbarItemInfo) where T : Window
        {
            window.SetValue (Window.TaskbarItemInfoProperty, taskbarItemInfo);
            return window;
        }

        public static T SizeToContent<T>(this T window, SizeToContent sizeToContent) where T : Window
        {
            window.SetValue (Window.SizeToContentProperty, sizeToContent);
            return window;
        }
        public static T WindowState<T>(this T window, WindowState windowState) where T : Window
        {
            window.SetValue (Window.WindowStateProperty, windowState);
            return window;
        }
        public static T ShowActivated<T>(this T window, bool showActivated) where T : Window
        {
            window.SetValue (Window.ShowActivatedProperty, showActivated);
            return window;
        }
        public static T ResizeMode<T>(this T window, ResizeMode resizeMode) where T : Window
        {
            window.SetValue (Window.ResizeModeProperty, resizeMode);
            return window;
        }
        public static T Left<T>(this T window, double left) where T : Window
        {
            window.SetValue (Window.LeftProperty, left);
            return window;
        }
        public static T Icon<T>(this T window, ImageSource icon) where T : Window
        {
            window.SetValue (Window.IconProperty, icon);
            return window;
        }
        public static T ShowInTaskbar<T>(this T window, bool showInTaskbar) where T : Window
        {
            window.SetValue (Window.ShowInTaskbarProperty, showInTaskbar);
            return window;
        }
    }
}
