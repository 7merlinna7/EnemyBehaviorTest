using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUpBehaviour : IAgroBehaviour
{
    private Mover _mover;
    private Transform _hero;

    public CatchUpBehaviour(Mover mover, Transform hero)
    {
        _mover = mover;
        _hero = hero;
    }

    public void Agro() => _mover.Move(_hero.transform.position, Enemy.ForwardDirection);
}
