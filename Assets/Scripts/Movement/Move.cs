using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        float currentZ = transform.position.z;

        if (Input.GetKey(KeyCode.D)) transform.position = new Vector3(currentX + moveSpeed, currentY, currentZ);
        else if(Input.GetKey(KeyCode.A)) transform.position = new Vector3(currentX - moveSpeed, currentY, currentZ);
    }
}
