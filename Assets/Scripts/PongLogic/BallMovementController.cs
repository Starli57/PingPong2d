using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public void SetConfiguration(BallData data)
    {
        _speed = data.speed;
    }

    public void ResetState()
    {
        transform.position = Vector3.zero;
        SetRandomDirection();
    }

    [SerializeField] private float _speed = 10;

    private Rigidbody2D _rigidBody;

    private Vector2 _direction;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPosition = currentPosition + _direction * _speed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(targetPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Reflect(collision.contacts[0].normal);
    }

    private void Reflect(Vector3 reflectVector)
    {
        _direction = Vector3.Reflect(_direction, reflectVector);
    }

    private void SetRandomDirection()
    {
        int signX = Random.Range(0, 2) == 0 ? -1 : 1;
        int signY = Random.Range(0, 2) == 0 ? -1 : 1;

        _direction = new Vector2(Screen.width * signX, Screen.height * 2f * signY).normalized;
    }
}
