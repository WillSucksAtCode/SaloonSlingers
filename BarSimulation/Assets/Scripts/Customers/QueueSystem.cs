    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QueueSystem : MonoBehaviour
{
    public List<GameObject> barQ = new List<GameObject>();
    public List<GameObject> waitQ = new List<GameObject>();
    public List<Transform> barQueuePos = new List<Transform>();
    public List<Transform> waitQueuePos = new List<Transform>();

    public GameObject customer;
    public Transform customerStart;

    public GameObject spawnLocation;

    private float time = 0.0f;
    public float customerSpawnDelay = 10.0f;
    public int spawnLimit = 8;
    private void Start()
    {
        spawnLocation = GameObject.Find("SpawnLocation");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= customerSpawnDelay && spawnLocation.transform.childCount <= spawnLimit)
        {
            time = 0.0f;
            AddToQueue(barQueuePos, barQ, Instantiate(customer, customerStart.position, customerStart.rotation, spawnLocation.transform));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddToQueue(barQueuePos, barQ, Instantiate(customer, customerStart.position, customerStart.rotation, spawnLocation.transform));
        }
    }

    public bool AddToQueue(List<Transform> list, List<GameObject> objs, GameObject newobj)
    {
        if (objs.Count >= list.Count || newobj == null) return false;

        newobj.GetComponent<NavMeshAgent>().destination = list[objs.Count].position;
        objs.Add(newobj);

        return true;
    }

    public GameObject RemoveFront(List<Transform> list, List<GameObject> objs)
    {
        if (objs.Count == 0) return null;

        GameObject obj = objs[0];
        objs.RemoveAt(0);
        CalcPos(list, objs);
        return obj;
    }

    public void CalcPos(List<Transform> list, List<GameObject> objs)
    {
        int i = 0;
        foreach (GameObject obj in objs)
        {
            NavMeshAgent agent = obj.GetComponent<NavMeshAgent>();

            //set targets here
            agent.destination = list[i++].position;
        }
    }

    public void MoveBar()
    {
        AddToQueue(waitQueuePos, waitQ, RemoveFront(barQueuePos, barQ));
    }
}
