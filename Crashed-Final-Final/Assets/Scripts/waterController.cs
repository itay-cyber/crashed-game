using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class waterController : MonoBehaviour
{
    public float water = 100f;
    public Image waterImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waterImg.rectTransform.sizeDelta = new Vector2(100f,94.21179f/100 * water);
    }
}
