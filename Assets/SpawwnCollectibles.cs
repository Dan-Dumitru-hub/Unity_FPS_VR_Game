using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawwnCollectibles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collectible;
    public int xpos;
    public int ypos;
    public int zpos;
    private int EnemyCount;
    private int TotalEnemyCount;
 

    private float coolDownTimer;
    private float coolDown = 1f;

    //GameObject Prefab => Resources.Load<GameObject>(enemy);
    void Start()
    {
        EnemyCount = GetComponent<gameEvent>().collectiblesGotten;
        TotalEnemyCount = GetComponent<gameEvent>().collectiblesTotal;
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        float planeX = plane.GetComponent<Transform>().position.x;
        float planeZ = plane.GetComponent<Transform>().position.z;
        float scaleX = plane.GetComponent<Transform>().localScale.x;
        float scaleZ = plane.GetComponent<Transform>().localScale.z;



    }

   

    // Update is called once per frame
    void CollectibleDrop()
    {
        // var Component = enemy.GetComponent<Enemyfollow>();
        //print(EnemyCount);

        Terrain terrain = GameObject.FindGameObjectWithTag("Plane").gameObject.GetComponent<Terrain>();
        float xMin = terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.2f);
        float xMax = terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.9f);
        float zMin = terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.2f);
        float zMax = terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.9f);

        while (EnemyCount < TotalEnemyCount)
        {
            if (coolDownTimer <= 0)
            {
                xpos = Random.Range((int)xMin,(int)xMax);
                //ypos = 0;
                zpos = Random.Range((int)zMin,(int)zMax);

                // Component.player = VRRig.transform;
                // enemy.player = VRRig.transform;

                //if (enemy.)
                Instantiate(collectible, new Vector3(xpos, ypos, zpos), Quaternion.identity);

                //enemy.transform.LookAt(VRRig);
                //enemy.transform.Rotate(0, 180, 0);
                // enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, VRRig.position, 10*Time.deltaTime);


                EnemyCount += 1;

                coolDownTimer = coolDown;
            }
            else
            {
                coolDownTimer -= Time.deltaTime;
            }
            
        }

    }

    private void Update()
    {
        Invoke("CollectibleDrop",1f);
    }
}
