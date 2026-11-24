using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeFunction : MonoBehaviour
{
   public void onPickup()
    {
        gameObject.SetActive(false);
    }

    public void onDrop()
    {
        gameObject.SetActive(true);
    }
}
