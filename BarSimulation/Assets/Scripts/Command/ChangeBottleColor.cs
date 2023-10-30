using UnityEngine;

public class ChangeBottleColor : IColorCommand
{
    Liquor _liquor;

    public ChangeBottleColor(Liquor liquor)
    {
        _liquor = liquor;
    }

    public void Execute()
    {
        _liquor.GetComponent<Renderer>().material.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }
}
