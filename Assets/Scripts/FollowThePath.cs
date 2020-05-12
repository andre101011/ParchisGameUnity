using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    public Transform homeWayPoint;

    [SerializeField]
    private float moveSpeed = 2f;

    [HideInInspector]
    public int waypointIndex = 0;
    public bool moveAllowed = false;

	private void Start () {
        waypointIndex = 0;
        transform.position = homeWayPoint.transform.position;
        //transform.position = waypoints[waypointIndex].transform.position;
	}
	

	private void Update () {
        if (moveAllowed){
            Move();
            //print("Muevaseeee");
        }
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,waypoints[waypointIndex].transform.position,moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                //print("avanza 1puesto");
                waypointIndex += 1;
                System.Threading.Thread.Sleep(150);
            }
        }
    }
}
