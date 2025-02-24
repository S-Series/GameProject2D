using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Transform s_Player;
    [SerializeField] Transform p;
    public static int s_GameSeed;

    private void Awake() { s_Player = p; }
    public static void GameStart(int seed = -1)
    {
        if (seed != -1) { s_GameSeed = seed; }
        else { s_GameSeed = Random.Range(0, 9999); }
    }

}
