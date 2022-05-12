using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyControl : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 7f);
    }
}
