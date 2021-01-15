using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerController : MonoBehaviour
{
    #region Variables
    public float hunger = 100.0f;
    private float maxHunger = 100.0f;

    public GameObject playerObj;
    public Image hungerImg;
    #endregion

    #region Logic Methods

    public void GetHungry(float howHungry)
    {
        if (hunger <= 0)
        {
            Debug.Log("Player's hunger has reached zero. Dying..");
            playerObj.GetComponent<healthController>().PlayerDIE("starvation");
        }
        else
        {
            hunger -= howHungry;
            Debug.Log("Player's hunger decreased by " + howHungry.ToString() + ". Hunger now " + hunger.ToString());
        }
    }

    public void Eat(float howEat)
    {
        if (hunger < maxHunger)
        {
            hunger += howEat;
        }
        else
        {
            Debug.Log("Player's hunger reached max.");
        }
    }


    private float calculateHungerDecrease()
    {
        float decrease = 0; //per second
        int playerLevel = playerObj.GetComponent<attributesController>().entityLevel;

        if (playerLevel < 5)
        {
            decrease = 6f;
        }
        else if (playerLevel >= 5)
        {
            decrease = 5f;
        }
        else if (playerLevel >= 10)
        {
            decrease = 4.8f;
        }
        else if (playerLevel >= 15)
        {
            decrease = 4.5f;
        }
        else if (playerLevel >= 20)
        {
            decrease = 4.2f;
        }
        else if (playerLevel >= 25)
        {
            decrease = 4.0f;
        }
        else if (playerLevel >= 30)
        {
            decrease = 3.5f;
        }

        return decrease;
    }

    #endregion

    #region IEnumerators

    IEnumerator HungerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(100f);
            GetHungry(calculateHungerDecrease());
        }
    }

    #endregion

    #region Built-In Methods

    // Start is called before the first frame update
    void Start() 
    {
        StartCoroutine(HungerLoop());
    }

    // Update is called once per frame
    void Update()
    {
        hungerImg.rectTransform.sizeDelta = new Vector2(100f, 100f/100 * hunger); 
    }
    #endregion
}
