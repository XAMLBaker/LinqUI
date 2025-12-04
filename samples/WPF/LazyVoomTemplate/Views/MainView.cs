using LazyVoomTemplate.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace LazyVoomTemplate.Views;

public class MainView : LinqComponent<MainViewModel>
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
                    .BindCommand (this, btn => btn.Command, vm => vm.IncrementCountCommand),
                new Button ()
                    .Content ("Decrement (-1)")
                    .Margin (8)
                    .BindCommand (this, btn => btn.Command, vm => vm.DecrementCountCommand)
            );
}
