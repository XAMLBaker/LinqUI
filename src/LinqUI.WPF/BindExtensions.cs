using System.Linq.Expressions;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace LinqUI.WPF
{
    public static class BindExtensions
    {
        public static T BindCommand<T, TViewModel, TProp, TViewModelProp>(
                    this T control,
                    Expression<Func<T, TProp>> controlProperty,
                    Expression<Func<TViewModel, TViewModelProp>> viewModelProperty)
                    where T : FrameworkElement
        {
            var dp = GetDependencyProperty (controlProperty);
            var path = GetPath (viewModelProperty);

            control.SetBinding (dp, new Binding (path) { Mode = BindingMode.OneWay });

            return control;
        }
        public static T Bind<T, TViewModel,TProp ,TViewModelProp>(
            this T control, 
            Expression<Func<T, TProp>> controlProperty, 
            Expression<Func<TViewModel, TViewModelProp>> viewModelProperty, 
            BindingMode mode = BindingMode.TwoWay) 
            where T : FrameworkElement
        {
            var dp = GetDependencyProperty (controlProperty);
            var path = GetPath (viewModelProperty);

            control.SetBinding (dp, new Binding (path) { Mode = mode });

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

        public static T Bind<T>(this T control, DependencyProperty property, BindingBase bindingBase) where T : FrameworkElement
        {
            control.SetBinding (property, bindingBase);

            return control;
        }

        public static T Command<T>(this T control, string path, object? parameter = null) where T : ButtonBase
        {
            control.SetBinding (ButtonBase.CommandProperty, new Binding (path));
            if (parameter is not null)
                control.CommandParameter = parameter;
            return control;
        }

        public static T Command<T>(this T control, BindingBase bindingBase, object? parameter = null) where T : ButtonBase
        {
            control.SetBinding (ButtonBase.CommandProperty, bindingBase);
            if (parameter is not null)
                control.CommandParameter = parameter;
            return control;
        }
    }
}
