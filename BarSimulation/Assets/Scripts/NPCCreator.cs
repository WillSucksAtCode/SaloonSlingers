using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class NPC : MonoBehaviour
{
    protected NavMeshAgent agent;
    public bool walk;
    protected Vector3 oldPosition;
    public QueueSystem queue;

    public virtual void Start()
    {
        oldPosition = transform.position;
        queue = FindObjectOfType<QueueSystem>();
        agent = GetComponent<NavMeshAgent>();
    }

    public abstract void Interact();

    public virtual void Walk()
    {
        if (oldPosition != transform.position)
        {
            walk = true;
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else
        {
            walk = false;
            GetComponent<Animator>().SetBool("Walk", false);
        }
        oldPosition = transform.position;
    }
}