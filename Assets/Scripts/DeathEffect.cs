using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private float _deathTimeDestroy;

    public void AddEffect(Transform target)
    {
        ParticleSystem newDeathEffect = Instantiate(_deathEffect, target.position, target.rotation);
        Destroy(newDeathEffect, _deathTimeDestroy);
    }
}
