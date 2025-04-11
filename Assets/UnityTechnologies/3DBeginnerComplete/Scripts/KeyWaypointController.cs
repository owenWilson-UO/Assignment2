using Benjathemaker;
using UnityEngine;

public class KeyWaypointController : MonoBehaviour
{
    public Transform player;
    public Transform[] keyWaypoints;
    public SimpleGemsAnim simpleGemsAnim;

    private int nextWaypoint;
    private bool moving;

    void Start()
    {
        nextWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = player.position - simpleGemsAnim.initialPosition;
        float sqrDistance = Vector3.Dot(toPlayer, toPlayer);
        //Debug.Log($"distance sqr: {sqrDistance} next waypoint: {keyWaypoints[nextWaypoint].position} moving: {moving}");
        if (sqrDistance < 9f && nextWaypoint < 2) //3 units away
        {
            Debug.Log("within distance");
            //moving = true;
        }

        if (moving)
        {
            simpleGemsAnim.initialPosition = Vector3.Lerp(simpleGemsAnim.initialPosition, keyWaypoints[nextWaypoint].position, Time.deltaTime);
        }

        if ((simpleGemsAnim.initialPosition - keyWaypoints[nextWaypoint].position).sqrMagnitude < 0.1f)
        {
            moving = false;
            nextWaypoint++;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 toPlayer = player.position - transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, toPlayer);
    }
}
