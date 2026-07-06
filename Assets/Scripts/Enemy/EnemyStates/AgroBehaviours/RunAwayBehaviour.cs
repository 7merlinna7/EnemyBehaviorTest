using UnityEngine;

public class RunAwayBehaviour : IAgroBehaviour
{
    private Mover _mover;
    private Transform _hero;

    public RunAwayBehaviour(Mover mover, Transform hero)
    {
        _mover = mover;
        _hero = hero;
    }

    public void Agro()
    {
        _mover.Move(_hero.position,Enemy.BackDirection);
    }
}
