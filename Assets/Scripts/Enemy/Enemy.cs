using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public Base Base { get; }
    public int Level { get; }

    public Enemy(Base b, int level)
    {
        Base = b;
        Level = level;
    }

    public int Health
    {
        get { return Base.Health * Level; }
    }

    public int Attack
    {
        get { return Base.Attack * Level; }
    }

    public int Defend
    {
        get { return Base.Defend * Level; }
    }

    public int ScopeAttack
    {
        get { return Base.ScopeAttack; }
    }

    public float SpeedAttack
    {
        get { return Base.SpeedAttack; }
    }

    public float Cooldown
    {
        get { return Base.Cooldown; }
    }

    public float MoveSpeed
    {
        get { return Base.MoveSpeed; }
    }
}
