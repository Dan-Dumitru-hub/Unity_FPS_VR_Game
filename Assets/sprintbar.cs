using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sprintbar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image BAR;
    public float fill;

    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        BAR.fillAmount = fill;
    }
}
