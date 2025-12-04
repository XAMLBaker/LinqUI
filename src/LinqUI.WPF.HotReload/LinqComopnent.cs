using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

public abstract class LinqComponent<TViewModel> : ContentControl
{
    private bool _initialized;

    public LinqComponent()
    {
        DataContextChanged += (_, __) => TryRender ();
        Loaded += (_, __) => TryRender ();
    }

    private void TryRender()
    {
        if (DataContext is TViewModel vm)
        {
            _initialized = true;
            Content = Build ();
        }
    }

    public abstract FrameworkElement Build();
}