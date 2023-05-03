using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointChangeTestScript : Singleton<PivotPointChangeTestScript>
{
    public Material[] testMaterial;
    private void Update()
    {
        Debug.Log(testMaterial[0].GetVector("_PivotPoint"));
        testMaterial[0].SetVector("_PivotPoint", transform.position);
    }
}
