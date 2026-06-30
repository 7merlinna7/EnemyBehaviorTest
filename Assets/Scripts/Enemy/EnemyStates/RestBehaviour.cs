using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestBehaviour : MonoBehaviour
{
    public void Rest(RestEnemyStates currentRestEnemyState)
    {
        switch (currentRestEnemyState)
        {
            case RestEnemyStates.Stay:
                Debug.Log("Ya vstal");
                break;

            case RestEnemyStates.Walk:
                Walking();
                break;

            case RestEnemyStates.Patrolling:
                Patrolling();
                break;
        }
    }

    private void Walking()
    {
        Debug.Log("Idu");
    }

    private void Patrolling()
    {
        Debug.Log("Patruliruyu");
    }
}
