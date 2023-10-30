using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Drink Data", menuName="Drink Data/Drink")]
public class DrinkScriptableData : ScriptableObject
{
    public string drinkName;
    public int beerValue;
    public int vodkaValue;
    public int GinValue;
}
