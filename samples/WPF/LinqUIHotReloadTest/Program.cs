using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinqUI.WPF;
using LinqUI.WPF.HotReload;
using System.Windows;
using System.Windows.Controls;
namespace LinqUIHotReloadTest
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            HotReloadManager.Enable ();
            _ = new Application ()
                    .ShutdownMode (ShutdownMode.OnMainWindowClose)
                    .OnDispatcherUnhandledException((_, e) =>
                    {
                        MessageBox.Show (e.Exception.ToString (), "Unhandled", MessageBoxButton.OK, MessageBoxImage.Error);
                        e.Handled = true;
                    })
                    .Run (new Window ()
                            .WindowStartupLocation (WindowStartupLocation.CenterScreen)
                            .Title ($"Hello, World! - {Thread.CurrentThread.GetApartmentState ()}")
                            .Size (640, 240)
                            .Content ( new MainView()
                                    .DataContext (new CounterViewModel ())));
        }
    }

    public class App : Application
    {

    }

    public class MainView : LinqComponent<CounterViewModel> 
    {
        public override FrameworkElement Build()
            => new StackPanel ()
                    .Orientation (Orientation.Vertical)
                    .Children (
                        new TextBlock ()
                            .Bind (this, tb => tb.Text, vm => vm.Count)
                            .FontSize (24)
                            .Margin (8)
                            .HCenter (),
                        new Button ()
                            .Content ("Increment (+1)")
                            .Margin (8)
                            .BindCommand (this, btn => btn.Command, vm=> vm.IncrementCountCommand),
                        new Button ()
                            .Content ("Decrement (-1)")
                            .Margin (8)
                            .BindCommand (this, btn => btn.Command, vm => vm.DecrementCountCommand)
                    );
    }

    public sealed partial class CounterViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _count = 0;

        [RelayCommand]
        private void IncrementCount()
            => Count++;

        [RelayCommand]
        private void DecrementCount()
            => Count--;
    }
}
