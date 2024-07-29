using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CauldronButton : MonoBehaviour
{
    private Button _button;
    private Cauldron _cauldron;

    public void Start()
    {
        _button = GetComponent<Button>();
        _cauldron = ServiceLocator.Get<Cauldron>();
    }
    
    private void Update()
    {
        _button.interactable = _cauldron.CanCook;
    }
}
