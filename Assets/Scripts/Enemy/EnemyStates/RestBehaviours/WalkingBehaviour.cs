using UnityEngine;

public class WalkingBehaviour : IRestBehaviour
{
    private float _timer = 0;
    private float _timeToChangeDirection;
    private Vector3 normalazedMoveDirection;
    private Mover _mover;

    private float _rightMoveLimit = 13f;
    private float _leftMoveLimit = - 13f;
    private float _upMoveLimit = 17f;
    private float _downMoveLimit = -10f;

    public WalkingBehaviour(Mover mover, float timeToChangeDirection)
    {
        _mover = mover;
        _timeToChangeDirection = timeToChangeDirection;
       
    }

    public void Rest()
    {
        Debug.Log("Idu");
        if (_mover.transform.position.x >= _rightMoveLimit || _mover.transform.position.x <= _leftMoveLimit || _mover.transform.position.z >= _upMoveLimit || _mover.transform.position.z <= _downMoveLimit)
        {
            ChangeMoveSide();
            _timer = Time.deltaTime;
        }

        if (_timer == 0)
        {
            ChangeMoveSide();
        }

        if (_timer < _timeToChangeDirection)
        {
            _timer += Time.deltaTime;
            _mover.ProcessMoveToTarget(normalazedMoveDirection);
        }

        if (_timer >= _timeToChangeDirection)
            _timer = 0;

    }
    private void ChangeMoveSide()
    {
        int xDirection = Random.Range(-1, 2);
        int zDirection = Random.Range(-1, 2);
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        normalazedMoveDirection = direction.normalized;
    }
}
