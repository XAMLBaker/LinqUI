using System.Windows;
using System.Windows.Media;

[assembly: System.Reflection.Metadata.MetadataUpdateHandler (typeof (LinqUI.WPF.HotReload.HotReloadManager))]
namespace LinqUI.WPF.HotReload;

public static class HotReloadManager
{
    private static bool _isEnabled = false;

    /// <summary>
    /// Hot Reload 활성화 상태
    /// </summary>
    public static bool IsEnabled => _isEnabled;

    /// <summary>
    /// Hot Reload를 활성화합니다.
    /// </summary>
    public static void Enable()
    {
        _isEnabled = true;
        Console.WriteLine ("🔥 Hot Reload 활성화!");
    }

    /// <summary>
    /// Hot Reload를 비활성화합니다.
    /// </summary>
    public static void Disable()
    {
        _isEnabled = false;
        Console.WriteLine ("❄️ Hot Reload 비활성화!");
    }

    public static void ClearCache(Type[]? types)
    {
        Console.WriteLine ("ClearCache");
    }

    public static void UpdateApplication(Type[]? types)
    {
        if (!_isEnabled)
        {
            Console.WriteLine ("⏸️ Hot Reload 비활성화 상태 - 업데이트 무시");
            return;
        }

        Application.Current.Dispatcher.Invoke (() =>
        {
            // 열려 있는 모든 Window 대상으로 처리
            foreach (Window window in Application.Current.Windows)
            {
                if (window is IRender windowBuildable)
                {
                    windowBuildable.Render ();
                }

                foreach (var component in window.FindVisualChildren<FrameworkElement> ().OfType<IRender> ())
                {
                    var type = component.GetType ();
                    if (types.Contains (type))
                    {
                        component.Render (); // 기존 객체 유지, UI만 갱신
                    }
                }
            }
        });
    }

    public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null)
            yield break;

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount (depObj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild (depObj, i);

            if (child is T t)
                yield return t;

            foreach (T childOfChild in FindVisualChildren<T> (child))
                yield return childOfChild;
        }
    }
}
