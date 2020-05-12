using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject BluePlayer1, RedPlayer1;

    public static int diceSideThrownSum = 0;
    public static int diceSideThrown1 = 0;
    public static int diceSideThrown2 = 0;
    public static int BluePlayerStartWayPoint = 0;
    public static int RedPlayerStartWayPoint = 0;
    public static bool gameOver = false;

    // Use this for initialization
    void Start () {
        
        BluePlayer1 = GameObject.Find("BluePlayer1");
        RedPlayer1 = GameObject.Find("RedPlayer1");

        BluePlayer1.GetComponent<FollowThePath>().moveAllowed = false;
        RedPlayer1.GetComponent<FollowThePath>().moveAllowed = false;
    }

    void Update()
    {
        diceSideThrownSum=diceSideThrown1+diceSideThrown2;


        if (BluePlayer1.GetComponent<FollowThePath>().waypointIndex > BluePlayerStartWayPoint + diceSideThrownSum){
            BluePlayer1.GetComponent<FollowThePath>().moveAllowed = false;
            BluePlayerStartWayPoint = BluePlayer1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (RedPlayer1.GetComponent<FollowThePath>().waypointIndex > RedPlayerStartWayPoint + diceSideThrownSum){
            RedPlayer1.GetComponent<FollowThePath>().moveAllowed = false;
            RedPlayerStartWayPoint = RedPlayer1.GetComponent<FollowThePath>().waypointIndex - 1;
        }



        if (BluePlayer1.GetComponent<FollowThePath>().waypointIndex == BluePlayer1.GetComponent<FollowThePath>().waypoints.Length){
            //gameOver = true;
            //print("Azul gana");
        }

        if (RedPlayer1.GetComponent<FollowThePath>().waypointIndex == RedPlayer1.GetComponent<FollowThePath>().waypoints.Length){
            //gameOver = true;
            //print("Rojo gana");
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                if (BluePlayer1.GetComponent<FollowThePath>().waypointIndex + diceSideThrownSum <= BluePlayer1.GetComponent<FollowThePath>().waypoints.Length ){
                    BluePlayer1.GetComponent<FollowThePath>().moveAllowed = true;
                }
                break;

            case 2:
                if (RedPlayer1.GetComponent<FollowThePath>().waypointIndex + diceSideThrownSum <= RedPlayer1.GetComponent<FollowThePath>().waypoints.Length ){
                    RedPlayer1.GetComponent<FollowThePath>().moveAllowed = true;
                }
                break;
        }
    }
}
