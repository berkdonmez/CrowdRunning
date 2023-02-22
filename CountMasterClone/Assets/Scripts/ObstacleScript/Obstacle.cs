using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const string playerClone = "PlayerClone";
    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(playerClone))
        {
            Vector3 newPlayerSplashPos = new Vector3(other.transform.position.x, 0.52f, other.transform.position.z);

            other.gameObject.SetActive(false);
            GameManager.Instance.ScoreCounter(GameManager.Instance.ActivePlayers--);
            _objectPool.PooledPlayerSplashObject(newPlayerSplashPos);
        }

    }
}
