using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DrinkTimer : MonoBehaviour
{
    private NavMeshAgent agent;
    private float timePassed = 0;
    public float drinkMeter;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
