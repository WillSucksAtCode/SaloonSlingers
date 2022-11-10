using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquor : MonoBehaviour, IInteractible
{

    public AudioClip clip;

    enum liquorTypes : int {Red, Blue, Yellow, Violet, Orange, Green }
    [SerializeField] liquorTypes liquorType;
    [SerializeField] GameObject shaker;

    public void Interact()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        shaker.GetComponent<Shaker>().AddDrink((int)liquorType);
    }
    

    
}
