using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    protected Transform _playerCameraTransform;

    public virtual void Initialize()
    {
        _playerCameraTransform = ServiceLocator.Get<PlayerCamera>().transform;

        this.LateUpdateAsObservable().Subscribe(_ => RotateToCamera()).AddTo(this);
    }

    private void RotateToCamera()
    {
        transform.LookAt(transform.position + _playerCameraTransform.forward);
    }
}
