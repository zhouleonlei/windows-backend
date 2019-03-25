using System;
using System.Collections.Generic;

namespace Tizen.NUI.CommonUI
{
    public sealed class StyleManager
    {
        private string theme = "default";
        private Dictionary<string, Dictionary<string, Type>> ThemeStyleSet = new Dictionary<string, Dictionary<string, Type>>();
        private Dictionary<string, Type> DefaultStyleSet = new Dictionary<string, Type>();
        private EventHandler<ThemeChangeEventArgs> themeChangeHander;
        public event EventHandler<ThemeChangeEventArgs> ThemeChangedEvent
        {
            add
            {
                themeChangeHander += value;
            }
            remove
            {
                themeChangeHander -= value;
            }
        }
        private StyleManager()
        {
            
        }
        
        public static StyleManager Instance { get; } = new StyleManager();
        public  string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                if(theme != value)
                {
                    theme = value;
                    themeChangeHander?.Invoke(null, new ThemeChangeEventArgs { CurrentTheme = theme });
                }
            }
        }
  

        public void RegisterStyle(string style, string theme, Type styleType, bool bDefault = false)
        {
            if(style == null)
            {
                throw new InvalidOperationException($"style can't be null");
            }

            if(theme == null || bDefault == true)
            {
                if(DefaultStyleSet.ContainsKey(style))
            {
                throw new InvalidOperationException($"{style}] already be used");
            }
                else
            {
                    DefaultStyleSet.Add(style, styleType);
                }
                return;
            }

            if(ThemeStyleSet.ContainsKey(style) && ThemeStyleSet[style].ContainsKey(theme))
            {
                throw new InvalidOperationException($"{style}] already be used");
            }
                if(!ThemeStyleSet.ContainsKey(style))
                {
                    ThemeStyleSet.Add(style, new Dictionary<string, Type>());
                }
                ThemeStyleSet[style].Add(theme, styleType);
        }

        public Attributes GetAttributes(string style)
        {
            if(style == null)
            {
                return null;
            }
            object obj = null;

            if(ThemeStyleSet.ContainsKey(style) && ThemeStyleSet[style].ContainsKey(Theme))
            {
                obj = Activator.CreateInstance(ThemeStyleSet[style][Theme]);
            }
            else if(DefaultStyleSet.ContainsKey(style))
            {
                obj = Activator.CreateInstance(DefaultStyleSet[style]);
            }

            return (obj as AttributesContainer)?.GetAttributes();
        }
        public class ThemeChangeEventArgs : EventArgs
        {
            public string CurrentTheme;
        }
    }
}
