using System;
using System.Globalization;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    //[ValueConversion(typeof(float), typeof(Rotation))]
    public class FloatToRotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Rotation(new Radian(new Degree((float)value)), Vector3.ZAxis);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (bool)value ? 1 : 0;
            return null;
        }
    }

    public class ViewToViewTest : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            float?[] aray = new float?[]{};
            Console.WriteLine(aray.GetType());

            ViewToViewPage myPage = new ViewToViewPage(window);
            Extensions.LoadFromXaml(myPage, typeof(ViewToViewPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            ViewToViewTest p = new ViewToViewTest();
            p.Run(args);
        }
    }
}
