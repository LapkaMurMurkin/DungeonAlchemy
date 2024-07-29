using System.Collections.Generic;
using UnityEngine;

public class CauldronElementsRatioView : MonoBehaviour
{
    public Cauldron Cauldron;
    public MeasuringTubeView MeasuringTubePrefab;
    public Transform Container;

    private List<MeasuringTubeView> _tubes = new List<MeasuringTubeView>();

    public void Start()
    {
        foreach (Transform child in Container)
            Destroy(child.gameObject);

        foreach (var element in Cauldron.Elements.Values)
        {
            var tubeView = Instantiate(MeasuringTubePrefab, Container);
            tubeView.Init(element);
            _tubes.Add(tubeView);
        }

        Cauldron.RatioChanged += RefreshUI;
        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (var tube in _tubes)
            tube.RefreshUI();
    }
}
