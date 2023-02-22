using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
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
            GameManager.Instance.DecreaseTheFinalBossScore();
            _objectPool.PooledPlayerSplashObject(newPlayerSplashPos);
        }

        if (GameManager.Instance.FinalBossScore <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.WinCanvas.SetActive(true);
        }

    }

}
