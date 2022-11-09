using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour, IInteractible
{
    [SerializeField] GameObject canvas;
    [SerializeField] float activeRange;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, transform.position));   
        if(activeRange < Vector3.Distance(player.transform.position, transform.position)){
            Debug.Log("Disabled");
            canvas.SetActive(false);
        }
    }
    public void Interact()
    {
        if (canvas.active == false)
        {
            canvas.SetActive(true);
        }
        else canvas.SetActive(false);

    }
}
