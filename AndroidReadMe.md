# IndigoOliveWPFVISX.vsix and Android

If you use the IndigoOliveWPFVSIX.vsix MasterDetailPCLMaps or the IndigoOliveNETVSIX.vsix MasterDetailNETMaps installer and you run Xamarin.Forms version 2.3.4.231(Default) or Xamarin.Forms version 2.5.0.91635(NET).  If you change to a newer or older version you will need to adjust the Android app as follows:

## AndroidManifest.xml

In the AndroidManifest.xml about line 30 you need to un-comment the following line:

    <meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />

## CustomMapRenderer

### Un-Comment this section on or about line 25:

    public CustomMapRenderer(Context context) : base(context) {
        AutoPackage = false;
    }

### Un-Comment the line on or about line 54:

    protected override void OnMapReady(GoogleMap googleMap)
	
### Comment out the line on or about line 55:

    public void OnMapReady (GoogleMap googleMap)

# MyProject.Android

### on or about line 129

If your project name ends in .Android then you will need to change this line from:

    public Android.Views.View GetInfoContents(Marker marker) {
	
to

    public global::Android.Views.View GetInfoContents(Marker marker) {
	
### on or about line 164

If your project name ends in .Android then you will need to change this line from:

    public Android.Views.View GetInfoWindow(Marker marker) {
	
to

    public global::Android.Views.View GetInfoWindow(Marker marker) {
	

## Older versions of Xamarin

The versions of Xamarin 2.3.4.231 and older will not require all of these changes.
	
## VSIX does not need these changes.

All the projects and solutions built for Android from any of the VSIX installers, do not need any of these changes.

## Authors

John Russell - Senior Software Engineer II - Indigo Olive Software, Inc.

