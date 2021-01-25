using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyEventScript : MonoBehaviour
{
    public CanvasGroup inventory;
    public bool inventoryVisible = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            print("hello");
            if (inventoryVisible == true)
            {
                inventory.alpha = 0;
                inventory.interactable = false;
                inventoryVisible = false;
                Cursor.visible = false;
                Screen.lockCursor = true;
            }

            else
            {
                inventory.alpha = 1;
                inventory.interactable = true;
                inventoryVisible = true;
                Cursor.visible = true;
                Screen.lockCursor = false;
            }


        }
    }
}
