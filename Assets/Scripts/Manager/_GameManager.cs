using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int s_GameSeed;

    public static void GameStart(int seed = -1)
    {
        if (seed != -1) { s_GameSeed = seed; }
        else { s_GameSeed = Random.Range(0, 9999); }
    }

}
