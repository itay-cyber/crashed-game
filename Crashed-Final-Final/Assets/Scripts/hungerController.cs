using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerController : MonoBehaviour
{
    public float hunger = 100f;
    public Image hungerImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerImg.rectTransform.sizeDelta = new Vector2(100f, 100f/100 * hunger); 
    }
}
