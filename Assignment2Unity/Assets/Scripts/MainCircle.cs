using UnityEngine;
using System.Collections.Generic;

public class ShootCircles : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<GameObject> circles = new List<GameObject>();

    private void Start()
    {
        print("Loading...");
        Load();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Savign...");
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Loading...");
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
                gameObjectsData.Add(new GameObjectData(circle, "ShootCircle"));
            }
        }

        SaveSystem.SaveGameObjects(gameObjectsData);
        // Destroying circles to demonsteight the save and load functions
        foreach (GameObject circle in circles)
        {
            if (circle != null)
            {
                Destroy(circle);
            }
        }
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
            GameObject prefab = Resources.Load<GameObject>("ShootCircle");
            GameObject circle = Instantiate(prefab);
            circle.transform.position = new Vector3(gameObjectData.position[0], gameObjectData.position[1], gameObjectData.position[2]);
            circle.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObjectData.velocity[0], gameObjectData.velocity[1]);
            circles.Add(circle);
        }
    }
}
