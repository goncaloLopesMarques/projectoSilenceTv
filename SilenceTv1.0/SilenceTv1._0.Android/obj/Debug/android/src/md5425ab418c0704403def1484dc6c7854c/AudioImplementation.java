package md5425ab418c0704403def1484dc6c7854c;


public class AudioImplementation
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SilenceTv1._0.Droid.AudioImplementation, SilenceTv1._0.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AudioImplementation.class, __md_methods);
	}


	public AudioImplementation () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AudioImplementation.class)
			mono.android.TypeManager.Activate ("SilenceTv1._0.Droid.AudioImplementation, SilenceTv1._0.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
