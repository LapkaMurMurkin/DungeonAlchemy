using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public abstract class MVVM_View : MonoBehaviour
{
    protected MVVM_ViewModel _viewModel;

    protected CompositeDisposable _disposables;

    protected virtual void Initialize(MVVM_ViewModel viewModel)
    {
        _viewModel = viewModel;
        _disposables = new CompositeDisposable();
    }

    public abstract void SubscribeToViewModel();

    public virtual void UnsubscribeFromViewModel()
    {
        _disposables.Clear();
    }
}
