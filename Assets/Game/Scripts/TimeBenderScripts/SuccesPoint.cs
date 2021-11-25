using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class SuccesPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.Human.ToString()))
        {
            EventManager.OnGameSuccess.Invoke();
        }
    }
}
