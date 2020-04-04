using UnityEngine;
namespace com.google.game
{
    public class GoogleGame
    {
        public delegate void GameEventHandler(string eventName, string msg);
        public delegate void SnapshotOpenHandler(string snapshotmeta, byte[] data);
        public delegate void RTgameEventHandler(string eventName, string msg);

        public event GameEventHandler gameEventHandler;
        public event SnapshotOpenHandler snapshotDataHandler;
        public event RTgameEventHandler rtgameEventHandler;
        private static GoogleGame _instance;

        public static GoogleGame Instance()
        {
            if (_instance == null)
            {
                _instance = new GoogleGame();
                _instance.preInitGame();
            }
            return _instance;
        }
//#if UNITY_ANDROID
#if UNITY_EDITOR

        private void preInitGame()
		{
		}

		 public void registerInvitationListener()
        {
            
        }
        public void registerTurnBasedMatchUpdateListener()
        {
            
        }
        public void loadPlayerInfo()
        {
            
        }
        public void getActivationHint(string type)
        {
            
        }

        public void showInvitationInbox()
        {

        }

        public void unlockAchievement(string achievementId)
        {
            
        }
        public void revealAchievement(string achievementId)
        {
            
        }
        public void incrementAchievement(string achievementId,int step)
        {
            
        }
        public void setAchievementStep(string achievementId, int step)
        {
            
        }
        public void showAchievements()
        {
            
        }
        public void loadAchievements(bool forceReload)
        {
            
        }
        public void submitLeaderboardScore(string leaderboardID, long score)
        {
           
        }
        public void showLeaderboard(string leaderboardID)
        {
           
        }
        public void showLeaderboards()
        {
           
        }
        public void loadLeaderboardMetadata(string leaderboardID, bool forceReload)
        {
           
        }
        public void loadLeaderboardMetadatas( bool forceReload)
        {
           
        }
        public void loadTopScores(string leaderboardId, int span, int leaderboardCollection, int maxResults, bool forceReload)
        {
           
        }
        public void loadMoreTopScores(int maxResults, int pageDirection)
        {
            
        }
        public void loadMorePlayerCenteredScores(int maxResults, int pageDirection)
        {
            
        }
        public void loadPlayerCenteredScores(string leaderboardId, int span, int leaderboardCollection, int maxResults, bool forceReload)
        {
            
        }
        public void loadCurrentPlayerLeaderboardScore(string leaderboardId, int span, int leaderboardCollection)
        {
            
        }

        public void showSnapshot(string title, bool allowAddButton, bool allowDelete, int maxSnapshots)
        {
            
        }
        public void loadSnapshotMetas(bool forceReload)
        {
            
        }
        public void saveSnapshot(string uniqueName,  byte[] screenShotImage, byte[] gameContent)
        {
            
        }
        public void deleteSnapshot(string uniqueName)
        {
            
        }
        public void getSnapshotContent(string uniqueName)
        {
            
        }

        public void showSelectRTOpponentsBox(int minAutoMatchPlayers, int maxAutoMatchPlayers, long exclusiveBitMask,bool allowAutomatch)
        {
            
        }
        public void createRTGameRoom(int minAutoMatchPlayers, int maxAutoMatchPlayers, long exclusiveBitMask, string[] invitees)
        {
            
        }
        public void leaveRTRoom(string roomID)
        {
            
        }
        public void showRTWaitingRoom(string roomID, int maxPlayerToStartGame)
        {
            
        }
        public void acceptRTInvite(string invitationId)
        {
            
        }
        public void dismissRTInvitation(string invitationId)
        {
            
        }
        public void declineRTInvitation(string invitationId)
        {
           
        }
       
        public void loadRTInvitations()
        {
           
        }
        public void sendReliableMessage(byte[] messageData, string roomId, string recipientParticipantId)
        {
           
        }
        public void sendUnreliableMessage(byte[] messageData, string roomId, string recipientParticipantId)
        {
           
        }
        public void sendUnreliableMessages(byte[] messageData, string roomId, string[] recipientParticipantIds)
        {
           
        }
        public void sendUnreliableMessageToOthers(byte[] messageData, string roomId)
        {
           
        }
        public void showSelectTurnbasedOpponentsBox(int minAutoMatchPlayers, int maxAutoMatchPlayers, bool allowAutomatch)
        {
           
        }
        public void createTurnbasedMatch(int minAutoMatchPlayers, int maxAutoMatchPlayers, string[] invitees)
        {
           
        }
        public void cancelTurnBasedMatch(string matchId)
        {
           
        }
        public void dismissTurnBasedMatch(string matchId)
        {
           
        }
        public void finishTurnbasedMatch(string matchId, byte[] matchData)
        {
           
        }
        public void leaveTurnBasedMatch(string matchId)
        {
           
        }
        public void leaveMatchDuringTurn(string matchId, string pendingParticipantId)
        {
           
        }
        public void loadTurnBasedMatch(string matchId)
        {
           
        }
        public void loadTurnBasedMatches(int invitationSortOrder, int[] matchTurnStatuses)
        {
           
        }
        public void rematchTurnBased(string matchId)
        {
           
        }
        public void takeTurn(string matchId, byte[] matchData, string pendingParticipantId)
        {
           
        }
        public void acceptTurnBasedInvitation(string invitationId)
        {
           
        }
        public void declineTurnBasedInvitation(string invitationId)
        {
           
        }
        public void dismissTurnBasedInvitation(string invitationId)
        {
           
        }
        public void showTurnbasedInvitationInbox()
        {
           
        }
        public void incrementEvent(string eventId, int incrementAmount)
        {
           
        }
        public void loadEvent(bool forceReload)
        {
           
        }
        public void loadEventByIds(bool forceReload, string[] eventIds)
        {
           
        }
        public void loadGameStates(bool forceReload)
        {
           
        }


#elif UNITY_ANDROID
//#elif UNITY_EDITOR
        private AndroidJavaObject jgame;
        private void preInitGame()
        {
            if (jgame == null)
            {
                AndroidJavaClass gameUnityPluginClass = new AndroidJavaClass("com.google.service.GoogleGameAPI");
                jgame = gameUnityPluginClass.CallStatic<AndroidJavaObject>("getInstance");
                GoogleGameListener googleGameListener = new GoogleGameListener();
                googleGameListener.gameInstance = this;
                RealTimeMessageListener rtListener = new RealTimeMessageListener();
                rtListener.gameInstance = this;
                jgame.Call("setListener", new object[] { new IGoogleGameListenerProxy(googleGameListener) });
                jgame.Call("setRTListener", new object[] { new IRealTimeMessageListenerProxy(rtListener) });
            }
        }
        public void registerInvitationListener()
        {
            jgame.Call("registerInvitationListener");
        }
        public void registerTurnBasedMatchUpdateListener()
        {
            jgame.Call("registerTurnBasedMatchUpdateListener");
        }
        public void loadPlayerInfo()
        {
            jgame.Call("loadPlayerInfo");
        }
        public void getActivationHint()
        {
            jgame.Call("getActivationHint");
        }

        public void showInvitationInbox()
        {
            jgame.Call("showInvitationInbox");
        }

        public void unlockAchievement(string achievementId)
        {
            jgame.Call("unlockAchievement", new object[] { achievementId });
        }
        public void revealAchievement(string achievementId)
        {
            jgame.Call("revealAchievement", new object[] { achievementId });
        }
        public void incrementAchievement(string achievementId,int step)
        {
            jgame.Call("incrementAchievement", new object[] { achievementId, step });
        }
        public void setAchievementStep(string achievementId, int step)
        {
            jgame.Call("setAchievementStep", new object[] { achievementId, step });
        }
        public void showAchievements()
        {
            jgame.Call("showAchievements");
        }
        public void loadAchievements(bool forceReload)
        {
            jgame.Call("loadAchievements", new object[] { forceReload });
        }
        public void submitLeaderboardScore(string leaderboardID, long score)
        {
            jgame.Call("submitLeaderboardScore", new object[] { leaderboardID, score });
        }
        public void showLeaderboard(string leaderboardID)
        {
            jgame.Call("showLeaderboard", new object[] { leaderboardID });
        }
        public void showLeaderboards()
        {
            jgame.Call("showLeaderboards");
        }
        public void loadLeaderboardMetadata(string leaderboardID, bool forceReload)
        {
            jgame.Call("loadLeaderboardMetadata", new object[] { leaderboardID, forceReload });
        }
        public void loadLeaderboardMetadatas( bool forceReload)
        {
            jgame.Call("loadLeaderboardMetadatas", new object[] { forceReload });
        }
        public void loadTopScores(string leaderboardId, int span, int leaderboardCollection, int maxResults, bool forceReload)
        {
            jgame.Call("loadTopScores", new object[] { leaderboardId, span, leaderboardCollection, maxResults,forceReload });
        }
        public void loadMoreTopScores(int maxResults, int pageDirection)
        {
            jgame.Call("loadMoreTopScores", new object[] { maxResults, pageDirection });
        }
        public void loadMorePlayerCenteredScores(int maxResults, int pageDirection)
        {
            jgame.Call("loadMorePlayerCenteredScores", new object[] { maxResults, pageDirection });
        }
        public void loadPlayerCenteredScores(string leaderboardId, int span, int leaderboardCollection, int maxResults, bool forceReload)
        {
            jgame.Call("loadPlayerCenteredScores", new object[] { leaderboardId, span, leaderboardCollection, maxResults , forceReload });
        }
        public void loadCurrentPlayerLeaderboardScore(string leaderboardId, int span, int leaderboardCollection)
        {
            jgame.Call("loadCurrentPlayerLeaderboardScore", new object[] { leaderboardId, span, leaderboardCollection});
        }

        public void showSnapshot(string title, bool allowAddButton, bool allowDelete, int maxSnapshots)
        {
            jgame.Call("showSnapshot", new object[] { title, allowAddButton, allowDelete,maxSnapshots });
        }
        public void loadSnapshotMetas(bool forceReload)
        {
            jgame.Call("loadSnapshotMetas", new object[] { forceReload });
        }
        public void saveSnapshot(string uniqueName,  byte[] screenShotImage, byte[] gameContent)
        {
            jgame.Call("saveSnapshot", new object[] { uniqueName, screenShotImage, gameContent });
        }
        public void deleteSnapshot(string uniqueName)
        {
            jgame.Call("deleteSnapshot", new object[] { uniqueName});
        }
        public void getSnapshotContent(string uniqueName)
        {
            jgame.Call("getSnapshotContent", new object[] { uniqueName });
        }

        public void showSelectRTOpponentsBox(int minAutoMatchPlayers, int maxAutoMatchPlayers, long exclusiveBitMask,bool allowAutomatch)
        {
            jgame.Call("showSelectRTOpponentsBox", new object[] { minAutoMatchPlayers, maxAutoMatchPlayers, exclusiveBitMask , allowAutomatch });
        }
        public void createRTGameRoom(int minAutoMatchPlayers, int maxAutoMatchPlayers, long exclusiveBitMask, string[] invitees)
        {
            jgame.Call("createRTGameRoom", new object[] { minAutoMatchPlayers, maxAutoMatchPlayers, exclusiveBitMask,invitees});
        }
        public void leaveRTRoom(string roomID)
        {
            jgame.Call("leaveRTRoom", new object[] { roomID });
        }
        public void showRTWaitingRoom(string roomID, int maxPlayerToStartGame)
        {
            jgame.Call("showRTWaitingRoom", new object[] { roomID, maxPlayerToStartGame });
        }
        public void acceptRTInvite(string invitationId)
        {
            jgame.Call("acceptRTInvite", new object[] { invitationId});
        }
        public void dismissRTInvitation(string invitationId)
        {
            jgame.Call("dismissRTInvitation", new object[] { invitationId });
        }
        public void declineRTInvitation(string invitationId)
        {
            jgame.Call("declineRTInvitation", new object[] { invitationId });
        }
       
        public void loadRTInvitations()
        {
            jgame.Call("loadRTInvitations");
        }
        public void sendReliableMessage(byte[] messageData, string roomId, string recipientParticipantId)
        {
            jgame.Call("sendReliableMessage", new object[] { messageData, roomId, recipientParticipantId });
        }
        public void sendUnreliableMessage(byte[] messageData, string roomId, string recipientParticipantId)
        {
            jgame.Call("sendUnreliableMessage", new object[] { messageData, roomId, recipientParticipantId });
        }
        public void sendUnreliableMessages(byte[] messageData, string roomId, string[] recipientParticipantIds)
        {
            jgame.Call("sendUnreliableMessages", new object[] { messageData, roomId, recipientParticipantIds });
        }
        public void sendUnreliableMessageToOthers(byte[] messageData, string roomId)
        {
            jgame.Call("sendUnreliableMessageToOthers", new object[] { messageData, roomId});
        }
        public void showSelectTurnbasedOpponentsBox(int minAutoMatchPlayers, int maxAutoMatchPlayers, bool allowAutomatch)
        {
            jgame.Call("showSelectTurnbasedOpponentsBox", new object[] { minAutoMatchPlayers, maxAutoMatchPlayers, allowAutomatch });
        }
        public void createTurnbasedMatch(int minAutoMatchPlayers, int maxAutoMatchPlayers, string[] invitees)
        {
            jgame.Call("createTurnbasedMatch", new object[] { minAutoMatchPlayers, maxAutoMatchPlayers, invitees });
        }
        public void cancelTurnBasedMatch(string matchId)
        {
            jgame.Call("cancelTurnBasedMatch", new object[] { matchId });
        }
        public void dismissTurnBasedMatch(string matchId)
        {
            jgame.Call("dismissTurnBasedMatch", new object[] { matchId });
        }
        public void finishTurnbasedMatch(string matchId, byte[] matchData)
        {
            jgame.Call("finishTurnbasedMatch", new object[] { matchId,matchData });
        }
        public void leaveTurnBasedMatch(string matchId)
        {
            jgame.Call("leaveTurnBasedMatch", new object[] { matchId });
        }
        public void leaveMatchDuringTurn(string matchId, string pendingParticipantId)
        {
            jgame.Call("leaveMatchDuringTurn", new object[] { matchId, pendingParticipantId });
        }
        public void loadTurnBasedMatch(string matchId)
        {
            jgame.Call("loadTurnBasedMatch", new object[] { matchId });
        }
        public void loadTurnBasedMatches(int invitationSortOrder, int[] matchTurnStatuses)
        {
            jgame.Call("loadTurnBasedMatches", new object[] { invitationSortOrder,matchTurnStatuses });
        }
        public void rematchTurnBased(string matchId)
        {
            jgame.Call("rematchTurnBased", new object[] { matchId });
        }
        public void takeTurn(string matchId, byte[] matchData, string pendingParticipantId)
        {
            jgame.Call("takeTurn", new object[] { matchId,matchData,pendingParticipantId });
        }
        public void showTurnbasedInvitationInbox(){
        jgame.Call("showTurnbasedInvitationBox", new object[] { });
        }
        public void acceptTurnBasedInvitation(string invitationId)
        {
            jgame.Call("acceptTurnBasedInvitation", new object[] { invitationId });
        }
        public void declineTurnBasedInvitation(string invitationId)
        {
            jgame.Call("declineTurnBasedInvitation", new object[] { invitationId });
        }
        public void dismissTurnBasedInvitation(string invitationId)
        {
            jgame.Call("dismissTurnBasedInvitation", new object[] { invitationId });
        }
        public void incrementEvent(string eventId, int incrementAmount)
        {
            jgame.Call("incrementEvent", new object[] { eventId,incrementAmount });
        }
        public void loadEvent(bool forceReload)
        {
            jgame.Call("loadEvent", new object[] { forceReload });
        }
        public void loadEventByIds(bool forceReload, string[] eventIds)
        {
            jgame.Call("loadEventByIds", new object[] { forceReload , eventIds});
        }
        public void loadGameStates(bool forceReload)
        {
            jgame.Call("loadGameStates", new object[] { forceReload });
        }

        class GoogleGameListener : IGoogleGameListener
        {
            internal GoogleGame gameInstance;
            public void onGameEvent(string eventName, string paramString)
            {
                if (gameInstance.gameEventHandler != null)
                    gameInstance.gameEventHandler(eventName, paramString);
            }
            public void onGetSnapshotData(string snapshotMeta,AndroidJavaObject snapshotData)
            {
                if (gameInstance.snapshotDataHandler != null){
                    byte[] datas=snapshotData.Call<byte[]>("readFully");
                    snapshotData.Call("close");
                    gameInstance.snapshotDataHandler(snapshotMeta,datas);
                }
                   
            }
        /*
         public void onGetSnapshotData(string snapshotMeta,byte[] snapshotData)
            {
                if (gameInstance.snapshotDataHandler != null)
                    gameInstance.snapshotDataHandler(snapshotMeta,snapshotData);
            }
        */
        }
         class RealTimeMessageListener : IRealTimeMessageListener
        {
            internal GoogleGame gameInstance;
            public void onGameEvent(string eventName, string paramString)
            {
                if (gameInstance.rtgameEventHandler != null)
                    gameInstance.rtgameEventHandler(eventName, paramString);
            }
        }
#endif

    }
}
