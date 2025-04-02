using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth_simple : MonoBehaviour
{

   
    public int PlayerHitPoints;
    private int currentHitPoints;
    public Image gameOverImage;

    public static bool gameOver; //use for villainidel when player dies

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        currentHitPoints = PlayerHitPoints;
        gameOverImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("axe"))
        {
            Debug.Log("HIT");
            currentHitPoints = currentHitPoints - 1;




            if (currentHitPoints <= 0)
            {
                PlayerLoses();
            }
        }
    }

    void PlayerLoses()
    {
        Debug.Log("playerLoses");
        gameOver = true;
        gameOverImage.enabled = true;

    }

}

