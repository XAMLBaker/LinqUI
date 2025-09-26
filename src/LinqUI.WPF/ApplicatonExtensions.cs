namespace LinqUI.WPF
{
    public static partial class ApplicatonExtensions
    {
        public static T ShutdownMode<T>(this T application, ShutdownMode shutdownMode) where T : Application
        {
            application.ShutdownMode = shutdownMode;

            return application;
        }
    }
}
