using System.Collections.Generic;
using UnityEngine;

public class RestBehaviour : MonoBehaviour
{
    private EnemyMover _mover;

    //PATROL
    [SerializeField] private List<Transform> _patrolPoints;
    private float _minDistanceToTarget = 0.05f;
    private Queue<Vector3> _targetsPositions;
    private Vector3 _currentTarget;
    private const int _forwardDirection = 1;
    //WALK
    private float _timer = 0;
    private float _timeToChangeDirection = 1f;
    private Vector3 normalazedMoveDirection;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _targetsPositions = new Queue<Vector3>();
        foreach (Transform target in _patrolPoints)
            _targetsPositions.Enqueue(target.position);
        SwitchTarget();
    }

    public void Rest(RestEnemyStates currentRestEnemyState)
    {
        switch (currentRestEnemyState)
        {
            case RestEnemyStates.Stay:
                Debug.Log("Ya stoyu");
                break;

            case RestEnemyStates.Walk:
                Walking();
                break;

            case RestEnemyStates.Patrolling:
                Patrolling();
                break;
        }
    }

    private void Walking()
    {
        Debug.Log("Idu");
        if(transform.position.x>= 13f || transform.position.x <=-13f ||transform.position.z>=17f || transform.position.z <= -10f)
        {
            ChangeMoveSide();
            _timer = Time.deltaTime;
        }

        if(_timer == 0)
        {
            ChangeMoveSide();
        }

        if (_timer < _timeToChangeDirection)
        {
            _timer += Time.deltaTime;
            _mover.ProcessMoveToTarget(normalazedMoveDirection);
        }

        if (_timer >= _timeToChangeDirection) 
            _timer= 0;

    }

    //PATROL
    private void Patrolling()
    {
        Debug.Log("Patruliruyu");
        Vector3 direction = _mover.GetDirectionToTarget(_currentTarget);
        if (direction.magnitude <= _minDistanceToTarget)
            SwitchTarget();

        _mover.Move(_currentTarget, _forwardDirection);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPositions.Dequeue();
        _targetsPositions.Enqueue(_currentTarget);
    }

    //WALK
    private void ChangeMoveSide()
    {
        int xDirection = Random.Range(-1, 2);
        int zDirection = Random.Range(-1, 2);
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        normalazedMoveDirection = direction.normalized;
    }
}
