using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    public float health = 100.0f;
    public Image heartImg;

	// Start is called before the first frame update
    void Start()
    {
        TakeDamage(50.0f, "Was stung by a psychotic tree... ");
    }

    // Update is called once per frame
    void Update()
    {
        heartImg.rectTransform.sizeDelta = new Vector2(139.5394f,85.22728f/100 * health);
    }

    //for now, param 2 is string
    void TakeDamage(float howMuchDamage, string reasonHit)
    {
        health -= howMuchDamage;
        if (health <= 0)
        {
            Debug.Log("Player health has reached zero. Dying.");
            PlayerDIE(reasonHit);
        }
        else
        {
            Debug.Log("Player took " + howMuchDamage.ToString() + " of damage. Current health: " + health);
        }
    }

    void PlayerDIE(string reasonOfDeath)
    {
        //die
        //play death animation.. (ragdoll)?
           
        Debug.Log("Player died from " + reasonOfDeath);
    }
}
