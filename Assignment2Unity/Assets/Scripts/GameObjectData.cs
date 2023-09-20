
using UnityEngine;

[System.Serializable]
public class GameObjectData
{
    public string prefabName;
    public float[] position;
    public float[] velocity;

    public GameObjectData(GameObject gameObject, string prefabName)
    {
        this.prefabName = prefabName;

        position = new float[3];
        position[0] = gameObject.transform.position.x;
        position[1] = gameObject.transform.position.y;
        position[2] = gameObject.transform.position.z;

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            velocity = new float[2];
            velocity[0] = rb.velocity.x;
            velocity[1] = rb.velocity.y;
        }
        else
        {
            velocity = new float[2] { 0, 0 }; // Default to zero if no Rigidbody2D is present
        }
    }
}


//EXAMPLES:

// Save game object data Examples

//GameObject gameObject = ... // get the game object
//string prefabName = ... // get the prefab name
//GameObjectData gameObjectData = new GameObjectData(gameObject, prefabName);
//SaveSystem.SaveGameObject(gameObjectData);

// Load game object data Examples

//GameObjectData gameObjectData = SaveSystem.LoadGameObject();
//
//string prefabName = "Resources/Circle"; 
//GameObject prefab = Resources.Load<GameObject>(prefabName);
//
//GameObject gameObject = Instantiate(prefab);
//gameObject.transform.position = new Vector3(gameObjectData.position[0], gameObjectData.position[1], gameObjectData.position[2]);
