using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AlchemyUtils
{
    public static string GetRatioString(CookingElement[] elements)
    {
        return String.Join(" | ", elements.Select(element => $"{element.Element.Name}: {element.Ratio}").ToArray());
    }
}
