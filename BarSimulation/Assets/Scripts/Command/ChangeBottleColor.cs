using UnityEngine;

public class ChangeBottleColor : IColorCommand
{
    Liquor _liquor;

    public void ChangeColorCommand(Liquor liquor)
    {
        _liquor = liquor;
        _liquor.GetComponent<Renderer>().material.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }

    public void Execute()
    {
       _liquor.ChangeColor();
    }
}
