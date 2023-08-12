using UnityEngine;

public class PlayerMovementMy : MonoBehaviour
{
    [SerializeField] private int _movementSpeed;

    private float _movementDirection;
    private Rigidbody _rigidbodyPlayer;

    private void Awake()
    {
        _rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movementDirection = Input.GetAxisRaw("Horizontal");
        Debug.Log("Input: " + _movementDirection);
    }

    private void FixedUpdate()
    {
        _rigidbodyPlayer.velocity = new Vector3(1, 0, 0) * _movementSpeed * _movementDirection;
        Debug.Log("Velocity: " + _rigidbodyPlayer.velocity);
    }
}