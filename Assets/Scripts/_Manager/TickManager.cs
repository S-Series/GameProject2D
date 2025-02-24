using UnityEngine;

public class TickManager : MonoBehaviour
{
    public static bool s_isActive = false;
    private float globalTick = 0f;
    private const float actionTick = 1f / 30f;

    private void Update()
    {
        if (!s_isActive) return;

        globalTick += Time.deltaTime;
        if (globalTick >= actionTick)
        {
            globalTick -= actionTick;
            EnemyManager.ProcessEnemies();
            BulletManager.ProcessBullets();
        }
    }
}
