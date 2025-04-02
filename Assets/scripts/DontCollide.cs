using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCollide : MonoBehaviour
{

    public Transform arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(arrowPrefab.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
