using UnityEngine;

public class AgroBehaviour : MonoBehaviour
{
    public void Agro(AgroEnemyStates currentAgroEnemyState)
    {
        Debug.Log("Ya zloy");
        switch (currentAgroEnemyState)
        {
            case AgroEnemyStates.RunAway:
                RunAway();
                break;

            case AgroEnemyStates.CatchUp:
                CatchUp();
                break;

            case AgroEnemyStates.Scared:
                Scared();
                break;
        }
    }

    private void RunAway()
    {
        Debug.Log("Ubegaem");
    }

    private void CatchUp()
    {
        Debug.Log("Dogonu");
    }

    private void Scared()
    {
        Debug.Log("Strashno");
    }
}
