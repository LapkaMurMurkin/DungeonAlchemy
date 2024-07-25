using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneLoader : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private void Awake()
    {
        ServiceLocator = new ServiceLocator();
    }
}

