using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedSpawner : MonoBehaviour
{
    public ObjectPoolManager objPm;
    public GameObject pedprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            for(int i =0; i < 40; i++)
            objPm.ReturnObject("Char",transform.position,transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < 40; i++)
                Instantiate(pedprefab,transform.position,transform.rotation);
        }
    }
}
