[System.Serializable]
public class GameObjectData
{
    public string prefabName;
    public float[] position;
    public float[] rotation;
    public float[] scale;
    // other properties

    public GameObjectData(GameObject gameObject, string prefabName)
    {
        this.prefabName = prefabName;

        position = new float[3];
        position[0] = gameObject.transform.position.x;
        position[1] = gameObject.transform.position.y;
        position[2] = gameObject.transform.position.z;

        rotation = new float[4];
        rotation[0] = gameObject.transform.rotation.x;
        rotation[1] = gameObject.transform.rotation.y;
        rotation[2] = gameObject.transform.rotation.z;
        rotation[3] = gameObject.transform.rotation.w;

        scale = new float[3];
        scale[0] = gameObject.transform.localScale.x;
        scale[1] = gameObject.transform.localScale.y;
        scale[2] = gameObject.transform.localScale.z;

        // other properties
    }
}

// Save game object data
GameObject gameObject = ... // get the game object
string prefabName = ... // get the prefab name
GameObjectData gameObjectData = new GameObjectData(gameObject, prefabName);
SaveSystem.SaveGameObject(gameObjectData);

// Load game object data
GameObjectData gameObjectData = SaveSystem.LoadGameObject();
GameObject prefab = ... // get the prefab using the recorded prefabName
GameObject gameObject = Instantiate(prefab);
gameObject.transform.position = new Vector3(gameObjectData.position[0], gameObjectData.position[1], gameObjectData.position[2]);
gameObject.transform.rotation = new Quaternion(gameObjectData.rotation[0], gameObjectData.rotation[1], gameObjectData.rotation[2], gameObjectData.rotation[3]);
gameObject.transform.localScale = new Vector3(gameObjectData.scale[0], gameObjectData.scale[1], gameObjectData.scale[2]);
// other properties

