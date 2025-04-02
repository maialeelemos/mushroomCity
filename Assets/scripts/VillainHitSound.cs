using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainHitSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip hit;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player")) 
        {
            source.PlayOneShot(hit);
        }
    }
}
