using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform spawnMonster;

    private void Awake()
    {
        LoadGO();
    }

    private void Reset()
    {
        LoadGO();
    }

    private void LoadGO()
    {
        _gameObject = Resources.Load<GameObject>("Prefabs/Level1/WhiteKnight");
        spawnMonster = GameObject.Find("SpawnMonster").GetComponent<Transform>();
    }

    private void Start()
    {
        float ran;
        for (int i = 0; i < 2; i++)
        {
            if (Random.Range(1, 10) > 5) ran = -10.8f;
            else ran = 10.8f;
            Vector3 pos = new Vector3(ran, -2.58f, 0);
            Instantiate(_gameObject, pos, Quaternion.identity, spawnMonster);
        }
    }
}
