#if UNITY_ANDROID
#endif
using UnityEngine;
using System.Collections;
namespace com.google.game
{
	public class IGoogleGameListenerProxy : AndroidJavaProxy {
		private IGoogleGameListener listener;
		internal IGoogleGameListenerProxy(IGoogleGameListener listener)
            : base("com.google.service.IGoogleGameListener")
		{
			this.listener = listener;
		}
         void onGameEvent(string eventName,string eventData){
           //  Debug.Log("c# gamelisterproxy "+eventGroup+"   "+eventName+"   "+eventData);
             if(listener!=null)
			listener.onGameEvent(eventName,eventData);
         }
         void onGetSnapshotData(string snapshotMeta, AndroidJavaObject snapshotData){
         	if(listener!=null)
			listener.onGetSnapshotData(snapshotMeta,snapshotData);
         }

	}
}
