using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    public Action OnAnimationStart;
    private void AnimationStartEvent() => OnAnimationStart?.Invoke();

    public Action OnAnimationEnd;
    private void AnimationEndEvent() => OnAnimationEnd?.Invoke();

    public Action OnDamage;
    private void DamageEvent() => OnDamage?.Invoke();

    public Action OnShieldUp;
    private void ShieldUpEvent() => OnShieldUp?.Invoke();

    public Action OnShieldDown;
    private void ShieldDownEvent() => OnShieldDown?.Invoke();

    public Action OnDefence;
    private void DefenceEvent() => OnDefence?.Invoke();
}
