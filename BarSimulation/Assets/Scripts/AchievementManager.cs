using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    private const string DLL_NAME = "Assets/Plugin/UnityPlugin.dll";

    [DllImport(DLL_NAME, EntryPoint = "GetSaveData")]

    private static extern int GetSaveData();

    [DllImport(DLL_NAME, EntryPoint = "SaveSaveData")]

    private static extern int SaveSaveData(int serveCount);

    [SerializeField] GameObject bronzeTrophy;
    [SerializeField] GameObject silverTrophy;
    [SerializeField] GameObject goldTrophy;

    int customerServed;

    // Start is called before the first frame update
    void Start()
    {
        customerServed = GetSaveData();
    }

    // Update is called once per frame
    void Update()
    {
        //Test
        if (Input.GetKeyDown("space"))
        {
            AddCustomerServed();
            Debug.Log("PPPOPO");
        }

        if(bronzeTrophy.active == false && customerServed >= 5)
        {
            bronzeTrophy.active = true;
        }
        if (silverTrophy.active == false && customerServed >= 25)
        {
            silverTrophy.active = true;
        }
        if (goldTrophy.active == false && customerServed >= 50)
        {
            goldTrophy.active = true;

        }
    }


    public void AddCustomerServed()
    {
        customerServed++;
        SaveSaveData(customerServed);
    }

}
