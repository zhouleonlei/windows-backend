using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Constants;
using Tizen.NUI.BaseComponents;

using System.CodeDom.Compiler;
using System.Reflection;
using System.Xml;

namespace VisualsExampleTest
{
    class TestScript : NUIApplication
    {
        public TestScript() : base()
        {
        }
        public TestScript(string stylesheet) : base(stylesheet)
        {
        }
        public TestScript(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            View view = new View();
        }
        public void Initialize()
        {
            LoadNodes("Test.xaml");
        }
        void LoadNodes(string fileName)
        {
            string nuiPath = Environment.GetEnvironmentVariable("dali_csharp-demo");
            string path = nuiPath + "/res/" + fileName;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var root = xmlDoc.DocumentElement;
            XmlElement child = (XmlElement)xmlDoc.SelectSingleNode("UI/Node");

            string name = child.GetElementsByTagName("Name")[0].InnerText;
            string type = child.GetElementsByTagName("Type")[0].InnerText;
            string x = child.GetElementsByTagName("X")[0].InnerText;
            string y = child.GetElementsByTagName("Y")[0].InnerText;
            string width = child.GetElementsByTagName("W")[0].InnerText;
            string height = child.GetElementsByTagName("H")[0].InnerText;
            string script = child.GetElementsByTagName("Script")[0].InnerText;

            if (type == "PushButton")
            {
                PushButton pb = new PushButton();
                pb.Name = name;
                pb.Position2D = new Position2D(int.Parse(x), int.Parse(y));
                pb.Size2D = new Size2D(int.Parse(width), int.Parse(height));

                pb.Clicked += CompileAndLink(script, "OnClick");

                Window win = Window.Instance;
                win.Add(pb);
            }
        }

        public EventHandlerWithReturnType<object, EventArgs, bool> CompileAndLink(string source,string eventKey)
        {
            CompilerParameters _CompilerParameters = new CompilerParameters();

            _CompilerParameters.ReferencedAssemblies.Add("System.dll");
            _CompilerParameters.GenerateExecutable = false;
            _CompilerParameters.GenerateInMemory = true;
            _CompilerParameters.IncludeDebugInformation = false;

            source = "using System;" + source;
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerResults _CompilerResults = codeProvider.CompileAssemblyFromSource(_CompilerParameters, source);

            Assembly _Assembly = _CompilerResults.CompiledAssembly;
            System.Type _type = _Assembly.GetType("CustomEvent");
            object obj = Activator.CreateInstance(_type);
            MethodInfo _method = _type.GetMethod("OnClick",BindingFlags.Public|BindingFlags.Instance);

            EventHandlerWithReturnType<object, EventArgs, bool>  test = (EventHandlerWithReturnType<object, EventArgs, bool>)
                Delegate.CreateDelegate(typeof(EventHandlerWithReturnType<object, EventArgs, bool>),obj, _method, true);

            return test;
        }
    }
}
