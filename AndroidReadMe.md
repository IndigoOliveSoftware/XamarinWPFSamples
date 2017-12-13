# IndigoOliveWPFVISX.vsix and Android

If you use the IndigoOliveWPFVISX.vsix MasterDetailPCLMaps installer and you run Xamarin.Forms version 2.3.4.231 you will need to adjust the Android app as follows:

## AndroidManifest.xml

In the AndroidManifest.xml about line 30 you need to comment out the following line:

    <meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />

## CustomMapRenderer

### Comment out this section on or about line 25:

    public CustomMapRenderer(Context context) : base(context) {
        AutoPackage = false;
    }

### Comment out the line on or about line 54:

    protected override void OnMapReady(GoogleMap googleMap)
	
### Un-Comment the line on or about line 55:

    public void OnMapReady (GoogleMap googleMap)

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
	

## Newer versions of Xamarin

The newer versions of Xamarin will not require all of these changes.
	
