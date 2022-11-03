using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShotGlass : MonoBehaviour
{
    public int[] values = { 0, 0, 0, 0, 0, 0 };

   


    public int[] GetValues()
    {
        return values;

    }

    public void SetValues(int[] val)
    {
        Debug.Log("Values: " + (values[0]) + " , " + values[1] + " , " + values[2] + " , " + values[3] + " , " + values[4] + " , " + values[5]);
        values = val;
    }
}
