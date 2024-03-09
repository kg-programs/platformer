using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Player Stats")]

public class PlayerStats : ScriptableObject
{
    public float health = 3;
    public float maxHealth = 3;
    public float coins = 0;
    public float maxCoins = 10;
}
