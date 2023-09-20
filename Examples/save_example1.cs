[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] velocity;

    public PlayerData(Rigidbody2D player)
    {
        position = new float[2];
        position[0] = player.position.x;
        position[1] = player.position.y;

        velocity = new float[2];
        velocity[0] = player.velocity.x;
        velocity[1] = player.velocity.y;
    }
}

// Save player data
Rigidbody2D player = ... // get the player's Rigidbody2D
PlayerData playerData = new PlayerData(player);
SaveSystem.SavePlayer(playerData);

// Load player data
PlayerData playerData = SaveSystem.LoadPlayer();
player.position = new Vector2(playerData.position[0], playerData.position[1]);
player.velocity = new Vector2(playerData.velocity[0], playerData.velocity[1]);

