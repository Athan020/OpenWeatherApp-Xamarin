package md5fe65921c5a24edc4cd814eded74e2f51;


public class WeatherDetailsActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Open_Weather_App.WeatherDetailsActivity, Open_Weather_App", WeatherDetailsActivity.class, __md_methods);
	}


	public WeatherDetailsActivity ()
	{
		super ();
		if (getClass () == WeatherDetailsActivity.class)
			mono.android.TypeManager.Activate ("Open_Weather_App.WeatherDetailsActivity, Open_Weather_App", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
