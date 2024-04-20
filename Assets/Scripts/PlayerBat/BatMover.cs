using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BatMover : MonoBehaviour, IResettable
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void OnValidate() => _rigidbody ??= GetComponent<Rigidbody2D>();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update() => Move();

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    private void Move()
    {
        if (PlayerInput.GetMove())
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotation * Time.deltaTime);
    }
}
