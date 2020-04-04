using UnityEngine;
using com.google.game;
using LitJson;
using System.Collections;
using admob;
public class playgamedemo : MonoBehaviour {

    // Use this for initialization
    string appID;
	string bannerID="";
	string interstitialID="";
	string videoID="";
    GoogleServce googleService;
	GoogleGame game;
	void Start () {
        Debug.Log("start unity demo-------------");
#if UNITY_IOS
        		 appID="ca-app-pub-3940256099942544~1458002511";
				 bannerID="ca-app-pub-3940256099942544/2934735716";
				 interstitialID="ca-app-pub-3940256099942544/4411468910";
				 videoID="ca-app-pub-3940256099942544/1712485313";
#elif UNITY_ANDROID
        		 appID="ca-app-pub-3940256099942544~3347511713";
				 bannerID="ca-app-pub-3940256099942544/6300978111";
				 interstitialID="ca-app-pub-3940256099942544/1033173712";
				 videoID="ca-app-pub-3940256099942544/5224354917";
#endif
        googleService = GoogleServce.Instance();
        googleService.googleEventHandler += onGoogleEvent;
        Admob.Instance().initSDK(appID, null);
        Admob.Instance().rewardedVideoEventHandler += onRewardedVideoEvent;

        FirebaseAnalytic.Instance().logEvent("appstart", "{\"name\":\"joe\"}");//the second param must been json string
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator saveGameSnapshot() {
        yield return new WaitForEndOfFrame();
        //Rect rect = new Rect(Screen.width*0.25f,Screen.height*0.25f,Screen.width * 0.5f, Screen.height * 0.5f);
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
        byte[] bytes = screenShot.EncodeToPNG();
        game.saveSnapshot("secondsnapshot",bytes , System.Text.Encoding.UTF8.GetBytes("{'score':20,'player':'jame222'}"));
        yield return null;
    }

    void OnGUI(){
        if (GUI.Button(new Rect(240, 480, 100, 60), "admobbanner"))
        {
            Admob.Instance().showBannerRelative(bannerID,AdSize.BANNER, AdPosition.BOTTOM_CENTER, 30, "defaultBanner");
        }
        if (GUI.Button(new Rect(360, 480, 100, 60), "admobInstitial"))
        {
            if (Admob.Instance().isInterstitialReady())
            {
                Admob.Instance().showInterstitial();
            }
            else
            {
                Admob.Instance().loadInterstitial(interstitialID);
            }
        }
        if (GUI.Button(new Rect(0, 580, 100, 60), "admobVideo"))
        {
            if (Admob.Instance().isRewardedVideoReady())
            {
                Admob.Instance().showRewardedVideo();
            }
            else
            {
                Admob.Instance().loadRewardedVideo(videoID);
            }
        }


        if (GUI.Button(new Rect(0, 0, 100, 60), "login"))
		{
            googleService.sign(null);
		}
        if (game == null)
        {
           // Debug.Log("you should login before call game func");
            return ;
        }
        if (GUI.Button(new Rect(120, 0, 100, 60), "loginout"))
        {
            googleService.signOut();
        }
        if (GUI.Button(new Rect(240, 0, 100, 60), "Leaderboards"))
        {
            game.showLeaderboards();
        }
        if (GUI.Button(new Rect(360, 0, 100, 60), "Achieve"))
        {
			game.showAchievements ();
        }
        if (GUI.Button(new Rect(0, 80, 100, 60), "loadevents"))
        {
            game.loadEvent(false);
        }

        if (GUI.Button(new Rect(120, 80, 100, 60), "playerinfo"))
        {
            game.loadPlayerInfo();
        }
        if (GUI.Button(new Rect(240, 80, 100, 60), "loadAchi"))
        {
            game.loadAchievements(false);
        }
        if (GUI.Button(new Rect(360, 80, 100, 60), "leadermeta"))
        {
            game.loadLeaderboardMetadatas(false);
        }
        if (GUI.Button(new Rect(0, 160, 100, 60), "topscores"))
        {
            game.loadTopScores("CgkItJ_UzNUHEAIQCQ", GameConst.TIME_SPAN_ALL_TIME, GameConst.COLLECTION_PUBLIC, 10, false);
        }
        if (GUI.Button(new Rect(120, 160, 100, 60), "unlockachi"))
        {
            game.unlockAchievement("CgkItJ_UzNUHEAIQBA");
        }
       
        if (GUI.Button(new Rect(360, 160, 100, 60), "submitscore"))
        {
            game.submitLeaderboardScore("CgkItJ_UzNUHEAIQCQ", 1000L);
        }
        if (GUI.Button(new Rect(0, 240, 100, 60), "mroeScore"))
        {
            game.loadMoreTopScores(10,GameConst.PageDirectionNEXT);
        }
       
        if (GUI.Button(new Rect(240, 240, 100, 60), "showsnaps"))
        {
            game.showSnapshot("saved games", true, true, 10);
        }
        if (GUI.Button(new Rect(360, 240, 100, 60), "loadSnapMetas"))
        {
            game.loadSnapshotMetas(false);
        }
        if (GUI.Button(new Rect(0, 320, 100, 60), "writesnap"))
        {
            StartCoroutine(saveGameSnapshot());
        }
        if (GUI.Button(new Rect(120, 320, 100, 60), "readsnap"))
        {
            game.getSnapshotContent("secondsnapshot");
        }
        if (GUI.Button(new Rect(240, 320, 100, 60), "Invite"))
        {
           
            game.showSelectRTOpponentsBox(2,2,0,true);
        }
        if (GUI.Button(new Rect(360, 320, 100, 60), "Invitation"))
        {
            
            game.showInvitationInbox();
        }
        if (GUI.Button(new Rect(0, 400, 100, 60), "roomPanel"))
        {
            if (roomID != null)
            game.showRTWaitingRoom(roomID, 4);

        }
        if (GUI.Button(new Rect(120, 400, 100, 60), "createRoom"))
        {
            game.createRTGameRoom(1, 2, 0, null);
        }
        if (GUI.Button(new Rect(240, 400, 100, 60), "leaveRoom"))
        {
            if(roomID!=null)
            game.leaveRTRoom(roomID);
        }
       
        if (GUI.Button(new Rect(0, 480, 100, 60), "showTBInvitePanel"))
        {
            game.showSelectTurnbasedOpponentsBox(1, 2, true);
        }
        if (GUI.Button(new Rect(120, 480, 100, 60), "createTBRoom"))
        {
            
            game.createTurnbasedMatch(1, 2, null);
        }
    }
  

	void onGameEvent(string eventName,string data){
		Debug.Log (eventName + "------&&-----" + data);
        if (eventName == GameEvent.onLoadSnapshotMetasResult)
        {
            JsonData result = JsonMapper.ToObject(data);
            if ((int)result["status"] == GameConst.RESULT_OK)
            {
                JsonData data2 = (JsonData)result["data"];
                for (int i = 0; i < data2.Count; i++)
                {
                    Debug.Log("snapshotID "+data2[i]["snapshotID"]+ "  uniqueName " + data2[i]["uniqueName"]);
                }
            }
        }
	    else if(eventName == GameEvent.onShowSnapshotsResult)
        {
            JsonData result = JsonMapper.ToObject(data);
            if ((int)result["status"] == GameConst.RESULT_OK)
            {
                JsonData data3 = (JsonData)result["data"];
                Debug.Log("snapshotID " + data3["snapshotID"] + "  uniqueName " + data3["uniqueName"]);
              //  game.getSnapshotContent((string)data3["uniqueName"]);
            }
	    }
        else if (eventName == GameEvent.onSaveSnapshotResult)
        {
            JsonData result = JsonMapper.ToObject(data);
            if ((int)result["status"] == GameConst.RESULT_OK)
            {
                JsonData data3 = (JsonData)result["data"];
                data3["owner"] = "ownerdelete";
                Debug.Log("save data "+data3.ToJson());
                Debug.Log("snapshotID " + data3["snapshotID"] + "  uniqueName " + data3["uniqueName"]);
            }
        }
	}

    //----------------------------------------------------------------------
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
    }
    void onSnapshotLoaded(string snapmeta, byte[] data)
    {
       // Debug.Log(eventName + "-----------" + data);
        string snapstring = System.Text.Encoding.UTF8.GetString(data);
        Debug.Log("saved game content:" + snapstring);
    }
    JsonData room;
    string roomID;
    void onRTGameEvent(string eventName, string data)
    {
        Debug.Log(eventName + "----###------" + data);
        if (eventName == RTGameEvent.onRoomCreatedSuccess)
        {
            room = JsonMapper.ToObject(data);
            roomID = (string)room["roomID"];
        }
    }
    void onGoogleEvent(string eventName, string data)
    {
        Debug.Log(eventName + "----***-------" + data);
        if (eventName == GoogleServiceEvent.onSignInSuccess)
        {
            game = GoogleGame.Instance();
            game.gameEventHandler += onGameEvent;
            game.snapshotDataHandler += onSnapshotLoaded;
            game.rtgameEventHandler += onRTGameEvent;
        }
    }
}
