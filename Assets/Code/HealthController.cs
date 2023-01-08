using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int playerHealth;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    
    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GetComponent<PlayerHealthSystem>.currentHealth;
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            playerHealth--;
            UpdateHealth();
        }
    }

    public void UpdateHealth()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i<playerHealth)
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
