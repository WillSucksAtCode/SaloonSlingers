using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Customer : MonoBehaviour, IInteractible
{
    public int[] values = { 0, 1, 0, 0, 0, 0 };
    GameObject playerGlass;


    private void Start()
    {
        OrderDrink();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (playerGlass == null)
        {
            playerGlass = GameObject.Find("Glass");
        }
        
        
        
    }

    
    public void Interact()
    {
        if (playerGlass != null)
        {

            if (values.SequenceEqual(playerGlass.GetComponent<ShotGlass>().GetValues()))
            {
                Debug.Log("YES");
                gameObject.SetActive(false);

            }
            else Debug.Log("NO");

            playerGlass.GetComponent<ShotGlass>().ClearValues();
        }
        

    }

    //Generates Customer drink value
    void OrderDrink()
    {
        for (int i = 0; i <= 5; i++)
        {
            values[i] = Random.Range(0, 5);
        }
        Debug.Log("Customer Values: " + (values[0]) + " , " + values[1] + " , " + values[2] + " , " + values[3] + " , " + values[4] + " , " + values[5]);

    }

}
