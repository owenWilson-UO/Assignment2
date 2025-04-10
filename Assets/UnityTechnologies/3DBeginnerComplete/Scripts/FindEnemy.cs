using UnityEngine;
using System.Linq;

public class FindEnemy : MonoBehaviour
{
    RedScreenEffect redScreenEffect;

    void Start()
    {
        redScreenEffect = FindFirstObjectByType<RedScreenEffect>();
    }

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 2f);

        bool on = hits.Any(hit => hit.name == "PointOfView");
        if (on)
        {
            redScreenEffect.RedScreenOn();  
        } 
        else
        {
            redScreenEffect.RedScreenOff();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 0f);
        Gizmos.DrawWireSphere(transform.position + transform.forward * 0f, 2f);
    }
}
