using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private RestEnemyStates _currentRestEnemyState;
    [SerializeField] private AgroEnemyStates _currentAgroEnemyState;

    private MainEnemyStates _currentMainState = MainEnemyStates.RestState;

    private AgroBehaviour _agroBehaviour;
    private RestBehaviour _restBehaviour;
    private Transform _currentTarget;

    private void Awake()
    {
        _agroBehaviour = GetComponent<AgroBehaviour>();
        _restBehaviour = GetComponent<RestBehaviour>();
    }

    private void Update()
    {
        if (_currentMainState == MainEnemyStates.RestState)
            _restBehaviour.Rest(_currentRestEnemyState);
        if (_currentMainState == MainEnemyStates.AgroState)
            _agroBehaviour.Agro(_currentTarget,_currentAgroEnemyState);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
        {
            GetTarget(hero.transform);
            _currentMainState = MainEnemyStates.AgroState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
        {
            _currentMainState = MainEnemyStates.RestState;
        }
    }

    private void GetTarget(Transform target) =>_currentTarget = target; 
}
