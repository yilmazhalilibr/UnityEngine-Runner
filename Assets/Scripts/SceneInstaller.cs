using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlatformSpawner _platformSpawner;
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager);
        Container.Bind<PlatformSpawner>().FromInstance(_platformSpawner);

    }
}