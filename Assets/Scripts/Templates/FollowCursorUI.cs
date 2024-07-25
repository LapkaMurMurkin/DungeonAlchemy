using System.Collections;
using System.Collections.Generic;
using R3;

using R3.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FollowCursor2DUI : MonoBehaviour
{
    public virtual void Initialize()
    {
        this.LateUpdateAsObservable().Subscribe(_ => FollowCursor()).AddTo(this);
    }

    private void FollowCursor()
    {
        this.transform.position = Input.mousePosition;
    }
}
