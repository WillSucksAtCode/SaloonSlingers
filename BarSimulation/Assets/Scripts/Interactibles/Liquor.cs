using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquor : MonoBehaviour, IInteractible
{

    enum liquorTypes : int {Red, Blue, Yellow, Violet, Orange, Green }
    [SerializeField] liquorTypes liquorType;
    [SerializeField] GameObject shaker;

    public void Interact()
    {
        shaker.GetComponent<Shaker>().AddDrink((int)liquorType);
    }
    

    
}
