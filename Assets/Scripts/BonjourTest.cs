using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Couchbase.Lite;
using Couchbase.Lite.Listener;
using Mono.Zeroconf;





public class BonjourTest : MonoBehaviour{

	CouchbaseLiteServiceBrowser browser;
	CouchbaseLiteServiceBroadcaster broadcaster;

	public void StartBrowsing()
	{
		Debug.Log ("Started browser");
		Mono.Zeroconf.Providers.Bonjour.ServiceBrowser b = new Mono.Zeroconf.Providers.Bonjour.ServiceBrowser (); 
		browser = new CouchbaseLiteServiceBrowser(b);

		browser.ServiceResolved += (sender, e) => {
			Debug.Log( "Discovered service: 1 : "+ e.Service.Name);
		};


		browser.ServiceResolved += (sender, e) => {
			Debug.Log( "Discovered service: 2 : "+ e.Service.HostEntry);
		};

		browser.Start();
	}


	public void StopBrowsing()
	{
		Debug.Log ("Stopped browsing");
		browser.Stop ();
	}

	public void Broadcast()
	{
		Debug.Log ("Started broadcasting");
		Mono.Zeroconf.Providers.Bonjour.RegisterService r = new Mono.Zeroconf.Providers.Bonjour.RegisterService (); 
		broadcaster = new CouchbaseLiteServiceBroadcaster(r, 59840);
		broadcaster.Name = "TushariPad";
		broadcaster.Start();
	}

	public void StopBroadcasting()
	{
		Debug.Log ("Stopped broadcasting");
		broadcaster.Stop ();
	}
}
