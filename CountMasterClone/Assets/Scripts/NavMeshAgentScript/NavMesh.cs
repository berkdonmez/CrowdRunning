using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private GameObject TargetPoint;
    [SerializeField] private GameObject FinalBossPosition;
    private NavMeshAgent navMeshAgent;
    private Animator _enemiesAnim;
    private bool isTouchFinalBoss = false;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _enemiesAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isTouchFinalBoss == false)
        {
            FollowPlayerPosition();
        }
        else
        {
            FollowFinalBossPosition();
        }

        if (GameManager.Instance.FinalBossScore <= 0)
        {
            StopPlayerClones();
            VictoryAnimForClones();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLine")
        {
            isTouchFinalBoss = true;
        }
    }

    private void VictoryAnimForClones()
    {
        _enemiesAnim.SetTrigger("Victory");
    }

    public void FollowPlayerPosition()
    {
        navMeshAgent.SetDestination(TargetPoint.transform.position);
    }

    public void FollowFinalBossPosition()
    {
        navMeshAgent.SetDestination(FinalBossPosition.transform.position);
    }

    public void StopPlayerClones()
    {
        navMeshAgent.Stop();
    }


}
