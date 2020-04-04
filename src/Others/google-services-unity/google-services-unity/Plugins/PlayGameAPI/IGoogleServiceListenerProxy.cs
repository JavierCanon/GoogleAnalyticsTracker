#if UNITY_ANDROID
#endif
using UnityEngine;
using System.Collections;
namespace com.google.game
{
	public class IGoogleServiceListenerProxy : AndroidJavaProxy {
		private IGoogleServiceListener listener;
		internal IGoogleServiceListenerProxy(IGoogleServiceListener listener)
            : base("com.google.service.IGoogleServiceListener")
		{
			this.listener = listener;
		}
         void onServiceEvent(string eventName,string eventData){
           //  Debug.Log("c# gamelisterproxy "+eventGroup+"   "+eventName+"   "+eventData);
             if(listener!=null)
			listener.onServiceEvent(eventName,eventData);
         }
        

	}
}
