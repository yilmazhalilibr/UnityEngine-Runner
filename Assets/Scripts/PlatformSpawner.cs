using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{


    [SerializeField] private GameObject _platform;
    [SerializeField] private List<GameObject> _platformList;
    [SerializeField] private List<GameObject> _activePlatformList;
    [SerializeField] private float _obstacleSpace;
    public Action<GameObject> SpawnState;
    // private void Awake()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        _platformList.Add(_platform);
    //    }
    //}

    private void Update()
    {
        PlatformSpawn();
    }

    private void PlatformSpawn()
    {
        //if (_platformList.Count < item)
        //{
        //    item = 0;
        //}
        //if (_activePlatformList.Count < 3)
        //{
        // var platformInstaniate = Instantiate(list[item]);
        //  _activePlatformList.Add(platformInstaniate);
        //   platformInstaniate.transform.position = new Vector3(0f, 0f, 80f * _activePlatformList.Count);
        //}
        foreach (var item in _activePlatformList)
        {
            if (item.transform.position.z <= -79.98f)
            {
                item.TryGetComponent(out PlatformMovement platformMovement);
                var frontPlatform = platformMovement.GetFrontPlatform();
                item.transform.position = new Vector3(0f, 0f, frontPlatform.transform.position.z + _obstacleSpace);
                //item.transform.position = new Vector3(0f, 0f, 160f);
                SpawnState?.Invoke(item);
            }

        }
        //if (item > 3)
        //{
        //    item++;
        //}

    }





}
