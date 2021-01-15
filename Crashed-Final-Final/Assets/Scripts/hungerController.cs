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
    #endregion

    #region Built-In Methods

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        hungerImg.rectTransform.sizeDelta = new Vector2(100f, 100f/100 * hunger); 
    }
    #endregion
}
