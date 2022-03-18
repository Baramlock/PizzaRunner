using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeedSide = 5;
    [SerializeField] private float _moveSpeedForward = 1;
    [SerializeField] private PlaneMover _planeMover;
    [SerializeField] private float _range;
    private PlayerInput _playerInput;
    private float _directionSide;

    private float _moveSpeed;

    private void Start()
    {
        _moveSpeed = _moveSpeedForward + _planeMover.MoveSpeed;
    }

    private void Awake()
    {
        _playerInput = new PlayerInput { };
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _directionSide = _playerInput.Player.Move.ReadValue<float>();

        if (_directionSide < 0 && (transform.position.x <= -_range))
        {
            _directionSide = 0;
            SetPositionX(-_range);
        }

        if (_directionSide > 0 && (transform.position.x >= _range))
        {
            _directionSide = 0;
            SetPositionX(+_range);
        }

        Move(CalculateDirection(_directionSide));
    }

    private Vector3 CalculateDirection(float directionSide)
    {
        return new Vector3(directionSide * _moveSpeedSide, 0, _moveSpeed);
    }

    private void Move(Vector3 direction)
    {
        transform.position = transform.position + (direction * Time.deltaTime);
    }

    private void SetPositionX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
