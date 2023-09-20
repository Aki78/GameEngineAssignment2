using UnityEngine;
using System.Collections.Generic;

public class ShootCircles : MonoBehaviour
{
    public GameObject circlePrefab;
    public float speed = 10f;
    public List<GameObject> circles = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Create a new circle instance
        GameObject circleInstance = Instantiate(circlePrefab, transform.position, Quaternion.identity);
        circles.Add(circleInstance);

        // Calculate the direction to shoot the circle
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Set the velocity of the circle
        circleInstance.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void Save()
    {
        List<GameObjectData> gameObjectsData = new List<GameObjectData>();

        foreach (GameObject circle in circles)
        {
            if (circle != null)
            {
                gameObjectsData.Add(new GameObjectData(circle, "Circle"));
            }
        }

        SaveSystem.SaveGameObjects(gameObjectsData);
    }

    void Load()
    {
        List<GameObjectData> gameObjectsData = SaveSystem.LoadGameObjects();

        foreach (GameObject circle in circles)
        {
            if (circle != null)
            {
                Destroy(circle);
            }
        }

        circles.Clear();

        foreach (GameObjectData gameObjectData in gameObjectsData)
        {
            GameObject prefab = ... // get the prefab using the recorded prefabName
            GameObject circle = Instantiate(prefab);
            circle.transform.position = new Vector3(gameObjectData.position[0], gameObjectData.position[1], gameObjectData.position[2]);
            circle.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObjectData.velocity[0], gameObjectData.velocity[1]);
            circles.Add(circle);
        }
    }
}

