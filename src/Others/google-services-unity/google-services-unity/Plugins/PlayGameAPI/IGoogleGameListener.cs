using System;
using UnityEngine;

namespace com.google.game
{
    // Interface for the methods to be invoked by the native plugin.
	internal interface IGoogleGameListener
    {
        void onGameEvent(string eventName,string eventData);
        void onGetSnapshotData(string snapshotMeta, AndroidJavaObject snapshotData);
        //void onGetSnapshotData(string snapshotMeta, byte[] snapshotData);
        
    }
}
