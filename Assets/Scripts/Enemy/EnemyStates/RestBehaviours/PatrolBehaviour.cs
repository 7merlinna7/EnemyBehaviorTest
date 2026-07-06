using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : IRestBehaviour
{
    private List<Transform> _patrolPoints;
    private Mover _mover;

    private Queue<Vector3> _targetsPositions;
    private Vector3 _currentTarget;
    private float _minDistanceToTarget = 0.05f;

    public PatrolBehaviour(Mover mover, Queue<Vector3> targetsPositions,Vector3 firstTarget)
    {
        _mover = mover;
        _targetsPositions = targetsPositions;
        _currentTarget = firstTarget;
    }

    public void Rest()
    {
        Debug.Log("Patruliruyu");
        Vector3 direction = _mover.GetDirectionToTarget(_currentTarget);
        if (direction.magnitude <= _minDistanceToTarget)
            SwitchTarget();

        _mover.Move(_currentTarget, Enemy.ForwardDirection);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPositions.Dequeue();
        _targetsPositions.Enqueue(_currentTarget);
    }
}
