using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGrassGenerator : MonoBehaviour
{

    public int forestSize = 50; // Overall size of the forest (a square of forestSize X forestSize).
    public int elementSpacing = 1; // The spacing between element placements. Basically grid size.
    public Element[] elements;

    public Terrain terrain;

    public Vector3 worldPos;

    private void Start()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        //z -40 50
        // x -50 45

        // Loop through all the positions within our forest boundary.
        for (float x = terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.01f); x < terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.99f); x += elementSpacing)
        {
            for (float z = terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.01f); z < terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.99f); z += elementSpacing)
            {

                // For each position, loop through each element...
                for (int i = 0; i < elements.Length; i++)
                {

                    // Get the current element.
                    Element element = elements[i];
                    Collider[] hitColliders = new Collider[10];

                    // Check if the element can be placed.
                    if (element.CanPlace() && !Physics.CheckSphere(new Vector3(x, 0.1f, z), 0.5f, 0) && Physics.CheckSphere(new Vector3(x, 0.1f, z), 0.5f, 9))
                    {

                        // Add random elements to element placement.
                        Vector3 position = new Vector3(x, 0f, z);
                        Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f), 0f, Random.Range(-0.75f, 0.75f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        // Instantiate and place element in world.
                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;

                        Rigidbody gameObjectsRigidBody = newElement.AddComponent<Rigidbody>(); // Add the rigidbody.
                        gameObjectsRigidBody.isKinematic = true;

                        //newElement.transform.localScale = scale;

                        // Break out of this for loop to ensure we don't place another element at this position.
                        break;

                    }

                }
            }
        }

    }

    IEnumerator turnOffTrigger(GameObject gameObject)
    {
        yield return new WaitForSeconds(1f);
        if (gameObject != null)
        {
            gameObject.GetComponent<MeshCollider>().isTrigger = false;
        }
    }

}