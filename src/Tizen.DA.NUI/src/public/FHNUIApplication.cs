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
            NUIApplication.RegisterAssembly(typeof(FHNUIApplication).GetTypeInfo().Assembly);

            Button.RegisterStyle("FamilyBasicButton", () => { return FamilyBasicButtonAttributesContainer.Container; });

            Button.RegisterStyle("UtilityBasicButton", typeof(UtilityBasicButtonAttributes));
            Button.RegisterStyle("FoodBasicButton", typeof(FoodBasicButtonAttributes));
            Button.RegisterStyle("KitchenBasicButton", typeof(KitchenBasicButtonAttributes));

            Button.RegisterStyle("UtilityServiceButton", typeof(UtilityServiceButtonAttributes));
            Button.RegisterStyle("FoodServiceButton", typeof(FoodServiceButtonAttributes));
            Button.RegisterStyle("FamilyServiceButton", typeof(FamilyServiceButtonAttributes));
            Button.RegisterStyle("KitchenServiceButton", typeof(KitchenServiceButtonAttributes));

            Button.RegisterStyle("UtilityToggleButton", typeof(UtilityToggleButtonAttributes));
            Button.RegisterStyle("FoodToggleButton", typeof(FoodToggleButtonAttributes));
            Button.RegisterStyle("FamilyToggleButton", typeof(FamilyToggleButtonAttributes));
            Button.RegisterStyle("KitchenToggleButton", typeof(KitchenToggleButtonAttributes));

            Button.RegisterStyle("UtilityOvalButton", typeof(UtilityOvalButtonAttributes));
            Button.RegisterStyle("FoodOvalButton", typeof(FoodOvalButtonAttributes));
            Button.RegisterStyle("FamilyOvalButton", typeof(FamilyOvalButtonAttributes));
            Button.RegisterStyle("KitchenOvalButton", typeof(KitchenOvalButtonAttributes));

            Controls.Pagination.RegisterStyle("BasicPagination", typeof(BasicPaginationAttributes));

            CheckBox.RegisterStyle("UtilityCheckBox", typeof(UtilityCheckBoxAttributes));
            CheckBox.RegisterStyle("FoodCheckBox", typeof(FoodCheckBoxAttributes));
            CheckBox.RegisterStyle("FamilyCheckBox", typeof(FamilyCheckBoxAttributes));
            CheckBox.RegisterStyle("KitchenCheckBox", typeof(KitchenCheckBoxAttributes));

            RadioButton.RegisterStyle("UtilityRadioButton", typeof(UtilityRadioButtonAttributes));
            RadioButton.RegisterStyle("FoodRadioButton", typeof(FoodRadioButtonAttributes));
            RadioButton.RegisterStyle("FamilyRadioButton", typeof(FamilyRadioButtonAttributes));
            RadioButton.RegisterStyle("KitchenRadioButton", typeof(KitchenRadioButtonAttributes));

            Switch.RegisterStyle("UtilitySwitch", typeof(UtilitySwitchAttributes));
            Switch.RegisterStyle("FoodSwitch", typeof(FoodSwitchAttributes));
            Switch.RegisterStyle("FamilySwitch", typeof(FamilySwitchAttributes));
            Switch.RegisterStyle("KitchenSwitch", typeof(KitchenSwitchAttributes));

            ScrollBar.RegisterStyle("DAScrollbar", typeof(FH.NUI.Controls.DAScrollBarAttributes));
            ScrollBar.RegisterStyle("VDScrollbar", typeof(FH.NUI.Controls.VDScrollBarAttributes));

            Progress.RegisterStyle("FamilyProgressbar", typeof(FH.NUI.Controls.FamilyProgressbarAttributes));
            Progress.RegisterStyle("FoodProgressbar", typeof(FH.NUI.Controls.FoodProgressbarAttributes));
            Progress.RegisterStyle("KitchenProgressbar", typeof(FH.NUI.Controls.KitchenProgressbarAttributes));
            Progress.RegisterStyle("UtilityProgressbar", typeof(FH.NUI.Controls.UtilityProgressbarAttributes));
            ProgressCircle.RegisterStyle("VDProgressCircle", typeof(FH.NUI.Controls.VDProgressCircleAttributes));

            Popup.RegisterStyle("DAPopup", typeof(DAPopupAttributes));
            Button.RegisterStyle("UtilityPopupButton", typeof(UtilityPopupButtonAttributes));
            Button.RegisterStyle("FoodPopupButton", typeof(FoodPopupButtonAttributes));
            Button.RegisterStyle("FamilyPopupButton", typeof(FamilyPopupButtonAttributes));
            Button.RegisterStyle("KitchenPopupButton", typeof(KitchenPopupButtonAttributes));

            Tab.RegisterStyle("DATab", typeof(DATabAttributes));

            Slider.RegisterStyle("UtilityDefaultSlider", typeof(UtilityDefaultSliderAttributes));
            Slider.RegisterStyle("FoodDefaultSlider", typeof(FoodDefaultSliderAttributes));
            Slider.RegisterStyle("FamilyDefaultSlider", typeof(FamilyDefaultSliderAttributes));
            Slider.RegisterStyle("KitchenDefaultSlider", typeof(KitchenDefaultSliderAttributes));
            Slider.RegisterStyle("UtilityTextSlider", typeof(UtilityTextSliderAttributes));
            Slider.RegisterStyle("FoodTextSlider", typeof(FoodTextSliderAttributes));
            Slider.RegisterStyle("FamilyTextSlider", typeof(FamilyTextSliderAttributes));
            Slider.RegisterStyle("KitchenTextSlider", typeof(KitchenTextSliderAttributes));

            Tizen.FH.NUI.Controls.InputField.RegisterStyle("FamilyDefaultInputField", typeof(FamilyDefaultInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("FamilyStyleBInputField", typeof(FamilyStyleBInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("FoodDefaultInputField", typeof(FoodDefaultInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("FoodStyleBInputField", typeof(FoodStyleBInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("KitchenDefaultInputField", typeof(KitchenDefaultInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("KitchenStyleBInputField", typeof(KitchenStyleBInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("UtilityDefaultInputField", typeof(UtilityDefaultInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("UtilityStyleBInputField", typeof(UtilityStyleBInputFieldAttributes));
            Tizen.FH.NUI.Controls.InputField.RegisterStyle("DefaultSearchInputField", typeof(DefaultSearchInputFieldAttributes));

            Tizen.FH.NUI.Controls.SearchBar.RegisterStyle("DefaultSearchBar", typeof(DefaultSearchBarAttributes));

            Tizen.FH.NUI.Controls.Toast.RegisterStyle("BasicToast", typeof(BasicToastAttributes));
        }
        private void CleanupComponent()
        {
        }
    }
}
