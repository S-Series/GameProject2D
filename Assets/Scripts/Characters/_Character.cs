using System;

public class Character
{
    public string Name;
    public float[] cooldown;
    public float speed, atkSpeed;
    public float atk, def;
    public float baseHp, shieldHp, lucidHp;
    public float mp, mpr;
    public float luck;

    public virtual void BaseAttack() { throw new Exception("Override Error"); }
    public virtual void SkillAttack() { throw new Exception("Override Error"); }
    public virtual void ForceEscape() { throw new Exception("Override Error"); }
}

public class Froggy : Character
{
    public override void BaseAttack()
    {
        base.BaseAttack();
    }
    public override void SkillAttack()
    {
        base.BaseAttack();
    }
    public override void ForceEscape()
    {
        base.BaseAttack();
    }
    public Froggy()
    {
        Name = "Froggy";
        cooldown = new float[2] { 0, 0 };
        speed = 5.0f; atkSpeed = 1.0f;
        baseHp = 10; shieldHp = 0; lucidHp = 0;
        mp = 100; mpr = 10;
        luck = 0;
    }
}
