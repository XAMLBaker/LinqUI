using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LazyVoomTemplate.ViewModels;

public sealed partial class MainViewModel : ObservableObject
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
