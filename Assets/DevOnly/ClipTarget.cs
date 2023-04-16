using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipTarget : MonoBehaviour
{
    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = PivotPointChangeTestScript.Instance.testMaterial[0];
    }
}
