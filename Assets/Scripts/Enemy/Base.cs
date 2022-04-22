using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "base", menuName = "Monster/Create new monster")]
public class Base : ScriptableObject
{
    //infor
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    //base
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _defend;
    [SerializeField] private int _scopeAttack;
    [SerializeField] private float _speedAttack;
    [SerializeField] private float _moveSpeed;
    //
    [SerializeField] private float _cooldown;

    public string Name
    {
        get { return _name; }
    }

    public Sprite Sprite
    {
        get { return _sprite; }
    }

    public int Health
    {
        get { return _health; }
    }

    public int Attack
    {
        get { return _attack; }
    }

    public int Defend
    {
        get { return _defend; }
    }

    public int ScopeAttack
    {
        get { return _scopeAttack; }
    }

    public float SpeedAttack
    {
        get { return _speedAttack; }
    }

    public float Cooldown
    {
        get { return _cooldown; }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
}
