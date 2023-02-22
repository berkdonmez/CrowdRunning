using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const string playerClone = "PlayerClone";
    private ObjectPool _objectPool;
    private NavMeshAgent _agent;
    private Animator _enemiesAnim;

    public GameObject TargetPoint;

    private void Awake()
    {
        _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        _agent = GetComponent<NavMeshAgent>();
        _enemiesAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackThePlayer();
        StopTheEnemies();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerClone))
        {
            Vector3 newEnemiesSplashPos = new Vector3(this.transform.position.x, 0.52f, this.transform.position.z);

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            _objectPool.PooledEnemiesSplashObject(newEnemiesSplashPos);
            GameManager.Instance.ScoreCounter(GameManager.Instance.ActivePlayers--);
        }
    }

    public void AttackThePlayer()
    {
        if (GameManager.Instance.isAttack == true)
        {
            _enemiesAnim.SetTrigger("EnemiesRun");
            _agent.SetDestination(TargetPoint.transform.position);
        }
    }

    public void StopTheEnemies()
    {
        if (GameManager.Instance.IsPlayerImmortal == false && GameManager.Instance.ActivePlayers <= 0)
        {
            _agent.Stop();
            GameManager.Instance.isAttack = false;
            _enemiesAnim.SetTrigger("EnemiesIdle");
        }
    }
}
