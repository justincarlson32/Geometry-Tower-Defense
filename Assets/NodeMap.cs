using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMap : MonoBehaviour
{

    public static NodeMap inst;

    public List<GameObject> nodeMap;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
