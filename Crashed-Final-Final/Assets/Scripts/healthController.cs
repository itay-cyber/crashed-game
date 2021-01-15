using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    #region Variables
    public float health = 100.0f;
    private float maxHealth = 100.0f;

    public Image heartImg;
    public GameObject playerObj;
    #endregion

    #region Logic Methods
    //for now, param 2 is string
    //function to take damage
    public void TakeDamage(float howMuchDamage, string reasonHit)
    { 
        if (health <= 0)
        {
            Debug.Log("Player health has reached zero. Dying.");
            PlayerDIE(reasonHit);
        }
        else
        {
            health -= howMuchDamage;
            Debug.Log("Player took " + howMuchDamage.ToString() + " of damage. Current health: " + health);
        }
    }

    //function to die
    public void PlayerDIE(string reasonOfDeath)
    {
        //die
        //play death animation.. (ragdoll)?
        

        Debug.Log("Player died from " + reasonOfDeath + ".");
    }


    //function to add health

    public void RegenerateHealth(float toRegen)
    {
        if (health < maxHealth)
        {
            health += toRegen;
        }
        else
        {
            Debug.Log("The player health has reached max.");
        }
    }


    #endregion

    #region Built-In Methods
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        //fill up heart ui
        heartImg.rectTransform.sizeDelta = new Vector2(139.5394f, 85.22728f / 100 * health);

        //update entity attributes

        playerObj.GetComponent<attributesController>().entityHealth = health;
    }
    #endregion
}
