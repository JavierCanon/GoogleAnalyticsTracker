#if UNITY_ANDROID
#endif
using UnityEngine;
using System.Collections;
namespace com.google.game
{
	public class IRealTimeMessageListenerProxy : AndroidJavaProxy {
		private IRealTimeMessageListener listener;
		internal IRealTimeMessageListenerProxy(IRealTimeMessageListener listener)
            : base("com.google.service.IRealTimeMessageListener")
		{
			this.listener = listener;
		}
         void onGameEvent(string eventName,string eventData){
           //  Debug.Log("c# gamelisterproxy "+eventGroup+"   "+eventName+"   "+eventData);
             if(listener!=null)
			listener.onGameEvent(eventName,eventData);
         }
        
	
	}
}
