using UnityEngine;

public class ScaredBehaviour :IAgroBehaviour
{
    private Enemy _enemy;

    public ScaredBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Agro()
    {
        Debug.Log("STRASHNO");
        _enemy.Kill();
    }
}
