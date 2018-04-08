using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    
    public bool gameStarted = false;
    public DestroyOnClick doc;
    public bool hittedTile = false;
    public TileSpecs tile;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("meni");

        tile = other.GetComponent<TileSpecs>();
        if (tile != null)
        {
            if (gameStarted && tile.colorInt == doc.color)
            {
                hittedTile = true;
            }
            else
            {
                hittedTile = false;
            }
        }
    }
}
