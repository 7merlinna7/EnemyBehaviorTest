using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _currentTarget;
    private Quaternion _lookRotation;

    public void Move(Vector3 target,int direction)
    {
        Vector3 moveDirection = GetDirectionToTarget(target);
        Vector3 normalazedMoveDirection = moveDirection.normalized * (direction);
        ProcessRorateTo(transform, normalazedMoveDirection);
        ProcessMoveToTarget(normalazedMoveDirection);
    }

    public Vector3 GetDirectionToTarget(Vector3 currentTarget) => currentTarget - transform.position;

    public void ProcessMoveToTarget(Vector3 direction) => transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    public void ProcessRorateTo(Transform _characterTransform, Vector3 direction)
    {
        _lookRotation = Quaternion.LookRotation(direction);
        if (_lookRotation != Quaternion.identity)
        {
            float step = _rotationSpeed * Time.deltaTime;
            _characterTransform.rotation = Quaternion.RotateTowards(_characterTransform.rotation, _lookRotation, step);
        }
    }
}
