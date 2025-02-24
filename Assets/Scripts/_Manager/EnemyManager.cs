using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<BaseEnemy> Enemies = new List<BaseEnemy>();

    public static void ProcessEnemies()
    {
        foreach (var enemy in Enemies) enemy.TickAction();
    }
}
