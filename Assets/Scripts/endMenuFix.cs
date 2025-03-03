 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endMenuFix : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUI;

    void Start()
    {
        loseUI.SetActive(false); 
        winUI.SetActive(false);
    }

    void Update()
    {
        if (loseUI.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (winUI.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}