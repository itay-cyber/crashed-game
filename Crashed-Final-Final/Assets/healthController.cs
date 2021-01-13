using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    public int Health = 100;
    public Image Heart;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Heart.rectTransform.sizeDelta = new Vector2(139.5394f,85.22728f/100 * Health);
    }
}
