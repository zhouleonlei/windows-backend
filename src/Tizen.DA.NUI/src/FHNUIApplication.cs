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

            StyleManager.Instance.RegisterStyle("BasicButton", "Family", typeof(FamilyBasicButtonAttributes));
            StyleManager.Instance.RegisterStyle("BasicButton", "Utility", typeof(UtilityBasicButtonStyle), true);
            StyleManager.Instance.RegisterStyle("BasicButton", "Food", typeof(FoodBasicButtonStyle));
            StyleManager.Instance.RegisterStyle("BasicButton", "Kitchen", typeof(KitchenBasicButtonAttributes));

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

            StyleManager.Instance.RegisterStyle("BasicPagination", null, typeof(BasicPaginationAttributes));

            StyleManager.Instance.RegisterStyle("CheckBox", "Utility", typeof(UtilityCheckBoxAttributes), true);
            StyleManager.Instance.RegisterStyle("CheckBox", "Food", typeof(FoodCheckBoxAttributes));
            StyleManager.Instance.RegisterStyle("CheckBox", "Family", typeof(FamilyCheckBoxAttributes));
            StyleManager.Instance.RegisterStyle("CheckBox", "Kitchen", typeof(KitchenCheckBoxAttributes));

            StyleManager.Instance.RegisterStyle("RadioButton", "Utility", typeof(UtilityRadioButtonAttributes), true);
            StyleManager.Instance.RegisterStyle("RadioButton", "Food", typeof(FoodRadioButtonAttributes));
            StyleManager.Instance.RegisterStyle("RadioButton", "Family", typeof(FamilyRadioButtonAttributes));
            StyleManager.Instance.RegisterStyle("RadioButton", "Kitchen", typeof(KitchenRadioButtonAttributes));

            StyleManager.Instance.RegisterStyle("Switch", "Utility", typeof(UtilitySwitchAttributes), true);
            StyleManager.Instance.RegisterStyle("Switch", "Food", typeof(FoodSwitchAttributes));
            StyleManager.Instance.RegisterStyle("Switch", "Family", typeof(FamilySwitchAttributes));
            StyleManager.Instance.RegisterStyle("Switch", "Kitchen", typeof(KitchenSwitchAttributes));
            StyleManager.Instance.RegisterStyle("ListIndexSwitch", null, typeof(ListIndexSwitchAttributes));

            StyleManager.Instance.RegisterStyle("DAScrollbar", null, typeof(FH.NUI.Controls.DAScrollBarAttributes));

            StyleManager.Instance.RegisterStyle("Progressbar","Family", typeof(FH.NUI.Controls.FamilyProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("Progressbar","Food", typeof(FH.NUI.Controls.FoodProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("Progressbar","Kitchen", typeof(FH.NUI.Controls.KitchenProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("Progressbar", "Utility", typeof(FH.NUI.Controls.UtilityProgressbarAttributes));

            StyleManager.Instance.RegisterStyle("Popup", "Family", typeof(FamilyPopupAttributes));
            StyleManager.Instance.RegisterStyle("Popup", "Utility", typeof(UtilityPopupAttributes), true);
            StyleManager.Instance.RegisterStyle("Popup", "Food", typeof(FoodPopupAttributes));
            StyleManager.Instance.RegisterStyle("Popup", "Kitchen", typeof(KitchenPopupAttributes));           

            StyleManager.Instance.RegisterStyle("Tab", "Family", typeof(FamilyTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Utility", typeof(UtilityTabStyle), true);
            StyleManager.Instance.RegisterStyle("Tab", "Food", typeof(FoodTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Kitchen", typeof(KitchenTabStyle));

            StyleManager.Instance.RegisterStyle("HeaderDropDown", null, typeof(HeaderSpinnerDropDownAttributes));
            StyleManager.Instance.RegisterStyle("ListDropDown", null, typeof(ListSpinnerDropDownAttributes));
            StyleManager.Instance.RegisterStyle("TextListItem", null, typeof(TextListItemAttributes));
            StyleManager.Instance.RegisterStyle("IconListItem", null, typeof(IconListItemAttributes));

            StyleManager.Instance.RegisterStyle("Back", null, typeof(BackNavigationAttributes));
            StyleManager.Instance.RegisterStyle("WhiteCondition", null, typeof(WhiteConditionNavigationAttributes));
            StyleManager.Instance.RegisterStyle("BlackCondition", null, typeof(BlackConditionNavigationAttributes));
            StyleManager.Instance.RegisterStyle("WhiteEditMode", null, typeof(WhiteEditModeNavigationAttributes));
            StyleManager.Instance.RegisterStyle("BlackEditMode", null, typeof(BlackEditModeNavigationAttributes));

            StyleManager.Instance.RegisterStyle("WhiteBackItem", null, typeof(WhiteBackNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("BlackBackItem", null, typeof(BlackBackNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("WhiteConditionItem", null, typeof(WhiteConditionNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("BlackConditionItem", null, typeof(BlackConditionNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("WhiteEditModeItem", null, typeof(WhiteEditModeNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("WhiteEditModeFirstItem", null, typeof(WhiteEditModeFirstNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("WhiteEditModeLastItem", null, typeof(WhiteEditModeLastNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("BlackEditModeItem", null, typeof(BlackEditModeNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("BlackEditModeFirstItem", null, typeof(BlackEditModeFirstNavigationItemAttributes));
            StyleManager.Instance.RegisterStyle("BlackEditModeLastItem", null, typeof(BlackEditModeLastNavigationItemAttributes));

            StyleManager.Instance.RegisterStyle("DefaultSlider", "Utility", typeof(UtilityDefaultSliderAttributes), true);
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Food", typeof(FoodDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Family", typeof(FamilyDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Kitchen", typeof(KitchenDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("TextSlider", "Utility", typeof(UtilityTextSliderAttributes), true);
            StyleManager.Instance.RegisterStyle("TextSlider", "Food", typeof(FoodTextSliderAttributes));
            StyleManager.Instance.RegisterStyle("TextSlider", "Family", typeof(FamilyTextSliderAttributes));
            StyleManager.Instance.RegisterStyle("TextSlider", "Kitchen", typeof(KitchenTextSliderAttributes));

            StyleManager.Instance.RegisterStyle("DefaultInputField", "Family", typeof(FamilyDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Family", typeof(FamilyStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Food", typeof(FoodDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Food", typeof(FoodStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Kitchen", typeof(KitchenDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Kitchen", typeof(KitchenStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Utility", typeof(UtilityDefaultInputFieldAttributes), true);
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Utility", typeof(UtilityStyleBInputFieldAttributes), true);
            StyleManager.Instance.RegisterStyle("DefaultSearchInputField", null, typeof(DefaultSearchInputFieldAttributes));

            StyleManager.Instance.RegisterStyle("DefaultSearchBar", null, typeof(DefaultSearchBarAttributes), true);

            StyleManager.Instance.RegisterStyle("BasicShortToast", null, typeof(BasicShortToastAttributes));
            StyleManager.Instance.RegisterStyle("BasicLongToast", null, typeof(BasicLongToastAttributes));

            StyleManager.Instance.RegisterStyle("DefaultListItem", null, typeof(DefaultListItemAttributes));
            StyleManager.Instance.RegisterStyle("MultiSubTextListItem", null, typeof(MultiSubTextListItemAttributes));
            StyleManager.Instance.RegisterStyle("EffectListItem", null, typeof(EffectListItemAttributes));
            StyleManager.Instance.RegisterStyle("ItemAlignListItem", null, typeof(ItemAlignListItemAttributes));
            StyleManager.Instance.RegisterStyle("NextDepthListItem", null, typeof(NextDepthListItemAttributes));
            StyleManager.Instance.RegisterStyle("GroupIndexListItem", null, typeof(GroupIndexListItemAttributes));

            StyleManager.Instance.RegisterStyle("DefaultLoading", null, typeof(DefaultLoadingAttributes));

            StyleManager.Instance.RegisterStyle("DAPicker", null, typeof(DAPickerAttributes));

            StyleManager.Instance.RegisterStyle("DATimePicker", null, typeof(DATimePickerAttributes));
            StyleManager.Instance.RegisterStyle("DATimePickerAMPM", null, typeof(DATimePickerAMPMAttributes));
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", null, typeof(DATimePickerRepeatAttributes));

            StyleManager.Instance.RegisterStyle("DASpin", null, typeof(DASpinAttributes));
            StyleManager.Instance.RegisterStyle("DAStrSpin", null, typeof(DAStrSpinAttributes));
            StyleManager.Instance.RegisterStyle("DefaultHeader", null, typeof(DefaultHeaderAttributes));
            StyleManager.Instance.RegisterStyle("OpaqueHeader", null, typeof(OpaqueHeaderAttributes));
            StyleManager.Instance.RegisterStyle("TransparencyHeader", null, typeof(TransparencyHeaderAttributes));
            StyleManager.Instance.RegisterStyle("DefaultNaviFrame", null, typeof(DefaultNaviFrameAttributes));
        }
        private void CleanupComponent()
        {
        }
    }
}
