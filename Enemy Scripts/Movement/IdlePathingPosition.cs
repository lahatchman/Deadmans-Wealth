using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePathingPosition : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        if (this.name.Contains("IdlePathingPosition"))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
        else if (this.name.Contains("EnemySpawnPoint"))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
