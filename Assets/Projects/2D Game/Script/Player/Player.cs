using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _moveAction, _shootAction;
    [SerializeField]
    float _speed;
    [SerializeField]
    GameObject _bulletPrefab;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _shootAction = _playerInput.actions.FindAction("Shoot");
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }

    void Shoot()
    {
        if (_shootAction != null && _shootAction.WasPerformedThisFrame())
        {
            GameObject bullet = ObjectPooling.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                Vector3 bulletSpawnOffset = new Vector3(0f, 0.5f, 0f); // Ajusta el offset según el diseño
                bullet.transform.position = transform.position + bulletSpawnOffset;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
            }
        }
    }

    void MovePlayer()
    {
        Vector2 direction = _moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0f) * _speed * Time.deltaTime;
    }
}
