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
using Tizen.NUI.Controls;
using Tizen.FH.NUI.Controls;
using StyleManager = Tizen.NUI.Controls.StyleManager;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.AppStyles.xaml", "AppStyles.xaml", typeof(Tizen.FH.NUI.FHNUIApplication))]

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
            //AttributesContainer container = Extensions.LoadObject<AttributesContainer>(typeof(DANUIApplication));
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
            StyleManager.Instance.RegisterStyle("BasicButton", "Utility", typeof(UtilityBasicButtonAttributes), true);
            StyleManager.Instance.RegisterStyle("BasicButton", "Food", typeof(FoodBasicButtonAttributes));
            StyleManager.Instance.RegisterStyle("BasicButton", "Kitchen", typeof(KitchenBasicButtonAttributes));

            StyleManager.Instance.RegisterStyle("ServiceButton", "Family", typeof(FamilyServiceButtonAttributes));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Utility", typeof(UtilityServiceButtonAttributes), true);
            StyleManager.Instance.RegisterStyle("ServiceButton", "Food", typeof(FoodServiceButtonAttributes));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Kitchen", typeof(KitchenServiceButtonAttributes));

            StyleManager.Instance.RegisterStyle("ToggleButton", "Family", typeof(FamilyToggleButtonAttributes));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Utility", typeof(UtilityToggleButtonAttributes), true);
            StyleManager.Instance.RegisterStyle("ToggleButton", "Food", typeof(FoodToggleButtonAttributes));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Kitchen", typeof(KitchenToggleButtonAttributes));

            StyleManager.Instance.RegisterStyle("OvalButton", "Family", typeof(FamilyOvalButtonAttributes));
            StyleManager.Instance.RegisterStyle("OvalButton", "Utility", typeof(UtilityOvalButtonAttributes), true);
            StyleManager.Instance.RegisterStyle("OvalButton", "Food", typeof(FoodOvalButtonAttributes));
            StyleManager.Instance.RegisterStyle("OvalButton", "Kitchen", typeof(KitchenOvalButtonAttributes));

            StyleManager.Instance.RegisterStyle("BasicPagination", null, typeof(BasicPaginationAttributes));

            StyleManager.Instance.RegisterStyle("UtilityCheckBox",null, typeof(UtilityCheckBoxAttributes));
            StyleManager.Instance.RegisterStyle("FoodCheckBox", null, typeof(FoodCheckBoxAttributes));
            StyleManager.Instance.RegisterStyle("FamilyCheckBox", null, typeof(FamilyCheckBoxAttributes));
            StyleManager.Instance.RegisterStyle("KitchenCheckBox", null, typeof(KitchenCheckBoxAttributes));

            StyleManager.Instance.RegisterStyle("UtilityRadioButton", null, typeof(UtilityRadioButtonAttributes));
            StyleManager.Instance.RegisterStyle("FoodRadioButton", null, typeof(FoodRadioButtonAttributes));
            StyleManager.Instance.RegisterStyle("FamilyRadioButton", null, typeof(FamilyRadioButtonAttributes));
            StyleManager.Instance.RegisterStyle("KitchenRadioButton", null,typeof(KitchenRadioButtonAttributes));

            StyleManager.Instance.RegisterStyle("UtilitySwitch", null, typeof(UtilitySwitchAttributes));
            StyleManager.Instance.RegisterStyle("FoodSwitch", null, typeof(FoodSwitchAttributes));
            StyleManager.Instance.RegisterStyle("FamilySwitch", null, typeof(FamilySwitchAttributes));
            StyleManager.Instance.RegisterStyle("KitchenSwitch", null, typeof(KitchenSwitchAttributes));

            StyleManager.Instance.RegisterStyle("DAScrollbar", null, typeof(FH.NUI.Controls.DAScrollBarAttributes));
            StyleManager.Instance.RegisterStyle("VDScrollbar", null, typeof(FH.NUI.Controls.VDScrollBarAttributes));

            StyleManager.Instance.RegisterStyle("FamilyProgressbar", null, typeof(FH.NUI.Controls.FamilyProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("FoodProgressbar", null, typeof(FH.NUI.Controls.FoodProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("KitchenProgressbar", null, typeof(FH.NUI.Controls.KitchenProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("UtilityProgressbar", null, typeof(FH.NUI.Controls.UtilityProgressbarAttributes));
            StyleManager.Instance.RegisterStyle("VDProgressCircle", null, typeof(FH.NUI.Controls.VDProgressCircleAttributes));

            StyleManager.Instance.RegisterStyle("DAPopup", null, typeof(DAPopupAttributes));
            StyleManager.Instance.RegisterStyle("UtilityPopupButton", null, typeof(UtilityPopupButtonAttributes));
            StyleManager.Instance.RegisterStyle("FoodPopupButton", null, typeof(FoodPopupButtonAttributes));
            StyleManager.Instance.RegisterStyle("FamilyPopupButton", null, typeof(FamilyPopupButtonAttributes));
            StyleManager.Instance.RegisterStyle("KitchenPopupButton", null, typeof(KitchenPopupButtonAttributes));

            StyleManager.Instance.RegisterStyle("DATab", null, typeof(DATabAttributes));

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

            StyleManager.Instance.RegisterStyle("UtilityDefaultSlider", null, typeof(UtilityDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("FoodDefaultSlider", null, typeof(FoodDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("FamilyDefaultSlider", null, typeof(FamilyDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("KitchenDefaultSlider", null, typeof(KitchenDefaultSliderAttributes));
            StyleManager.Instance.RegisterStyle("UtilityTextSlider", null, typeof(UtilityTextSliderAttributes));
            StyleManager.Instance.RegisterStyle("FoodTextSlider", null, typeof(FoodTextSliderAttributes));
            StyleManager.Instance.RegisterStyle("FamilyTextSlider", null, typeof(FamilyTextSliderAttributes));
            StyleManager.Instance.RegisterStyle("KitchenTextSlider", null, typeof(KitchenTextSliderAttributes));

            StyleManager.Instance.RegisterStyle("FamilyDefaultInputField", null, typeof(FamilyDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("FamilyStyleBInputField", null, typeof(FamilyStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("FoodDefaultInputField", null, typeof(FoodDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("FoodStyleBInputField", null, typeof(FoodStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("KitchenDefaultInputField", null, typeof(KitchenDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("KitchenStyleBInputField", null, typeof(KitchenStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("UtilityDefaultInputField", null, typeof(UtilityDefaultInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("UtilityStyleBInputField", null, typeof(UtilityStyleBInputFieldAttributes));
            StyleManager.Instance.RegisterStyle("DefaultSearchInputField", null, typeof(DefaultSearchInputFieldAttributes));

            StyleManager.Instance.RegisterStyle("DefaultSearchBar", null, typeof(DefaultSearchBarAttributes));

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
        }
        private void CleanupComponent()
        {
        }
    }
}
