using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera Camera;

    public void Initialize()
    {
        Camera = GetComponent<Camera>();
    }
}
