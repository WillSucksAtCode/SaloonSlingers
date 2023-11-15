using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


public class Customer : NPC, IInteractible
{
    public int[] values = { 0, 0, 0 };
    public string orderDrinkName;
    GameObject playerGlass;
    public Dictionary<string, int[]> drinks = new Dictionary<string, int[]>();
    bool ordered = false;

    [SerializeField] DrinkScriptableData[] drinkList;

    [SerializeField] Transform drinkText;
    [SerializeField] Timer angerTimer;
    [SerializeField] DrinkTimer DrinkTimer;
    GameObject player;

    private void Start()
    {
        base.Start();

        player = GameObject.Find("Player");

        foreach (DrinkScriptableData drink in drinkList)
        {
            drinks.Add(drink.drinkName, new int[] { drink.beerValue, drink.vodkaValue, drink.GinValue }); 
        }

        
    }

    // Start is called before the first frame update
    void Update()
    {
        Walk();
        
    }

    public override void Walk()
    {
        base.Walk();

        if (!agent.pathPending && agent.remainingDistance < 0.5f && !ordered)
        {
            OrderDrink();
            drinkText.gameObject.SetActive(true);
            ordered = true;
        }

        drinkText.LookAt(player.transform);
        if (playerGlass == null)
        {
            playerGlass = GameObject.Find("Glass");
        }

    }
    public override void Interact()
    {
        if (playerGlass != null)
        {
            bool equal = true;

            for (int i = 0; i <= 2; i++)
            {
                if (drinks[orderDrinkName][i] != playerGlass.GetComponent<ShotGlass>().GetValues()[i])
                {
                    equal = false;
                }
            }

            if (equal == true)
            {
                drinkText.gameObject.SetActive(false);
                player.GetComponent<PlayerControls>().serveCorrect();
                queue.MoveBar();
                angerTimer.enabled = false;
                DrinkTimer.enabled = true;
            }
            else player.GetComponent<PlayerControls>().serveWrong();





            playerGlass.GetComponent<ShotGlass>().ClearValues();
        }
    }


    //Generates Customer drink value
    void OrderDrink()
    {


        orderDrinkName = drinks.ElementAt(Random.Range(0, drinks.Count)).Key;
        drinkText.GetComponent<TextMesh>().text = orderDrinkName;


        Debug.Log("Customer Order: " + orderDrinkName + ": " + (drinks[orderDrinkName][0]) + " , " + drinks[orderDrinkName][1] + " , " + drinks[orderDrinkName][2]);

    }

    public void LeaveBar()
    {
        queue.LeaveBar();
    }
}
