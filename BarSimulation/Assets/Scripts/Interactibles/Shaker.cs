using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Shaker : MonoBehaviour, IInteractible
{
    public AudioClip clip;

    public int[] val = { 0, 0, 0 };
    int[] empty = { 0, 0, 0 };
    [SerializeField] GameObject shotGlass;

    [SerializeField] GameObject DrinksUIParent;
    public Transform[] drinkUITexts;
    GameObject player;
    private void Start()
    {
        drinkUITexts = DrinksUIParent.GetComponentsInChildren<Transform>();
        drinkUITexts = drinkUITexts.Skip(1).ToArray();
        player = GameObject.Find("Player");
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
        player.GetComponent<PlayerControls>().bottleMix();
        if (val != empty)
        {
            if (shotGlass.gameObject.active == false)
            {
                shotGlass.gameObject.SetActive(true);
            }

            for(int i = 0; i <= 2; i++)
            {
                shotGlass.GetComponent<ShotGlass>().values[i] = val[i];
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }

            Array.Clear(val, 0, val.Length);
        }
        
    }
}
