using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    //public AudioClip GoT;
    private AudioSource source;
    public bool battleStarts;
    private Collider collider;
    public bool skelAttack;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        battleStarts = false;
        collider = GetComponent<Collider>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        battleStarts = true;
        source.Play();
        Destroy(collider);


        


    }
}
