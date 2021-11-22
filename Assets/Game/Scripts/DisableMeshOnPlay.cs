using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DisableMeshOnPlay : MonoBehaviour
{

    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
}
