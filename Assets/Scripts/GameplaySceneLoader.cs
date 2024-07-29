using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneLoader : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    public AlchemyInitializer AlchemyInitializer;
    
    private ActionMap _actionMap;

    private Player _player;

    private Enemy _enemy;

    private void Awake()
    {
        ServiceLocator = new ServiceLocator();
        AlchemyInitializer.Init();
        
        // _actionMap = new ActionMap();
        // _actionMap.Enable();
        // ServiceLocator.Register<ActionMap>(_actionMap);
        //
        // _player = FindObjectOfType<Player>();
        // _player.Initialize();
        //
        // _enemy = FindObjectOfType<Enemy>();
        // _enemy.Initialize();
    }
}

