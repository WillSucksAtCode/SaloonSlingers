using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour, IInteractible
{
    public int[] val = { 0, 0, 0, 0, 0, 0 };

    [SerializeField] GameObject shotGlass;

    private void Start()
    {
        
    }
    public void AddDrink(int drink)
    {
        if (val[drink] < 4)
        {
            val[drink]++;
        }
        
    }
    public void Interact()
    {
        if (shotGlass.gameObject.active == false)
        {
            shotGlass.gameObject.SetActive(true);
        }

        shotGlass.GetComponent<ShotGlass>().SetValues(val);

        

        Array.Clear(val, 0, 6);
        
    }
}
