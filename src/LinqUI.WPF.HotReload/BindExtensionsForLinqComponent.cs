using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;

namespace LinqUI.WPF.HotReload;

public static class BindExtensionsForLinqComponent
{
    public static TControl Bind<TControl, TViewModel, TControlProp, TViewModelProp>(
        this TControl control,
        LinqComponent<TViewModel> view,
        Expression<Func<TControl, TControlProp>> controlProperty,
        Expression<Func<TViewModel, TViewModelProp>> viewModelProperty,
        BindingMode mode = BindingMode.TwoWay)
    where TControl : FrameworkElement
    {
        var dp = GetDependencyProperty (controlProperty);
        var path = GetPath (viewModelProperty);

        control.SetBinding (dp, new Binding (path) { Mode = mode });
        return control;
    }

    public static TControl BindCommand<TControl, TViewModel, TControlProp, TViewModelProp>(
        this TControl control,
        LinqComponent<TViewModel> view,
        Expression<Func<TControl, TControlProp>> controlProperty,
        Expression<Func<TViewModel, TViewModelProp>> viewModelProperty)
    where TControl : FrameworkElement
    {
        var dp = GetDependencyProperty (controlProperty);
        var path = GetPath (viewModelProperty);

        control.SetBinding (dp, new Binding (path) { Mode = BindingMode.OneWay });
        return control;
    }

    private static DependencyProperty GetDependencyProperty(LambdaExpression expr)
    {
        var member = (expr.Body as MemberExpression)!;
        return (DependencyProperty)member.Member.DeclaringType!
            .GetField (member.Member.Name + "Property")!
            .GetValue (null)!;
    }

    private static string GetPath(LambdaExpression expr)
        => expr.Body switch
        {
            MemberExpression m => m.Member.Name,
            UnaryExpression u when u.Operand is MemberExpression m => m.Member.Name,
            _ => throw new InvalidOperationException ()
        };
}
