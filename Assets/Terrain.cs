using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    public static Terrain inst;

    public List<PlaceableTile> tiles;

    private void Awake()
    {
        inst = this;
    }


    void Start()
    {
        PlaceableTile[] allTiles = GetComponentsInChildren<PlaceableTile>();
        foreach (PlaceableTile child in allTiles)
        {
            tiles.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
