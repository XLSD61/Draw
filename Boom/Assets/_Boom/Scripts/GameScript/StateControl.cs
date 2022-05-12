using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
public class StateControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
