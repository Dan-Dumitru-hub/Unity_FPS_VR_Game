using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proj;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
        {

            GameObject spawnedBullet = Instantiate(proj, transform.position, Quaternion.identity);
            Destroy(spawnedBullet,0.7f);

            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
