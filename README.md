# CommonUI dev branch
This branch used to develop new common ui components.


Windows backend run steps:

1. Clone code
2. Run bat files in .\Dali\windows-dependencies\prebuild.bat setenv.bat to configure build environment
3. Open .\demo\csharp-demo\csharp-demo.sln with VS2017
4. Modify all C++ projects Windows SDK version to your version (1.right click on c++ project; 2.Property->General -> Windows SDK version)
5.Build Dali related prj as following order dali-core dali-adapter dali-toolkit dali-csharp-binder dali-extension-tv libcapi-appfw-app-common libcapi-appfw-app-manager
6. Build csharp-demo
7. Run


