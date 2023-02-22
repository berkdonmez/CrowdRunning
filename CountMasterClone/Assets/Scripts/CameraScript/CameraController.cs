using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 7, -8);
    private Vector3 _finalFightOffset = new Vector3(0, 9, -8.3f);
    private float _smoothSpeed = 2.3f;

    public GameObject Player;


    void Awake()
    {
        //_smoothSpeed = Time.deltaTime;
    }

    void LateUpdate()
    {
        FollowThePlayer();
    }

    public void FollowThePlayer()
    {
        if (GameManager.Instance.CameraNewPosition == false)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset, _smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + _finalFightOffset, _smoothSpeed * Time.deltaTime);
        }
    }
}
