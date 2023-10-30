using UnityEngine;

public class ChangeBottleColor : IColorCommand
{
    Liquor _liquor;
    Color _newColor;

    public ChangeBottleColor(Liquor liquor, Color newColor)
    {
        _liquor = liquor;
        _newColor = newColor;
    }

    public void Execute()
    {
        _liquor.GetComponent<Renderer>().material.color = _newColor;
    }
}
