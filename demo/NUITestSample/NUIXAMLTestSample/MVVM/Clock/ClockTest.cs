using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Examples
{
class ClockViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;

            // Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //     {
            //         this.DateTime = DateTime.Now;
            //         return true;
            //     });
            Timer timer = new Timer(1000);
            timer.Tick += (obj, e) => {
                this.DateTime = DateTime.Now;
                    return true;
            };
            timer.Start();
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

    }

    public class ClockTest : NUIApplication
    {

        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            ClockPage myPage = new ClockPage(window);
            Extensions.LoadFromXaml(myPage, typeof(ClockPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            ClockTest p = new ClockTest();
            p.Run(args);
        }
    }
}
