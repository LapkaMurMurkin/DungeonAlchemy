using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class MVVM_ViewModel
{
    protected MVVM_Model _model;
    protected CompositeDisposable _disposables;

    protected MVVM_ViewModel(MVVM_Model model)
    {
        _model = model;
        _disposables = new CompositeDisposable();
    }

    public abstract void SubscribeToModel();

    public virtual void UnsubscribeFromModel()
    {
        _disposables.Clear();
    }
}
