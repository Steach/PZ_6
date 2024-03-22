using UnityEngine;

public class LocationBuilder : MonoBehaviour
{
    [Header("Create and Config Player")]
    [SerializeField] private string playerName;
    [SerializeField] private Material playerMaterial;
    [SerializeField] private Move moveScript;
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerCollision playerCollisionScript;

    [Header("Create and Config Enemy")]
    [SerializeField] private string enemyName;
    [SerializeField] private Material enemyMaterial;
    [SerializeField] private Enemy enemyScript;

    [Header("Create and Config ground")]
    [SerializeField] private string groundName;
    [SerializeField] private Material groundMaterial;

    private int counter = 0;

    private void Start()
    {
        BuildPlayer(playerName);
        BuildEnemy(enemyName);
        BuildGround(groundName);
    }

    private void BuildPlayer(string name)
    {
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player.name = name;

        if (counter == 0)
        {
            player.transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
            counter++;
        }
        

        Rigidbody playerRb = player.AddComponent(typeof(Rigidbody)) as Rigidbody;
        playerRb.useGravity = false;
        playerRb.isKinematic = true;

        Renderer renderer = player.GetComponent<Renderer>();
        renderer.material = playerMaterial;

        player.AddComponent<Move>();
        player.AddComponent<PlayerCollision>();

        Move playerMove = player.GetComponent<Move>();
        playerMove.ChangeSpeed(moveSpeed);
    }

    private void BuildEnemy(string name)
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.name = name;

        enemy.transform.position = new Vector3(transform.position.x, 4, transform.position.y);

        Rigidbody enemyRb = enemy.AddComponent(typeof(Rigidbody)) as Rigidbody;
        enemyRb.drag = 3;

        Renderer renderer = enemy.GetComponent<Renderer>();
        renderer.material = enemyMaterial;

        enemy.AddComponent<Enemy>();
    }

    private void BuildGround(string name)
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ground.name = name;

        ground.transform.position = new Vector3(0f, 0f, 0f);

        ground.transform.localScale = new Vector3(10f, 0.2f, 10f);

        Renderer renderer = ground.GetComponent<Renderer>();
        renderer.material = groundMaterial;
    }
}
