using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Road : MonoBehaviour
{
    public List<Tile> Tiles;

    public void Initialize()
    {
        for (int i = 1; i < Tiles.Count - 1; i++)
        {
            Tiles[i - 1].NextTile = Tiles[i];
            Tiles[i].PreviousTile = Tiles[i - 1];
            Tiles[i].NextTile = Tiles[i + 1];
            Tiles[i + 1].PreviousTile = Tiles[i];
        }
    }
}
