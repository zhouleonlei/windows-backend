/// @file TVUIApplication.cs
/// <published> N </published>
/// <privlevel> Non-privilege </privlevel>
/// <privilege> None </privilege> 
/// <privacy> N </privacy>
/// <product> TV </product>
/// <version> 4.4.0 </version>
/// <SDK_Support> Y </SDK_Support>
///
/// Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved 
/// PROPRIETARY/CONFIDENTIAL 
/// This software is the confidential and proprietary 
/// information of SAMSUNG ELECTRONICS ("Confidential Information"). You shall 
/// not disclose such Confidential Information and shall use it only in 
/// accordance with the terms of the license agreement you entered into with 
/// SAMSUNG ELECTRONICS. SAMSUNG make no representations or warranties about the 
/// suitability of the software, either express or implied, including but not 
/// limited to the implied warranties of merchantability, fitness for a 
/// particular purpose, or non-infringement. SAMSUNG shall not be liable for any 
/// damages suffered by licensee as a result of using, modifying or distributing 
/// this software or its derivatives.
using System;
using System.Reflection;
using Tizen.NUI;
using Tizen.NUI.Xaml;
using Tizen.NUI.CommonUI;
using Tizen.FH.NUI.Controls;
using StyleManager = Tizen.NUI.CommonUI.StyleManager;

namespace Tizen.FH.NUI
{
    /// <summary>
    /// The base class of tv nui application. Your ui application code should inherit this class.
    /// </summary>
    /// <code>
    /// class MyUIApp : TVUIApplication
    /// {
    ///     static void Main(string[] args)
    ///     {
    ///         MyUIApp uiApp = new MyUIApp();
    ///         uiApp.Run(args);
    ///     }
    /// }
    /// </code>

    public class FHNUIApplication : NUIApplication
    {

        private static Graphics.BackendType GraphicsBackend()
        {
            String DALI_VULKAN_BACKEND = Environment.GetEnvironmentVariable("DALI_VULKAN_BACKEND");

            int numVal = Int32.Parse(DALI_VULKAN_BACKEND);
            Log.Error("TV.NUI", "DALI_VULKAN_BACKEND : " + numVal);

            if ((Graphics.BackendType)numVal == Graphics.BackendType.Gles)
            {
                Log.Error("TV.NUI", "NUI Vulkan disabled~!");
                return Graphics.BackendType.Gles;
            }

            Log.Error("TV.NUI", "NUI Vulkan enabled~!");
            return Graphics.BackendType.Vulkan;
        }
        /// <summary>
        /// Constructor to instantiate the TVUIApplication class.
        /// <param name="windowMode">window mode for deciding whether application window is opaque or transparent.</param>
        /// </summary>
        public FHNUIApplication(WindowMode windowMode = WindowMode.Opaque) : base("", windowMode)
        {
        }

        /// <summary>
        /// Constructor to instantiate the TVUIApplication class.
        /// <param name="styleSheet">The stylesheet url</param>
        /// <param name="windowMode">window mode for deciding whether application window is opaque or transparent.</param>
        /// </summary>
        public FHNUIApplication(string styleSheet, WindowMode windowMode = WindowMode.Opaque) : base("", windowMode)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// </summary>
        protected override void OnPreCreate()
        {
            base.OnPreCreate();
            Initialize();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is created.        
        /// </summary>

        protected override void OnCreate()
        {
            base.OnCreate();
            //StyleBase container = Extensions.LoadObject<StyleBase>(typeof(DANUIApplication));
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is resumed.
        /// </summary>

        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is terminated.
        /// If base.OnTerminate() is not called, the event 'Terminated' will not be emitted.
        /// </summary>
        protected override void OnTerminate()
        {
            CleanUp();
            base.OnTerminate();
        }

        /// <summary>
        /// Runs the TVUIApplication.
        /// </summary>
        /// <version> 5.5.0 </version>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);
        }

        private void Initialize()
        {
            InitializeComponent();
        }
        private void CleanUp()
        {
            CleanupComponent();
        }

        private void InitializeComponent()
        {
            StyleManager.Instance.Theme = "Utility";
            NUIApplication.RegisterAssembly(typeof(FHNUIApplication).GetTypeInfo().Assembly);

            StyleManager.Instance.RegisterStyle("BasicButton", "Family", typeof(FamilyBasicButtonStyle));
            StyleManager.Instance.RegisterStyle("BasicButton", "Utility", typeof(UtilityBasicButtonStyle), true);
            StyleManager.Instance.RegisterStyle("BasicButton", "Food", typeof(FoodBasicButtonStyle));
            StyleManager.Instance.RegisterStyle("BasicButton", "Kitchen", typeof(KitchenBasicButtonStyle));

            StyleManager.Instance.RegisterStyle("ServiceButton", "Family", typeof(FamilyServiceButtonStyle));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Utility", typeof(UtilityServiceButtonStyle), true);
            StyleManager.Instance.RegisterStyle("ServiceButton", "Food", typeof(FoodServiceButtonStyle));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Kitchen", typeof(KitchenServiceButtonStyle));

            StyleManager.Instance.RegisterStyle("ToggleButton", "Family", typeof(FamilyToggleButtonStyle));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Utility", typeof(UtilityToggleButtonStyle), true);
            StyleManager.Instance.RegisterStyle("ToggleButton", "Food", typeof(FoodToggleButtonStyle));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Kitchen", typeof(KitchenToggleButtonStyle));

            StyleManager.Instance.RegisterStyle("OvalButton", "Family", typeof(FamilyOvalButtonStyle));
            StyleManager.Instance.RegisterStyle("OvalButton", "Utility", typeof(UtilityOvalButtonStyle), true);
            StyleManager.Instance.RegisterStyle("OvalButton", "Food", typeof(FoodOvalButtonStyle));
            StyleManager.Instance.RegisterStyle("OvalButton", "Kitchen", typeof(KitchenOvalButtonStyle));

            StyleManager.Instance.RegisterStyle("BasicPagination", null, typeof(BasicPaginationStyle));

            StyleManager.Instance.RegisterStyle("CheckBox", "Utility", typeof(UtilityCheckBoxStyle), true);
            StyleManager.Instance.RegisterStyle("CheckBox", "Food", typeof(FoodCheckBoxStyle));
            StyleManager.Instance.RegisterStyle("CheckBox", "Family", typeof(FamilyCheckBoxStyle));
            StyleManager.Instance.RegisterStyle("CheckBox", "Kitchen", typeof(KitchenCheckBoxStyle));

            StyleManager.Instance.RegisterStyle("RadioButton", "Utility", typeof(UtilityRadioButtonStyle), true);
            StyleManager.Instance.RegisterStyle("RadioButton", "Food", typeof(FoodRadioButtonStyle));
            StyleManager.Instance.RegisterStyle("RadioButton", "Family", typeof(FamilyRadioButtonStyle));
            StyleManager.Instance.RegisterStyle("RadioButton", "Kitchen", typeof(KitchenRadioButtonStyle));

            StyleManager.Instance.RegisterStyle("Switch", "Utility", typeof(UtilitySwitchStyle), true);
            StyleManager.Instance.RegisterStyle("Switch", "Food", typeof(FoodSwitchStyle));
            StyleManager.Instance.RegisterStyle("Switch", "Family", typeof(FamilySwitchStyle));
            StyleManager.Instance.RegisterStyle("Switch", "Kitchen", typeof(KitchenSwitchStyle));
            StyleManager.Instance.RegisterStyle("ListIndexSwitch", null, typeof(ListIndexSwitchStyle));

            StyleManager.Instance.RegisterStyle("DAScrollbar", null, typeof(FH.NUI.Controls.DAScrollBarStyle));

            StyleManager.Instance.RegisterStyle("Progressbar","Family", typeof(FH.NUI.Controls.FamilyProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar","Food", typeof(FH.NUI.Controls.FoodProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar","Kitchen", typeof(FH.NUI.Controls.KitchenProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar", "Utility", typeof(FH.NUI.Controls.UtilityProgressbarStyle));

            StyleManager.Instance.RegisterStyle("Popup", "Family", typeof(FamilyPopupStyle));
            StyleManager.Instance.RegisterStyle("Popup", "Utility", typeof(UtilityPopupStyle), true);
            StyleManager.Instance.RegisterStyle("Popup", "Food", typeof(FoodPopupStyle));
            StyleManager.Instance.RegisterStyle("Popup", "Kitchen", typeof(KitchenPopupStyle));           

            StyleManager.Instance.RegisterStyle("Tab", "Family", typeof(FamilyTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Utility", typeof(UtilityTabStyle), true);
            StyleManager.Instance.RegisterStyle("Tab", "Food", typeof(FoodTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Kitchen", typeof(KitchenTabStyle));

            StyleManager.Instance.RegisterStyle("HeaderDropDown", null, typeof(HeaderSpinnerDropDownStyle));
            StyleManager.Instance.RegisterStyle("ListDropDown", null, typeof(ListSpinnerDropDownStyle));
            StyleManager.Instance.RegisterStyle("TextListItem", null, typeof(TextListItemStyle));
            StyleManager.Instance.RegisterStyle("IconListItem", null, typeof(IconListItemStyle));

            StyleManager.Instance.RegisterStyle("Back", null, typeof(BackNavigationStyle));
            StyleManager.Instance.RegisterStyle("WhiteCondition", null, typeof(WhiteConditionNavigationStyle));
            StyleManager.Instance.RegisterStyle("BlackCondition", null, typeof(BlackConditionNavigationStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditMode", null, typeof(WhiteEditModeNavigationStyle));
            StyleManager.Instance.RegisterStyle("BlackEditMode", null, typeof(BlackEditModeNavigationStyle));

            StyleManager.Instance.RegisterStyle("WhiteBackItem", null, typeof(WhiteBackNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackBackItem", null, typeof(BlackBackNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteConditionItem", null, typeof(WhiteConditionNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackConditionItem", null, typeof(BlackConditionNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeItem", null, typeof(WhiteEditModeNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeFirstItem", null, typeof(WhiteEditModeFirstNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeLastItem", null, typeof(WhiteEditModeLastNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeItem", null, typeof(BlackEditModeNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeFirstItem", null, typeof(BlackEditModeFirstNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeLastItem", null, typeof(BlackEditModeLastNavigationItemStyle));

            StyleManager.Instance.RegisterStyle("DefaultSlider", "Utility", typeof(UtilityDefaultSliderStyle), true);
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Food", typeof(FoodDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Family", typeof(FamilyDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Kitchen", typeof(KitchenDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Utility", typeof(UtilityTextSliderStyle), true);
            StyleManager.Instance.RegisterStyle("TextSlider", "Food", typeof(FoodTextSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Family", typeof(FamilyTextSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Kitchen", typeof(KitchenTextSliderStyle));

            StyleManager.Instance.RegisterStyle("DefaultInputField", "Family", typeof(FamilyDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Family", typeof(FamilyStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Food", typeof(FoodDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Food", typeof(FoodStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Kitchen", typeof(KitchenDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Kitchen", typeof(KitchenStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Utility", typeof(UtilityDefaultInputFieldStyle), true);
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Utility", typeof(UtilityStyleBInputFieldStyle), true);
            StyleManager.Instance.RegisterStyle("DefaultSearchInputField", null, typeof(DefaultSearchInputFieldStyle));

            StyleManager.Instance.RegisterStyle("DefaultSearchBar", null, typeof(DefaultSearchBarStyle), true);

            StyleManager.Instance.RegisterStyle("BasicShortToast", null, typeof(BasicShortToasStyle));
            StyleManager.Instance.RegisterStyle("BasicLongToast", null, typeof(BasicLongToastStyle));

            StyleManager.Instance.RegisterStyle("DefaultListItem", null, typeof(DefaultListItemStyle));
            StyleManager.Instance.RegisterStyle("MultiSubTextListItem", null, typeof(MultiSubTextListItemAttributes));
            StyleManager.Instance.RegisterStyle("EffectListItem", null, typeof(EffectListItemAttributes));
            StyleManager.Instance.RegisterStyle("ItemAlignListItem", null, typeof(ItemAlignListItemAttributes));
            StyleManager.Instance.RegisterStyle("NextDepthListItem", null, typeof(NextDepthListItemAttributes));
            StyleManager.Instance.RegisterStyle("GroupIndexListItem", null, typeof(GroupIndexListItemAttributes));

            StyleManager.Instance.RegisterStyle("DefaultLoading", null, typeof(DefaultLoadingStyle));

            StyleManager.Instance.RegisterStyle("DAPicker", null, typeof(DAPickerStyle));

            StyleManager.Instance.RegisterStyle("DATimePicker", null, typeof(DATimePickerStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerAMPM", null, typeof(DATimePickerAMPMStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", null, typeof(DATimePickerRepeatStyle));

            StyleManager.Instance.RegisterStyle("DASpin", null, typeof(DASpinStyle));
            StyleManager.Instance.RegisterStyle("DAStrSpin", null, typeof(DAStrSpinStyle));
            StyleManager.Instance.RegisterStyle("DefaultHeader", null, typeof(DefaultHeaderStyle));
            StyleManager.Instance.RegisterStyle("OpaqueHeader", null, typeof(OpaqueHeaderStyle));
            StyleManager.Instance.RegisterStyle("TransparencyHeader", null, typeof(TransparencyHeaderStyle));
            StyleManager.Instance.RegisterStyle("DefaultNaviFrame", null, typeof(DefaultNaviFrameStyle));
        }
        private void CleanupComponent()
        {
        }
    }
}
