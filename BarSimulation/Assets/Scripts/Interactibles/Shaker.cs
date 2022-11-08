using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Shaker : MonoBehaviour, IInteractible
{
    public int[] val = { 0, 0, 0, 0, 0, 0 };
    int[] empty = { 0, 0, 0, 0, 0, 0 };
    [SerializeField] GameObject shotGlass;

    [SerializeField] GameObject DrinksUIParent;
    public Transform[] drinkUITexts;
    private void Start()
    {
        drinkUITexts = DrinksUIParent.GetComponentsInChildren<Transform>();
        drinkUITexts = drinkUITexts.Skip(1).ToArray();
    }
    private void Update()
    {
        int i = 0;
        foreach (Transform t in drinkUITexts)
        {
            t.gameObject.GetComponent<TextMeshProUGUI   >().SetText("{0}", val[i]);
            i++;
        }    
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
