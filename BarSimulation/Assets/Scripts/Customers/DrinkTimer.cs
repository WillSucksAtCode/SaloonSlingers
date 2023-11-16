using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrinkTimer : MonoBehaviour
{
    private NavMeshAgent agent;
    private float timePassed = 0;
    private float drinkMeter = 20;
    bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            timePassed += Time.deltaTime;
        }

        if (drinkMeter <= timePassed)
        {
            Debug.Log("Im refreshed!");
            GetComponent<Customer>().LeaveBar();
            if (kill)
            {
                Destroy(gameObject);
            }
            kill = true;
            drinkMeter = 5;
        }

        if (agent.pathPending)
        {
            timePassed = 0;
        }
    }

    float CalculateTime()
    {
        return timePassed / drinkMeter;
    }
}
