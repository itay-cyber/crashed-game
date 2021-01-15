using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class waterController : MonoBehaviour
{
    #region Variables
    public float thirst = 100.0f;
    private float maxThirst = 100.0f;


    public Image waterImg;
    public GameObject playerObj;
    #endregion

    #region Logic Methods
    //function to reduce thirst meter
    public void GetThirsty(float howThirsty)
    {
        if (thirst <= 0)
        {
            Debug.Log("Player has reached zero thirst.. Dying");
            playerObj.GetComponent<healthController>().PlayerDIE("thirst");
        }
        else
        {
            thirst -= howThirsty;
            Debug.Log("Player's thirst decreased by " + howThirsty.ToString() + ". Player's thirst now " + thirst.ToString() + ".");
        }
    }

    public void DrinkWater(float howMuchRegenWater)
    {
        if (thirst < maxThirst)
        {
            thirst += howMuchRegenWater;
        }
        else
        {
            Debug.Log("Player thirst reached max.");
        }
    }
    #endregion

    #region Built-In Methods
    void Update()
    {
        //fill up water ui
        waterImg.rectTransform.sizeDelta = new Vector2(100f,94.21179f/100 * thirst);
    }

    void Start() { }
    #endregion
}
