namespace com.google.game
{

    public class GameConst
    {

        public static readonly int COLLECTION_PUBLIC = 0;
        public static readonly int COLLECTION_SOCIAL = 1;
        public static readonly int TIME_SPAN_DAILY = 0;
        public static readonly int TIME_SPAN_WEEKLY = 1;
        public static readonly int TIME_SPAN_ALL_TIME = 2;

        public static readonly int PageDirectionNONE = -1;
        public static readonly int PageDirectionNEXT = 0;
        public static readonly int PageDirectionPREV = 1;

        public static readonly int RESULT_LEFT_ROOM = 10005;
        public static readonly int RESULT_OK = -1;
        public static readonly int RESULT_CANCELED = 0;


        public static readonly int MULTIPLAYER_DISABLED = 6003;
        public static readonly int REAL_TIME_CONNECTION_FAILED = 7000;
        public static readonly int REAL_TIME_MESSAGE_SEND_FAILED = 7001;
        public static readonly int REAL_TIME_ROOM_NOT_JOINED = 7004;
        
        
         public static readonly int MATCH_STATUS_AUTO_MATCHING = 0;
	    public static readonly int MATCH_STATUS_ACTIVE = 1;
	    public static readonly int MATCH_STATUS_COMPLETE = 2;
	    public static readonly int MATCH_STATUS_EXPIRED = 3;
	    public static readonly int MATCH_STATUS_CANCELED = 4;
	    public static readonly int MATCH_TURN_STATUS_INVITED = 0;
	    public static readonly int MATCH_TURN_STATUS_MY_TURN = 1;
	    public static readonly int MATCH_TURN_STATUS_THEIR_TURN = 2;
	    public static readonly int MATCH_TURN_STATUS_COMPLETE = 3;
	    
	    public static readonly int SORT_ORDER_MOST_RECENT_FIRST=0;
	    public static readonly int SORT_ORDER_SOCIAL_AGGREGATION=1;

    }
}
