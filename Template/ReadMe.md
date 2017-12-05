# To create the template from the files here do the following:

1) Go into the directory:
    
    FilesToCreateTemplate

2) With your mouse select all the files so that you have selected:

    CPXFApp
    CPXFApp.Android
    CPXFApp.iOS
    CPXFApp.UWP
    CPXFApp.WPF
    __icon.ico
    __PreviewImage.jpg
    CrossPlatformAppXamarin.vstemplate

3) With the above files selected, right click and select:
   Send->Compressed Zip File

4) Give that file the name: CrossPlatformAppXamarin.zip when asked for a name.


# How to Use this file:

1) copy this file to the following folder:
    C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#
so now you have:
    C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\CrossPlatformAppXamarin.zip
2) Close all instances of Visual Studio 2017
3) Open up the Visual Studio 2017 Developer Command Prompt for VS 2017
     To find this command prompt, go to start, Visual Studio 2017 (folder) and select "Developer Command Prompt for VS 2017"
4) In that command prompt type: devenv /installvstemplates
5) Start Visual Studio 2017
6) Select New->Project
7) Select Visual C#
8) Select "Cross Platform Xamarin.Forms (UWP/Android/iOS/WPF) and Maps"
9) Enter a project name and location.

That is it.

Just set WPF version to the Start Up Project
add a License key
build
and Run.

# If you would like to Un-Install the Template:

1) Close all instances of Visual Studio 2017
2) Delete the file:   C:\Users\<YOUR USER>\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\CrossPlatformAppXamarin.zip
3) Open up the Visual Studio 2017 Developer Command Prompt for VS 2017
     To find this command prompt, go to start, Visual Studio 2017 (folder) and select "Developer Command Prompt for VS 2017"
4) In that command prompt type: devenv /installvstemplates

Now it is gone.