using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionZone : MonoBehaviour
{
    public bool canAttack = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = true;

            Debug.Log($"감지 대상 : {other.name}");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            Debug.Log($"감지 대상이 벗어남 : {other.name}");
        }
    }
}
