using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractible
{
    int[] empty = { 0, 0, 0, 0, 0, 0 };
    [SerializeField] GameObject shotGlass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        shotGlass.GetComponent<ShotGlass>().ClearValues();
    }
}
