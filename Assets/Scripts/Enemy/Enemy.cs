using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {   
        Debug.Log($"Collision with {collision.gameObject.name}");
    }
}
