using Unity.VisualScripting;
using UnityEngine;

public class MoveWallDown : MonoBehaviour
{
    public bool move = false;
    void Update()
    {
        if (move)
        {
            Debug.Log("Should move");
            Vector3 target = new Vector3(transform.position.x, -2.3f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
        }
    }
}
