using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefub;
    [SerializeField] Transform _hero;
    [SerializeField] private RestEnemyStates _restEnemyState;
    [SerializeField] private AgroEnemyStates _agroEnemyState;
    [SerializeField] private float _timeToChangeWalkingDirection;
    [SerializeField] private List<Transform> _patrolPoints;

    private IRestBehaviour _currentRestBehaviour;
    private IAgroBehaviour _currentAgroBehaviour;

    private void Awake()
    {
        Enemy enemy = Instantiate(_enemyPrefub, transform.position, transform.rotation);
        SelectRestState(_restEnemyState,enemy);
        SelectAgroState(_agroEnemyState,enemy);
        enemy.Initialize(_currentAgroBehaviour,_currentRestBehaviour);

    }

    private void SelectAgroState(AgroEnemyStates currentAgroEnemyState,Enemy enemy)
    {
        switch (currentAgroEnemyState)
        {
            case AgroEnemyStates.RunAway:
                _currentAgroBehaviour = new RunAwayBehaviour(enemy.GetComponent<Mover>(),_hero);
                break;

            case AgroEnemyStates.CatchUp:
                _currentAgroBehaviour = new CatchUpBehaviour(enemy.GetComponent<Mover>(), _hero);
                break;

            case AgroEnemyStates.Scared:
                _currentAgroBehaviour = new ScaredBehaviour(enemy);
                break;
        }
    }

    private void SelectRestState(RestEnemyStates currentRestEnemyState, Enemy enemy)
    {
        switch (currentRestEnemyState)
        {
            case RestEnemyStates.Stay:
                _currentRestBehaviour = new StayBehaviour();
                break;

            case RestEnemyStates.Walk:
                _currentRestBehaviour = new WalkingBehaviour(enemy.GetComponent<Mover>(),_timeToChangeWalkingDirection);
                break;

            case RestEnemyStates.Patrolling:
                Queue<Vector3> patrolPositions = new Queue<Vector3>();
                foreach (Transform target in _patrolPoints)
                    patrolPositions.Enqueue(target.position);
                Vector3 firstTargetPosition = _patrolPoints[_patrolPoints.Count - 1].position;

                _currentRestBehaviour = new PatrolBehaviour(enemy.GetComponent<Mover>(),patrolPositions,firstTargetPosition);
                break;
        }
    }
}
