using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearItem : MonoBehaviour
{

    public GameObject objectToDisappear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
            Destroy(objectToDisappear);
            Destroy(gameObject);
        }
    }
}
