using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    public GameObject LoseCanvas;
    public GameObject ExitCanvas;

    // Update is called once per frame
    void Update()
    {
        if (LoseCanvas.activeInHierarchy || ExitCanvas.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
