# Use the IndigoOliveWPFVISX.vsix Instead.

[Use IndigoOliveWPFVISX.vsix Instead](../ReadMe.md)

The IndigoOliveWPFVISX.vsix can create Solutions OR Projects!

In development right now is IndigoOliveWPF_NET_VSIX.vsix. Which will handle the new .NET Standard Library!

But if you must do it the hard way then continue reading.

# How to Use the MasterDetailPCLMaps.zip file:

same for the files:

EmptyPCL.zip

EmptyShare.zip

MasterDetailPCL.zip

MasterDetailShare.zip

1) Create this folder:
    C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\Cross-Platform
2) copy this file to the following folder:
    C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\Cross-Platform
so now you have:
    C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\Cross-Platform\MasterDetailPCLMaps.zip
3) Close all instances of Visual Studio 2017
4) Open up the Visual Studio 2017 Developer Command Prompt for VS 2017
     To find this command prompt, go to start, Visual Studio 2017 (folder) and select "Developer Command Prompt for VS 2017"
5) In that command prompt type: devenv /installvstemplates
6) Start Visual Studio 2017
7) Select New->Project
8) Select Visual C#
9) Select Cross-Platform
10) Select "Android-iOS-UWP-WPF Master Detail PCL Maps"
11) Enter a project name and location.

That is it.

Just set WPF version to the Start Up Project
add a License key
build
and Run.

# If you would like to Un-Install the Template:

same for the files:

EmptyPCL.zip

EmptyShare.zip

MasterDetailPCL.zip

MasterDetailShare.zip

1) Close all instances of Visual Studio 2017
2) Delete the file:   C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\Cross-Platform\MasterDetailPCLMaps.zip
3) Open up the Visual Studio 2017 Developer Command Prompt for VS 2017
     To find this command prompt, go to start, Visual Studio 2017 (folder) and select "Developer Command Prompt for VS 2017"
4) In that command prompt type: devenv /installvstemplates

Now it is gone.


# To create the template from the files here do the following:

same for the files:

EmptyPCL.zip

EmptyShare.zip

MasterDetailPCL.zip

MasterDetailShare.zip

1) Go into the directory:
    
    MasterDetailPCLMaps

2) With your mouse select all the files so that you have selected:

    CPXFApp
    CPXFApp.Android
    CPXFApp.iOS
    CPXFApp.UWP
    CPXFApp.WPF
    __icon.ico
    __PreviewImage.jpg
    MasterDetailPCLMaps.vstemplate

3) With the above files selected, right click and select:
   Send->Compressed Zip File

4) Give that file the name: MasterDetailPCLMaps.zip when asked for a name.
