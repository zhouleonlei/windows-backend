/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Test
{
    public class App : Tizen.NUI.NUIApplication
    {
        static TextLabel MainTitle;
        static readonly string Title = "NUI Auto TCT \n\n";
        static readonly float TextSize = 30.0f;

        private PushButton pushButton;

        private static Graphics.BackendType GraphicsBackend()
        {
            String DALI_VULKAN_BACKEND = Environment.GetEnvironmentVariable("DALI_VULKAN_BACKEND");
            int numVal = 0;
            Int32.TryParse(DALI_VULKAN_BACKEND, out numVal);

            if ((Graphics.BackendType)numVal == Graphics.BackendType.Gles)
            {
                Log.Fatal("NUI", "NUI Vulkan disabled~!");
                return Graphics.BackendType.Gles;
            }

            Log.Fatal("NUI", "NUI Vulkan enabled~!");
            return Graphics.BackendType.Vulkan;
        }

        public App() : base(GraphicsBackend(), WindowMode.Opaque, null, null, "")
        {
            // : base(GraphicsBackend(), WindowMode.Opaque, null, null, "")
            Log.Fatal("NUI", "Call App()");
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            //Tizen.Log.Fatal("NUI", "### OnCreate() START!");
            Random rand = new Random();

            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            MainTitle = new TextLabel();
            MainTitle.MultiLine = true;
            MainTitle.Text = Title + $"Process ID: {Process.GetCurrentProcess().Id} \nThread ID: {Thread.CurrentThread.ManagedThreadId}\n\n" + "Backend: ";
            if (GraphicsBackend() == Graphics.BackendType.Gles)
            {
                MainTitle.Text += "GL\n";
            }
            else
            {
                MainTitle.Text += "Vulkan\n";
            }
            MainTitle.PixelSize = TextSize;
            MainTitle.BackgroundColor = new Color(rand.Next(250) / 255.0f, rand.Next(250) / 255.0f, rand.Next(250) / 255.0f, 1.0f);
            MainTitle.Size2D = new Size2D(window.WindowSize.Width / 2, window.WindowSize.Height / 2);
            MainTitle.PositionUsesPivotPoint = true;
            MainTitle.ParentOrigin = ParentOrigin.Center;
            MainTitle.PivotPoint = PivotPoint.Center;
            window.Add(MainTitle);

            pushButton = new PushButton();
            pushButton.LabelText = "Start TCT";
            pushButton.Clicked += PushButton_Clicked;
            pushButton.Position2D = new Position2D(100, 100);
            window.Add(pushButton);

            //TRunner t = new TRunner();
            //t.LoadTestsuite();
            //t.Execute();

            //Tizen.Log.Fatal("NUI", "### OnCreate() END!");
        }

        private bool PushButton_Clicked(object source, EventArgs e)
        {
            StartTCT();
            return true;
        }

        private bool isTCT = false;
        private Type descriptionAttrType;
        private Type testFixtureAttrType;

        private bool TypeNeedDoTCT(Type type)
        {
            if (null != CustomAttributeExtensions.GetCustomAttribute(type, testFixtureAttrType))
            {
                DescriptionAttribute descriptionAttribute = CustomAttributeExtensions.GetCustomAttribute(type, descriptionAttrType) as DescriptionAttribute;

                if (null != descriptionAttribute)
                {
                    string description = descriptionAttribute.Properties.Get(PropertyNames.Description) as string;

                    if (false == description?.Contains("Tizen.NUI.Xaml")
                        &&
                        false == description?.Contains("Tizen.NUI.Binding"))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void StartTCT()
        {
            if (true == isTCT)
            {
                return;
            }

            isTCT = true;

            Assembly thisAssembly = this.GetType().Assembly;
            Assembly nunitFrameWorkAssembly = null;

            foreach (AssemblyName assembly in thisAssembly.GetReferencedAssemblies())
            {
                if ("nunit.framework" == assembly.Name)
                {
                    nunitFrameWorkAssembly = Assembly.Load(assembly);
                    break;
                }
            }

            testFixtureAttrType = nunitFrameWorkAssembly.GetType("NUnit.Framework.TestFixtureAttribute");
            descriptionAttrType = nunitFrameWorkAssembly.GetType("NUnit.Framework.DescriptionAttribute");

            Type setUpAttrType = nunitFrameWorkAssembly.GetType("NUnit.Framework.SetUpAttribute");
            Type tearDownAttrType = nunitFrameWorkAssembly.GetType("NUnit.Framework.TearDownAttribute");
            Type TestAttrType = nunitFrameWorkAssembly.GetType("NUnit.Framework.TestAttribute");

            try
            {
                foreach (Type type in thisAssembly.GetTypes())
                {
                    MethodInfo setUpMethod = null;
                    MethodInfo tearDownMethod = null;

                    if (true == TypeNeedDoTCT(type))
                    {
                        object testCase = thisAssembly.CreateInstance(type.FullName);

                        foreach (MethodInfo methodInfo in type.GetMethods())
                        {
                            if (null != CustomAttributeExtensions.GetCustomAttribute(methodInfo, setUpAttrType))
                            {
                                setUpMethod = methodInfo;
                            }

                            if (null != CustomAttributeExtensions.GetCustomAttribute(methodInfo, tearDownAttrType))
                            {
                                tearDownMethod = methodInfo;
                            }

                            if (null != setUpMethod && null != tearDownMethod)
                            {
                                break;
                            }
                        }

                        setUpMethod?.Invoke(testCase, new object[] { });

                        foreach (MethodInfo methodInfo in type.GetMethods())
                        {
                            if (null != CustomAttributeExtensions.GetCustomAttribute(methodInfo, TestAttrType))
                            {
                                methodInfo.Invoke(testCase, new object[] { });
                            }
                        }

                        tearDownMethod?.Invoke(testCase, new object[] { });
                    }
                }
            }
            catch (AssertionException exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }

            isTCT = false;
        }

        static public async Task MainTitleChangeBackgroundColor(Color color)
        {
            //if (color == null)
            //{
            //    Random rand = new Random();
            //    color = new Color(rand.Next(250) / 255.0f, rand.Next(250) / 255.0f, rand.Next(250) / 255.0f, 1.0f);
            //}
            //MainTitle.BackgroundColor = color;
            //await Task.Delay(1000);
        }

        static public async Task MainTitleChangeText(string title)
        {
            //MainTitle.Text = Title + title;
            //MainTitle.PixelSize = TextSize;
            //await Task.Delay(1000);

            //Tizen.Log.Fatal("NUI", $"{title} Process ID: {Process.GetCurrentProcess().Id} Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        protected override void OnTerminate()
        {
            //Tizen.Log.Fatal("NUI", "### OnTerminate() START!");

            Exit();
            base.OnTerminate();

            //Tizen.Log.Fatal("NUI", "### OnTerminate() END!");
        }

        public delegate string SWIGStringDelegate(string message);

        [global::System.Runtime.InteropServices.DllImport("libcapi-appfw-app-common.so.0", EntryPoint = "RegisterCreateStringCallback")]
        public static extern void RegisterCreateStringCallback(SWIGStringDelegate stringDelegate);

        static void Main(string[] args)
        {
            RegisterCreateStringCallback(new SWIGStringDelegate((string message) =>
            {
                return message;
            }));

            Tizen.Log.Fatal("NUI", "NUI RUN!");
            App example = new App();
            example.Run(args);
        }
    }
}

