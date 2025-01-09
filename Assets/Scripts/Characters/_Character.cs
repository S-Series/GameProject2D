using UnityEngine;

public class Character
{
    public string Name;
    public int[] cooldown;
    public int speed;
    public float atk, def;
    public float hp, hpr;
    public float mp, mpr;

    public virtual void BaseAttack() { }
    public virtual void SkillAttack() { }
}
