using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMgr : MonoBehaviour
{

    public bool isGamePaused = false;

    public static GameStateMgr inst;

    private void Awake()
    {
        inst = this;
    }

     // Start is called before the first frame update
    void Start()
    {
        //SceneManager.UnloadSceneAsync("SplashTitle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
