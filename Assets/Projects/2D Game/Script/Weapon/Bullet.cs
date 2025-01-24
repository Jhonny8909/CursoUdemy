using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float _speedBullet;

    void Update()
    {
        transform.Translate(Vector3.up * _speedBullet * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coll"))
        {
            gameObject.SetActive(false);
        }
    }
}
