using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage = 9;
    public Action<int> OnDamageDeal;

    private void DamageDealEventHandler() => OnDamageDeal?.Invoke(Damage);
}
