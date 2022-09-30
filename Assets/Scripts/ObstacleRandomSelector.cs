using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;

public class ObstacleRandomSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;

    private PlatformSpawner _platformSpawner;
    [Inject]
    private void Constructor(PlatformSpawner platformSpawner)
    {
        _platformSpawner = platformSpawner;
        _platformSpawner.OnSpawnState += GetAllChildObstacle;
        GetAllChild();
    }

    private void OnDestroy()
    {
        _platformSpawner.OnSpawnState -= GetAllChildObstacle;
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
        var platformChilds = platform.transform.GetAllChilds().FindAll((child) => child.CompareTag("Obstacles"));

        foreach (var child in platformChilds)
        {
            var obstacles = new List<GameObject>();

            var obstacleChilds = child.GetAllChilds();
            foreach (var obstacleChild in obstacleChilds)
            {
                obstacleChild.gameObject.SetActive(false);
                obstacles.Add(obstacleChild.gameObject);
            }

            var randomIndex = Random.Range(0, obstacles.Count);
            obstacles[randomIndex].gameObject.SetActive(true);

        }
    }
}
