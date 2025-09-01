using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _moveAction, _shotAction;
    [SerializeField] float _speed;
    [SerializeField] float _fireRate = 0.5f;
    [SerializeField] float _canFire = -1f;
    [SerializeField] int _lives = 3;
    SpawnManager _spawnManager;
    [SerializeField] bool _istripleShotActive = false;
    [SerializeField] GameObject _tripleShotPrefab;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _shotAction = _playerInput.actions.FindAction("Shot");
        _spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is NULL");
        }
    }

    void Update()
    {
        MovePlayer();
        Shoot();
    }
        
    void Shoot()
    {
        if (_shotAction != null && _shotAction.ReadValue<float>() > 0f && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;

            if (_istripleShotActive == true)
            {
                GameObject triple = Instantiate(_tripleShotPrefab,transform.position + new Vector3(0f, -1.5f, 0f),Quaternion.identity);
                Destroy(triple, 2.5f); 
            }
            else
            {
                GameObject bullet = ObjectPooling.SharedInstance.GetPooledLaser();
                if (bullet != null)
                {
                    Vector3 bulletSpawnOffset = new Vector3(0f, 1.5f, 0f);
                    bullet.transform.position = transform.position + bulletSpawnOffset;
                    bullet.transform.rotation = Quaternion.identity;
                    bullet.SetActive(true);
                }
            }
        }
    }

    public void ActivateTripleShot(float duration = 5f)
    {
        _istripleShotActive = true;
        PowerUpEventManager.TriggerTripleShotActivated();
        StartCoroutine(TripleShotPowerDownRoutine(duration));
    }

    private IEnumerator TripleShotPowerDownRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        _istripleShotActive = false;
        PowerUpEventManager.TriggerTripleShotDesactivated();
    }

    void MovePlayer()
    {
        float moveX = _moveAction.ReadValue<Vector2>().x;
        transform.position += new Vector3(moveX, 0f, 0f) * _speed * Time.deltaTime;
        float moveY = _moveAction.ReadValue<Vector2>().y;
        transform.position += new Vector3(0f, moveY, 0f) * _speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        float clampedY = Mathf.Clamp(transform.position.y, -3f, 5f);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void Damage()
    {
        _lives--;

        if ( _lives == 0)
        {
            _spawnManager.OnPlayerDeath();
            this.gameObject.SetActive(false);
        }
    }
}
