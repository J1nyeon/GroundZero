using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    [Header("State")]
    public BaseState currentState;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;
    public EnemyPatrolState patrolState; // 아직 만들지않음.

    public NavMeshAgent agent;

    public Transform targetPlayer;

    [Header("Check Distance")]
    public float chaseRange = 10f;
    public float attackRange = 5f;
    public float longRange = 15f;
    public float detectRange = 12f;

    [Header("Patrol")]
    public Transform[] patrolWaypoint;
    public int index;

    [Header("Attack")]
    public bool isBlocked;
    public bool attackCheck = false;
    public Transform firePoint;
    public BulletPoolingTest pool;
    public LayerMask layer;
    

    public float timer = 0;
    public float turnSpeed = 5f;
    public float targetDistance;

    [Header("Animation")]
    public Animator animator;
    public bool isAttack = false;
    public bool isIdle = true;
    public bool isChase = false;

    public void Start()
    {
        idleState = new EnemyIdleState(this);
        chaseState = new EnemyChaseState(this);
        attackState = new EnemyAttackState(this);
        patrolState = new EnemyPatrolState(this);
        currentState = idleState;
        ChangeState(currentState);
    }
    public void ChangeState(BaseState nextState)
    {
        if (nextState == null) return;
        
        if (currentState != null)
        {
            currentState.Exit();
        }
        Debug.Log($"[State Change] {currentState?.GetType().Name} -> {nextState.GetType().Name}");
        currentState = nextState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState == null) return;
        TargetDistance();
        currentState.Do();
        Debug.Log($"현재 상태 : {currentState}");
    }

    public void Chase()
    {
        agent.SetDestination(targetPlayer.position);
    }
    public void Detect() // 감지거리에서 이 함수를 먼저 호출함
    {
        // 천천히 플레이어 방향을 바라 볼 수 있게
        Vector3 dir = (targetPlayer.position - transform.position).normalized;
        dir.y = 0f;
        if (dir == null) return;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        float smoothMove = Time.deltaTime * turnSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothMove);
    }
    public void Attack()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0f;
            BulletSpawn();
        }
    }
    public void Patrol()
    {
        index = (index + 1) % patrolWaypoint.Length;
        agent.SetDestination(patrolWaypoint[index].position);

    }
   

    public void BulletSpawn()
    {
        GameObject bullet = pool.GetBullet();
        if (bullet == null) return;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
    }

    public void TargetDistance()
    {
        targetDistance = Vector3.Distance(transform.position,targetPlayer.position);
    }

    public void TargetRaycast()
    {
        Vector3 dir = (targetPlayer.transform.position - transform.position).normalized;

        Debug.DrawRay(transform.position, dir * 100f, Color.magenta);

        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, 100f, layer) == true)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                isBlocked = false;
            }
            else
            {
                isBlocked = true;
            }
            
        }
    }
    public void StateAnimation(bool idle, bool chase, bool attack)
    {
        isIdle = idle;
        isChase = chase;
        isAttack = attack;

        animator.SetBool("isIdle", idle);
        animator.SetBool("isChase", chase);
        animator.SetBool("isAttack", attack);

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f);
        //Gizmos.DrawSphere(transform.position, chaseRange);
        //Gizmos.DrawLine(transform.position, targetPlayer.position);
    }

}
