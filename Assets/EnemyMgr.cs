using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    public static EnemyMgr inst;

    public AudioClip death, takeDamage, spawn, playerDeath;


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


    public void enemyDied()
    {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.clip = death;
        audioData.Play(0);
    }

   public void enemyReachedBase()
    {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.clip = takeDamage;
        audioData.Play(0);
    }

    public void enemySpawned()
    {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.clip = spawn;
        audioData.Play(0);
    }

    public void playerDied()
    {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.clip = playerDeath;
        audioData.Play(0);
    }

}
