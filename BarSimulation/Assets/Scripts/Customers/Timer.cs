using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private NavMeshAgent agent;
    private float timePassed = 0;
    public float angerMeter;
    public Slider slider;
    public GameObject angerUI;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        angerUI.SetActive(false);

        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            timePassed += Time.deltaTime;
            slider.value = CalculateTime();
            angerUI.SetActive(true);
        }

        if (angerMeter <= timePassed)
        {
            Debug.Log("Im pissed!");
            SceneManager.LoadScene("LoseScene");
        }

        if (agent.pathPending)
        {
            timePassed = 0;
            angerUI.SetActive(false);
        }
    }

    float CalculateTime()
    {
        return timePassed / angerMeter;
    }

}
