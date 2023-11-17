using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeleteCustomer : MonoBehaviour
{
    private NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
