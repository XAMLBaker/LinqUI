using System.Windows;
using System.Windows.Controls;

namespace LinqUI.WPF.HotReload;
public abstract class LinqComponent : ContentControl, IRender
{
    private bool _hasRendered;

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized (e);
        Render ();
    }

    public LinqComponent()
    {
        DataContextChanged += (_, __) =>
        {
            if (_hasRendered)
                Render ();
        };
    }

    public void Render()
    {
        _hasRendered = true;
        Content = Build ();
    }

    public abstract FrameworkElement Build();
}

public abstract class LinqComponent<TViewModel> : LinqComponent
{
}