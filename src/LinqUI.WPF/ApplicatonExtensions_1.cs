using System.Windows.Navigation;
using System.Windows.Threading;

namespace LinqUI.WPF
{
    public static partial class ApplicatonExtensions
    {
        public static T OnActivated<T>(this T application, EventHandler handler) where T : Application
        {
            application.Activated += handler;

            return application;
        }

        public static T OnDeactivated<T>(this T application, EventHandler handler) where T : Application
        {
            application.Deactivated += handler;

            return application;
        }

        public static T OnExit<T>(this T application, ExitEventHandler handler) where T : Application
        {
            application.Exit += handler;

            return application;
        }
        public static T OnFragmentNavigation<T>(this T application, FragmentNavigationEventHandler handler) where T : Application
        {
            application.FragmentNavigation += handler;

            return application;
        }

        public static T OnLoadCompleted<T>(this T application, LoadCompletedEventHandler handler) where T : Application
        {
            application.LoadCompleted += handler;

            return application;
        }

        public static T OnNavigated<T>(this T application, NavigatedEventHandler handler) where T : Application
        {
            application.Navigated += handler;

            return application;
        }
        public static T OnNavigating<T>(this T application, NavigatingCancelEventHandler handler) where T : Application
        {
            application.Navigating += handler;

            return application;
        }
        public static T OnNavigationFailed<T>(this T application, NavigationFailedEventHandler handler) where T : Application
        {
            application.NavigationFailed += handler;

            return application;
        }
        public static T OnNavigationProgress<T>(this T application, NavigationProgressEventHandler handler) where T : Application
        {
            application.NavigationProgress += handler;

            return application;
        }
        public static T OnNavigationStopped<T>(this T application, NavigationStoppedEventHandler handler) where T : Application
        {
            application.NavigationStopped += handler;

            return application;
        }
        public static T OnSessionEnding<T>(this T application, SessionEndingCancelEventHandler handler) where T : Application
        {
            application.SessionEnding += handler;

            return application;
        }

        public static T OnStartup<T>(this T application, StartupEventHandler handler) where T : Application
        {
            application.Startup += handler;

            return application;
        }

        public static T DispatcherUnhandledException<T>(this T application, DispatcherUnhandledExceptionEventHandler handler) where T : Application
        {
            application.DispatcherUnhandledException += handler;
            return application;
        }
    }
}
