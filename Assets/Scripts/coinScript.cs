using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    [SerializeField] PlayerStats stats;

    private void OnTriggerEnter(Collider other)
    {
        stats.coins = stats.coins + 1;
        Destroy(gameObject);
    }
}
