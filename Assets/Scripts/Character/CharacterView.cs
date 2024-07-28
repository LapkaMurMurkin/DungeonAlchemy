using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

public abstract class CharacterView : MonoBehaviour
{
    protected Character _character;

    public abstract void Initialize(Character character);
}
