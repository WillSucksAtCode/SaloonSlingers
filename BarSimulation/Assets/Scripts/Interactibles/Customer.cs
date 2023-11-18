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
    public CustomerState custState = CustomerState.WALK;
    public Dictionary<string, int[]> drinks = new Dictionary<string, int[]>();
    bool ordered = false;

    [SerializeField] DrinkScriptableData[] drinkList;

    [SerializeField] Transform drinkText;
    [SerializeField] Timer angerTimer;
    [SerializeField] DrinkTimer DrinkTimer;
    GameObject player;
    GameObject achievementManager;
    private void Start()
    {
        base.Start();

        achievementManager = GameObject.Find("AchievementManager");

        player = GameObject.Find("Player");

        foreach (DrinkScriptableData drink in drinkList)
        {
            drinks.Add(drink.drinkName, new int[] { drink.beerValue, drink.vodkaValue, drink.GinValue }); 
        }

        
    }

    // Start is called before the first frame update
    void Update()
    {
        switch (custState)
        {
            case CustomerState.WALK:
                Walk();
                break;
            case CustomerState.ORDER:
                OrderDrink();
                custState = CustomerState.WALK;
                break;
            case CustomerState.DRINK:
                queue.MoveBar();
                custState = CustomerState.WALK;
                break;
            case CustomerState.LEAVE:
                queue.LeaveBar();
                custState = CustomerState.WALK;
                break;
        }   
    }

    public override void Walk()
    {
        base.Walk();

        if (!agent.pathPending && agent.remainingDistance < 0.5f && !ordered)
        {
            drinkText.gameObject.SetActive(true);
            ordered = true;
            custState = CustomerState.ORDER;
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
                custState = CustomerState.DRINK;
                angerTimer.enabled = false;
                DrinkTimer.enabled = true;
                achievementManager.GetComponent<AchievementManager>().AddCustomerServed();
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

    public enum CustomerState
    {
        WALK,
        ORDER,
        DRINK,
        LEAVE,
        ENABLE,
        DISABLE
    }
}
