using System;

using System.Globalization;
using Tizen.NUI.XamlBinding;

namespace Tizen.NUI.Examples
{
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

            ViewToViewPage myPage = new ViewToViewPage();
            window.Add(myPage.ViewInstance);
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }
    }
}
