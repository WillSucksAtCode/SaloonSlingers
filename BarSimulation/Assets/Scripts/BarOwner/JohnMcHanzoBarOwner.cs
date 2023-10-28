using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMcHanzoBarOwner : NPC, IInteractible
{
    [SerializeField] Transform managerText;
    public override void Interact()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        managerText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        managerText.gameObject.SetActive(false);

    }
}
