using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private ObjectPool _objectPool;
    private const string playerTag = "Player";

    public enum GateType { Plus, Extraction, Multiplication }
    public GateType gateType;
    public int GateScore;

    void Start()
    {
        _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            switch (gateType)
            {
                case GateType.Plus:
                    AdditionScore(GateScore);
                    break;
                case GateType.Extraction:
                    ExtractionScore(GateScore);
                    break;
                case GateType.Multiplication:
                    MultiplicationScore(GateScore);
                    break;
            }
        }
    }

    public int AdditionScore(int s)
    {
        GameManager.Instance.ActivePlayers += s;
        GameManager.Instance.ScoreCounter(GameManager.Instance.ActivePlayers);
        GameManager.Instance.IsPlayerImmortal = false;

        for (int i = 0; i < s; i++)
        {
            _objectPool.PooledObjects(true);

        }
        return s;
    }

    public int MultiplicationScore(int m)
    {
        GameManager.Instance.ActivePlayers *= m;
        GameManager.Instance.ScoreCounter(GameManager.Instance.ActivePlayers);

        for (int i = 0; i < GameManager.Instance.ActivePlayers / 2; i++)
        {
            _objectPool.PooledObjects(true);
        }
        return m;
    }

    public int ExtractionScore(int e)
    {
        GameManager.Instance.ActivePlayers -= e;
        GameManager.Instance.ScoreCounter(GameManager.Instance.ActivePlayers);
        GameManager.Instance.IsPlayerImmortal = false;

        for (int i = 0; i < e; i++)
        {
            _objectPool.UnPooledObjects();
        }

        return e;
    }
}
