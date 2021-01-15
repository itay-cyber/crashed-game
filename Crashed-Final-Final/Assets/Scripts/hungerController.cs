using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerController : MonoBehaviour
{
    public GameObject playerObj;

    public float hunger = 100.0f;
    public Image hungerImg;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void GetHungry(float howHungry)
    {
        if (hunger > 0)
        {
            hunger -= howHungry;
        }
        else
        {
            playerObj.GetComponent<healthController>().PlayerDIE("starvation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        hungerImg.rectTransform.sizeDelta = new Vector2(100f, 100f/100 * hunger); 
    }
}
