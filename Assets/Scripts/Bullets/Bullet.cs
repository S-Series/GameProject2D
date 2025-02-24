using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int AttackStat = 5;
    public int MoveSpeed = 5;
    public int LifeTick = 3 * 15;
    public Vector2 Direct;
    public virtual void Move()
    {
        
    }
}
