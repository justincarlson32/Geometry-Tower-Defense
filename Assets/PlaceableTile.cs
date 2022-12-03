using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTile : MonoBehaviour
{

    public bool isSpaceAvailable;
    public Tower placedTower;

    // Start is called before the first frame update
    void Start()
    {
        isSpaceAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
