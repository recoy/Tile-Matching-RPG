using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpecs : MonoBehaviour
{

    public DestroyOnClick doc;
    public RandomMapGenerator2D tileGenerator;
    public int number;
    public int colorInt;
    //private int tileRows;
    public List<GameObject> neighboursList = new List<GameObject>();
    public bool hasChecked = false;
    public bool isAdded = false;

    private void Start()
    {
        doc = GameObject.FindGameObjectWithTag("TileGenerator").GetComponent<DestroyOnClick>();
        tileGenerator = doc.tileGenerator;
        //tileRows = tileGenerator.rows;
        //Debug.Log(tileGenerator.rows * tileGenerator.colums);
        //Debug.Log(tileRows);
    }

    //public void CheckAround()
    //{
    //    //Left Side
    //    if (number == 0 || number % tileRows == 0)
    //    {
    //        AddTilesToDestroyList(true, true, false, true);
    //    }

    //    //Right Side
    //    else if (number == tileRows - 1 || number % (tileRows - 1) == 0)
    //    {
    //        AddTilesToDestroyList(true, true, true, false);
    //    }

    //    else
    //    {
    //        AddTilesToDestroyList(true, true, true, true);
    //    }
    //}

    //public void AddTilesToDestroyList(bool up, bool down, bool left, bool right)
    //{
    //    doc.AddToDestroyList(tileGenerator.tiles[number]);

    //    if (up)
    //    {
    //        Debug.Log("Up: " + (number + tileRows));
    //        if (number + tileRows < tileGenerator.rows * tileGenerator.colums && colorInt == tileGenerator.tiles[number + tileRows].GetComponent<TileSpecs>().colorInt)
    //        {
    //            doc.AddToDestroyList(tileGenerator.tiles[number + tileRows]);
    //            tileGenerator.tiles[number + tileRows].GetComponent<TileSpecs>().CheckAround();
    //        }
    //    }

    //    if (down)
    //    {
    //        Debug.Log("Down: " + (number - tileRows));
    //        if (number - tileRows >=0  && colorInt == tileGenerator.tiles[number - tileRows].GetComponent<TileSpecs>().colorInt)
    //        {
    //            doc.AddToDestroyList(tileGenerator.tiles[number - tileRows]);
    //            tileGenerator.tiles[number - tileRows].GetComponent<TileSpecs>().CheckAround();
    //        }
    //    }

    //    if (left)
    //    {
    //        Debug.Log("Left: " + (number - 1));
    //        if (colorInt == tileGenerator.tiles[number - 1].GetComponent<TileSpecs>().colorInt)
    //        {
    //            doc.AddToDestroyList(tileGenerator.tiles[number - 1]);
    //            tileGenerator.tiles[number - 1].GetComponent<TileSpecs>().CheckAround();
    //        }
    //    }

    //    if (right)
    //    {
    //        Debug.Log("Right: " + (number + 1));
    //        if (colorInt == tileGenerator.tiles[number + 1].GetComponent<TileSpecs>().colorInt)
    //        {
    //            doc.AddToDestroyList(tileGenerator.tiles[number + 1]);
    //            tileGenerator.tiles[number + 1].GetComponent<TileSpecs>().CheckAround();
    //        }
    //    }

        





















        //    if (down)
        //    {
        //        if (number - tileRows >= 0)
        //        {
        //            if ((doc.destroy.Count == 0) && colorInt == tileGenerator.tiles[number - tileRows].GetComponent<TileSpecs>().colorInt)
        //            {
        //                Debug.Log("ADD DOWN");
        //                //doc.destroy.Add(tileGenerator.tiles[number + tileRows]);
        //            }
        //        }
        //    }
        //    if (left)
        //    {
        //        if ((!doc.destroy.Contains(tileGenerator.tiles[number - 1]) || doc.destroy.Count == 0) && colorInt == tileGenerator.tiles[number - 1].GetComponent<TileSpecs>().colorInt)
        //        {
        //            Debug.Log("ADD LEFT");
        //            //doc.destroy.Add(tileGenerator.tiles[number + tileRows]);
        //        }
        //    }
        //    if (right)
        //    {
        //        if ((!doc.destroy.Contains(tileGenerator.tiles[number + 1]) || doc.destroy.Count == 0) && colorInt == tileGenerator.tiles[number + 1].GetComponent<TileSpecs>().colorInt)
        //        {
        //            Debug.Log("ADD RIGHT");
        //            //doc.destroy.Add(tileGenerator.tiles[number + tileRows]);
        //        }
        //    }
        //}


    }


