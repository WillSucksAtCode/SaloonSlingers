using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shaker : MonoBehaviour, IInteractible
{
    public int[] val = { 0, 0, 0, 0, 0, 0 };
    int[] empty = { 0, 0, 0, 0, 0, 0 };
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
        if(val != empty)
        {
            if (shotGlass.gameObject.active == false)
            {
                shotGlass.gameObject.SetActive(true);
            }

            for(int i = 0; i <= 5; i++)
            {
                shotGlass.GetComponent<ShotGlass>().values[i] = val[i];
            }
            

            


            Array.Clear(val, 0, val.Length);
        }
        
        
    }
}
