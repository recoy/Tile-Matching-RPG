using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapGenerator2D : MonoBehaviour {

    public GameObject[] tileTypes;
    public List<GameObject> tiles;
    public List<Vector3> tilePositions;
    public string tilesTag;
    public Transform tilesParent;
    //public GameObject tilesParentObj;

    private int[] types;
    public int colums, rows, seed;
    private int prevColums, prevRows, prevSeed;
    private float r, c;

    void Start()
    {
        //tilesParentObj = transform.Find("Tiles").gameObject;
        SetTilesPositions();
        GenerateTilesRandomly();
        prevColums = colums;
        prevRows = rows;
        prevSeed = seed;
        Random.InitState(seed);
    }



    private void Update()
    {

        if (prevColums != colums || prevRows != rows || prevSeed != seed)
        {
            DestroyTiles();
            SetTilesPositions();
            GenerateTilesRandomly();
            prevColums = colums;
            prevRows = rows;
            prevSeed = seed;
        }
    }

    public void GenerateTiles()
    {
        DestroyTiles();
        SetTilesPositions();
        GenerateTilesRandomly();
    }

    private void SetTilesPositions()
    {
        int s = 0;
        for (r = 0f; r < rows; ++r)
        {
            for (c = 0f; c < colums; ++c)
            {
                tilePositions.Insert(s, new Vector3(c, r, 0f));
                ++s;
            }
        }
    }

    public void GenerateTilesRandomly()
    {
        RandomizeType();
        int s = 0;

        for (int j = 0; j < colums; ++j)
        {
            for (int k = 0; k < rows; ++k)
            {
                GameObject tile = Instantiate(tileTypes[types[s]], tilePositions[s], Quaternion.identity);
                tiles.Add(tile);
                tile.GetComponent<TileSpecs>().number = s;
                tile.transform.parent = tilesParent.transform;
                ++s;
            }
        }
    }

    private void DestroyTiles()
    {
        //GameObject[] destroyTiles = GameObject.FindGameObjectsWithTag(tilesTag);

        for (int j = 0; j < tiles.Count; ++j)
        {
            //tiles.Remove(destroyTiles[j]);
            //Destroy(destroyTiles[j]);
            Destroy(tiles[j]);
        }
        tiles.Clear();
    }

    private void RandomizeType()
    {
        types = new int[colums * rows];
        int i;

        System.Random rnd = new System.Random();
        for (i = 0; i < colums * rows; ++i)
        {
            types[i] = rnd.Next(tileTypes.Length);
        }
    }
}
