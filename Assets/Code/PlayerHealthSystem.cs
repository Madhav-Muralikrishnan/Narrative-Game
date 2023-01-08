using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    public int startingHealth = 3;
    public int currentHealth=1;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private PlayerController playerController;

    public static bool killedByBoss = false;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = ChangeLevel.healthTrack;
        UpdateHealth();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
            UpdateHealth();
        }
        
    }

    
    public void TakeDamage(int dmg)
    {
       currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth);

        if(currentHealth > 0)
        {   
            UpdateHealth();
            print(currentHealth);
        }
        else
        {
            if(Boss.isBossAttacking == true)
            {
                killedByBoss = true;
            }

            if(killedByBoss == true)
            {
                //SceneManager.LoadScene(16, LoadSceneMode.Single);
            }
            else
            {
                playerController.transform.position = playerController.respawnPoint;
                currentHealth = 3;
            }
        }
       
    }

    //private int playerHealth;
    public void UpdateHealth()
    {
        for(int i = 0; i < hearts.Length; i++)
        {

            if(i<currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

   
}
