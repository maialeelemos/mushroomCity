using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int PlayerHitPoints;
    public int currentHitPoints;
    public HealthBar healthBar;
    public static bool gameOver;
    //public Image[] images;
    public Image gameOverImage;
    public Button restartButton;
    public TMP_Text restartText;


    


    // Start is called before the first frame update
    void Start()
    {
  
        gameOver = false;
        currentHitPoints = PlayerHitPoints;
        healthBar.SetMaxHealth(PlayerHitPoints);
        //images = GetComponents<Image>();
        //gameOverImage = images[0];
        //restartImage = images[1];
       // Debug.Log(gameOverImage);
       // Debug.Log(restartImage);
        gameOverImage.enabled = false;
        restartButton.enabled = false;
        restartText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("V_sword"))
        {
            Debug.Log("HIT");
            currentHitPoints = currentHitPoints - 1;
            healthBar.SetHealth(currentHitPoints);


            if (currentHitPoints <= 0 )
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
    
        Invoke("Wait", 3f);

    }
    public void Wait()
    {
        PlayAgain("PlayAgain");
    }

    public void PlayAgain (string PlayAgain)
    {
        Debug.Log("PlayAgainCalled");
        SceneManager.LoadScene(PlayAgain);

    }
}
