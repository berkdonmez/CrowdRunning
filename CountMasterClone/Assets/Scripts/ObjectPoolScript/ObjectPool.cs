using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _bornPoint;

    public GameObject[] PooledObject;
    public GameObject[] PooledPlayerSplashObjects;
    public GameObject[] PooledEnemySplashObjects;

    public bool PooledObjects(bool t)
    {
        foreach (var item in PooledObject)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = _bornPoint.transform.position;
                item.SetActive(t);
                break;
            }
        }
        return t;
    }

    public void UnPooledObjects()
    {
        foreach (var item in PooledObject)
        {
            if (item.activeInHierarchy)
            {
                item.transform.position = _bornPoint.transform.position;
                item.SetActive(false);
                break;
            }
        }
    }

    public Vector3 PooledPlayerSplashObject(Vector3 t)
    {
        foreach (var item in PooledPlayerSplashObjects)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = t;
                item.SetActive(true);
                break;
            }
        }
        return t;
    }

    public Vector3 PooledEnemiesSplashObject(Vector3 t)
    {
        foreach (var item in PooledEnemySplashObjects)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = t;
                item.SetActive(true);
                break;
            }
        }
        return t;
    }

}
