using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] Image bar;
    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = stats.health/stats.maxHealth;
    }
}
