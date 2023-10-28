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
    Dictionary<string, int[]> drinks = new Dictionary<string, int[]>();
    bool ordered = false;

    

    [SerializeField] Transform drinkText;
    GameObject player;

    private void Start()
    {
        base.Start();

        player = GameObject.Find("Player");

        drinks.Add("Silverhand Special", new int[] { 3, 2, 3 });
        drinks.Add("The Huntsman", new int[] { 3, 4, 3 });
        drinks.Add("Death's Friend", new int[] { 4, 4, 4 });
        drinks.Add("Killer Queen", new int[] { 2, 2, 2 });
        drinks.Add("Loreley's Vanquisher", new int[] { 4, 4, 0 });
        drinks.Add("Bit of Everything", new int[]{1, 1, 1});
        drinks.Add("Drunken Outlaw", new int[] { 3, 3, 3 });
        drinks.Add("Vodka", new int[] { 0, 4, 0 });
        drinks.Add("Gin", new int[] { 0, 0, 4 });
        drinks.Add("Beer", new int[] { 4, 0, 0 });
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
}
