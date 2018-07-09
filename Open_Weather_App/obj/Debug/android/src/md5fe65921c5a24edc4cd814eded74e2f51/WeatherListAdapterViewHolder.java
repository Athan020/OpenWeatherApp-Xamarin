package md5fe65921c5a24edc4cd814eded74e2f51;


public class WeatherListAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Open_Weather_App.WeatherListAdapterViewHolder, Open_Weather_App", WeatherListAdapterViewHolder.class, __md_methods);
	}


	public WeatherListAdapterViewHolder ()
	{
		super ();
		if (getClass () == WeatherListAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("Open_Weather_App.WeatherListAdapterViewHolder, Open_Weather_App", "", this, new java.lang.Object[] {  });
	}

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
