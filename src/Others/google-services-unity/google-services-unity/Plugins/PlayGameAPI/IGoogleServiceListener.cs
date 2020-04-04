using System;

namespace com.google.game
{
    // Interface for the methods to be invoked by the native plugin.
	internal interface IGoogleServiceListener
    {
        void onServiceEvent(string eventName,string eventData);
    }
}
