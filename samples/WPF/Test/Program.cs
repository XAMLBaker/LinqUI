using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinqUI.WPF;
using System.Windows;
using System.Windows.Controls;
namespace Test
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
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
                            .DataContext (new CounterViewModel ())
                            .Content (
                                new StackPanel ()
                                    .Orientation(Orientation.Vertical)
                                    .Children (
                                        new TextBlock ()
                                            .FontSize (24)
                                            .Margin (8)
                                            .HCenter ()
                                            .Bind (tb => tb.Text, static (CounterViewModel vm) => vm.Count),
                                        new Button ()
                                            .Content ("Increment (+1)")
                                            .Margin (8)
                                            .BindCommand (btn => btn.Command, static (CounterViewModel vm) => vm.IncrementCountCommand),
                                        new Button ()
                                            .Content ("Decrement (-1)")
                                            .Margin (8)
                                            .BindCommand (btn => btn.Command, static (CounterViewModel vm) => vm.DecrementCountCommand)
                                    )
                            )
                    );
        }
    }

    public class App : Application
    {

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
