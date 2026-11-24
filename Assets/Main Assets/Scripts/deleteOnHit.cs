using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("Glont -> loveste inamic");
            Destroy(this);
            Destroy(other);
        }

    }
}
