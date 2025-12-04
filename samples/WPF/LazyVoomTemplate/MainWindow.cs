using LazyVoomTemplate.ViewModels;
using LazyVoomTemplate.Views;
using System.Windows;

namespace LazyVoomTemplate;

public class MainWindow : Window
{
    public MainWindow()
    {
        this.DataContext(new MainViewModel ())
            .Content(new MainView());
    }
}
