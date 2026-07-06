using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private Mover _mover;
    private Vector3 _input;

    private void Update()
    {
        _input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
        if (_input!= Vector3.zero)
            _mover.Move(_input,transform);
    }
}
