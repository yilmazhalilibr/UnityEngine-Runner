using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private PlatformSpawner _platformSpawner;

    private void Awake()
    {
        _platformSpawner.SpawnState += GetAllChildObstacle;
        GetAllChild();
    }
    private void OnDestroy()
    {
        _platformSpawner.SpawnState -= GetAllChildObstacle;
    }
    public void GetAllChild()
    {
        foreach (var item in transform.GetAllChilds())
        {
            item.gameObject.SetActive(false);
            _obstacles.Add(item.gameObject);
        }
        var randomCount = UnityEngine.Random.Range(0, _obstacles.Count);
        _obstacles[randomCount].gameObject.SetActive(true);
    }
    private void GetAllChildObstacle(GameObject platform)
    {
        var childs = new List<GameObject>();

        foreach (Transform child in platform.transform.GetAllChilds())
        {
            childs.Add(child.gameObject);
        }

        foreach (var model in childs)
        {
            var obstacles = new List<GameObject>();

            if (model.CompareTag("Obstacles"))
            {
                foreach (var i in model.gameObject.transform.GetAllChilds())
                {
                    i.gameObject.SetActive(false);
                    obstacles.Add(i.gameObject);
                }
                var randomCount1 = Random.Range(0, obstacles.Count);
                obstacles[randomCount1].gameObject.SetActive(true);
            }

        }
    }
}
