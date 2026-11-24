using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHousegenerator : MonoBehaviour
{

    public int forestSize = 50; // Overall size of the forest (a square of forestSize X forestSize).
    public int elementSpacing = 3; // The spacing between element placements. Basically grid size.
    public Element[] elements;

    public Terrain terrain;

    public Vector3 worldPos;

    private void Start()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        //z -40 50
        // x -50 45

        // Loop through all the positions within our forest boundary.
        for (float x = terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.1f); x < terrain.GetPosition().x + (terrain.terrainData.bounds.max.x * 0.9f); x += elementSpacing)
        {
            for (float z = terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.1f); z < terrain.GetPosition().z + (terrain.terrainData.bounds.max.z * 0.9f); z += elementSpacing)
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
                        Vector3 rotation = new Vector3(0, Random.Range(0, 360f), 0);
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        // Instantiate and place element in world.
                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        newElement.transform.eulerAngles = rotation;

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


}


[System.Serializable]
public class Element
{

    public string name;
    [Range(1, 10)]
    public int density;

    public GameObject[] prefabs;

    public bool CanPlace()
    {

        // Validation check to see if element can be placed. More detailed calculations can go here, such as checking perlin noise.

        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;

    }

    public GameObject GetRandom()
    {

        // Return a random GameObject prefab from the prefabs array.

        return prefabs[Random.Range(0, prefabs.Length)];

    }

}