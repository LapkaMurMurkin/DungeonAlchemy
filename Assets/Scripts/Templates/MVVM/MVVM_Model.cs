using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class MVVM_Model
{
    protected CompositeDisposable _disposables;

    protected MVVM_Model()
    {
        _disposables = new CompositeDisposable();
    }

    public virtual void SubscribeToChanges() { }

    public virtual void UnsubscribeFromChanges()
    {
        _disposables.Clear();
    }
}