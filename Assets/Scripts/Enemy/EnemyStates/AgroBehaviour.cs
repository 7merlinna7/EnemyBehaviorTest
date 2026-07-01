using UnityEngine;

public class AgroBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private float _deathTimeDestroy;

    private EnemyMover _mover;
    private const int _backDirection = -1;
    private const int _forwardDirection = 1;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void Agro(Transform hero, AgroEnemyStates currentAgroEnemyState)
    {
        Debug.Log("Ya zloy");
        switch (currentAgroEnemyState)
        {
            case AgroEnemyStates.RunAway:
                RunAway(hero);
                break;

            case AgroEnemyStates.CatchUp:
                CatchUp(hero);
                break;

            case AgroEnemyStates.Scared:
                Scared();
                break;
        }
    }

    private void RunAway(Transform hero) => _mover.Move(hero.transform.position,_backDirection);

    private void CatchUp(Transform hero) =>  _mover.Move(hero.transform.position, _forwardDirection);

    private void Scared()
    {
        Debug.Log("STRASHNO");
        ParticleSystem newDeathEffect = Instantiate(_deathEffect,transform.position,transform.rotation);
        Destroy(this.gameObject);
        Destroy(newDeathEffect,_deathTimeDestroy);
    }
}
