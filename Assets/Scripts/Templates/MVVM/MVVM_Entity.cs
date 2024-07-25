using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public abstract class MVVM_Entity : MonoBehaviour
{
    protected MVVM_Model _model;
    protected MVVM_ViewModel _viewModel;
    protected MVVM_View _view;

    public virtual void Initialize()
    {
        this.OnEnableAsObservable().Subscribe(_ => Enable()).AddTo(this);
        this.OnDisableAsObservable().Subscribe(_ => Disable()).AddTo(this);
    }

    protected virtual void Enable()
    {
        _model.SubscribeToChanges();
        _viewModel.SubscribeToModel();
        _view.SubscribeToViewModel();
    }

    protected virtual void Disable()
    {
        _view.UnsubscribeFromViewModel();
        _viewModel.UnsubscribeFromModel();
        _model.UnsubscribeFromChanges();
    }
}
