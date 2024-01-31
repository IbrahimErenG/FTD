using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 wP;
    bool wPS;

    public float hp;

    public float dmg;

    public float wPR;

    public float tBA;

    bool aA;

    public float sR,aR;
    public bool pIR, pIAR;

    private void Awake() 
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        pIR = Physics.CheckSphere(transform.position, sR, whatIsPlayer);
        pIAR = Physics.CheckSphere(transform.position, aR, whatIsPlayer);

        if (!pIR && !pIAR) idle();
        if (pIR && !pIAR) Chase();
        if (pIR && pIAR) Attack();
    }

    private void SearchWP()
    {
        float randomZ = Random.Range(-wPR,wPR);
        float randomX = Random.Range(-wPR,wPR);

        wP = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(wP, -transform.up, 2f, whatIsGround))
             wPS = true;
    }

    private void idle()
    {
        if (!wPS) SearchWP();

        if (wPS)
            agent.SetDestination(wP);
        
        Vector3 distanceToWalkPoint = transform.position - wP;

        if (distanceToWalkPoint.magnitude < 1f)
            wPS = false;
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!aA)
         {
            aA = true;
            Invoke(nameof(ResetAttack), tBA);
         }
    }
    private void ResetAttack()
    {
        aA = false;
    }

    public void TakeDamage(int Damage)
    {
        hp -= dmg;

        if (hp <= 0) Invoke(nameof(DE), .5f);
    }

    private void DE()
    {
        Destroy(gameObject);
    }

}
