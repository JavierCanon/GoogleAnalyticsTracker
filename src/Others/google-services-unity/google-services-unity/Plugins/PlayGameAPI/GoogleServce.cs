using UnityEngine;
namespace com.google.game
{
    public class GoogleServce
    {
        public delegate void GoogleServiceEventHandler(string eventName, string msg);
        public event GoogleServiceEventHandler googleEventHandler;
       
        private static GoogleServce _instance;

        public static GoogleServce Instance()
        {
            if (_instance == null)
            {
                _instance = new GoogleServce();
                _instance.preInitGame();
            }
            return _instance;
        }
//#if UNITY_ANDROID
#if UNITY_EDITOR
        private void preInitGame()
		{
		}
        public void sign(string[] scopes)
        {
           Debug.Log("calling login");
        }
        public void signOut()
        {
          
        }
        public bool isSignedIn()
        {
            return false;
        }
        public bool checkServiceAvailable()
        {
            return false;
        }


#elif UNITY_ANDROID
//#elif UNITY_EDITOR
        private AndroidJavaObject jgame;
        private void preInitGame()
        {
            if (jgame == null)
            {
                AndroidJavaClass gameUnityPluginClass = new AndroidJavaClass("com.google.service.GoogleServiceAPI");
                jgame = gameUnityPluginClass.CallStatic<AndroidJavaObject>("getInstance");
                GoogleServiceListener googleServiceListener = new GoogleServiceListener();
                googleServiceListener.googleInstance = this;
                jgame.Call("setListener", new object[] { new IGoogleServiceListenerProxy(googleServiceListener) });
            }
        }
        public void sign(string[] scopes)
        {
            jgame.Call("login", new object[] { scopes });
        }
        public void signOut()
        {
            jgame.Call("signOut");
        }
        public bool isSignedIn()
        {
            return jgame.Call<bool>("isSignedIn");
        }
        public bool checkServiceAvailable()
        {
            return jgame.Call<bool>("checkServiceAvailable");
        }
        class GoogleServiceListener : IGoogleServiceListener
        {
            internal GoogleServce googleInstance;
            public void onServiceEvent(string eventName, string paramString)
            {
                if (googleInstance.googleEventHandler != null)
                    googleInstance.googleEventHandler(eventName, paramString);
            }
        }  
#endif
    }
}
