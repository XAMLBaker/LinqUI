using Microsoft.UI.Xaml.Data;

namespace LinqUI.WinUI3
{
    public static class BindingExtensions
    {
        public static T Bind<T>(this T control, DependencyProperty property, string path, BindingMode bindingMode= BindingMode.TwoWay) where T : FrameworkElement
        {
            var binding = new Binding ();
            binding.Path = new PropertyPath(path);
            binding.Mode = bindingMode;
            control.SetBinding (property, binding);

            return control;
        }

        public static T Bind<T>(this T control, DependencyProperty property, BindingBase bindingBase) where T : FrameworkElement
        {
            control.SetBinding (property, bindingBase);

            return control;
        }

        public static T Command<T>(this T control, string path, object? parameter = null) where T : ButtonBase
        {
            var binding = new Binding ();
            binding.Path = new PropertyPath (path);
            control.SetBinding (ButtonBase.CommandProperty, binding);
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
