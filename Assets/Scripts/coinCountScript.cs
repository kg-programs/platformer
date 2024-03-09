using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCountScript : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] Image coin;

    // Update is called once per frame
    void Update()
    {
        coin.fillAmount = stats.coins / stats.maxCoins;
    }
}
