using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    public bool _isPlayerMoving = true;

    private Animator _playerAnim;

    [Header("Player Movement Settings")]
    public float _playerForwardSpeed; //  Two.five is best value to forward movement. 
    public float _playerHorizontalSpeed; // Four is best value to horizontal movement.

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveForwardThePlayer(_playerForwardSpeed);
    }

    private void Update()
    {
        MoveHorizontalThePlayer(_playerHorizontalSpeed);
        VictoryAnim();
        IdleAnim();
        KillThePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AttackArea")
        {
            GameManager.Instance.isAttack = true;
        }

        if (other.gameObject.name == "FinishLine")
        {
            _isPlayerMoving = false;
            GameManager.Instance.CameraNewPosition = true;
        }
    }

    public float MoveForwardThePlayer(float s)
    {
        if (GameManager.Instance.IsGameStart == true && _isPlayerMoving == true)
        {
            _playerRb.velocity = Vector3.forward * s;
            _playerAnim.SetTrigger("run");
        }

        return s;
    }

    public float MoveHorizontalThePlayer(float s)
    {
        if (GameManager.Instance.IsGameStart == true && _isPlayerMoving == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - s, transform.position.y, transform.position.z), Time.deltaTime);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + s, transform.position.y, transform.position.z), Time.deltaTime);
                }
            }
        }

        return s;
    }

    private void VictoryAnim()
    {
        if (GameManager.Instance.FinalBossScore <= 0)
        {
            _playerAnim.SetTrigger("Victory");
        }
    }

    private void IdleAnim()
    {
        if(_isPlayerMoving == false)
        {
            _playerAnim.SetTrigger("Idle");
        }
    }

    private void KillThePlayer()
    {
        if (GameManager.Instance.IsPlayerImmortal == false && GameManager.Instance.ActivePlayers <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.RestartCanvas.SetActive(true);
        }
    }

}
