using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int BackDirection = -1;
    public static int ForwardDirection = 1;

    private MainEnemyStates _currentMainState = MainEnemyStates.RestState;
    private IRestBehaviour _restEnemyState;
    private IAgroBehaviour _agroEnemyState;

    private Transform _heroTarget;
    private DeathEffect _deathEffect;

    public void Kill()
    {
        _deathEffect.AddEffect(transform);
        Destroy(this.gameObject);
    }

    public void Initialize(IAgroBehaviour agroBehaviour,IRestBehaviour restBehaviour)
    {
        _agroEnemyState = agroBehaviour;
        _restEnemyState = restBehaviour;
        _deathEffect = GetComponent<DeathEffect>();
    }

    private void Update()
    {
        if (_currentMainState == MainEnemyStates.RestState)
            _restEnemyState.Rest();
        if (_currentMainState == MainEnemyStates.AgroState)
            _agroEnemyState.Agro();
    }

    private void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
        {
            GetHeroTarget(hero.transform);
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

    private void GetHeroTarget(Transform target) =>_heroTarget = target; 
}
