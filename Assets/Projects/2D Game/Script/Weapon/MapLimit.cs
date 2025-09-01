using UnityEngine;

public class MapLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}