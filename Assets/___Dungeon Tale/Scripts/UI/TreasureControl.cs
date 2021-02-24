using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureControl : MonoBehaviour
{
    [SerializeField] IntegerSO mapfragments;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("treasure here");
            mapfragments.value++;
            collision.gameObject.SetActive(false);
        }
    }
}
