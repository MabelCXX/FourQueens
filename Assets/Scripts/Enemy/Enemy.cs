using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    public PhysikCheck physikCheck; 


    [Header("Basic Attribute")]
    public float normalSpeed;
    public float chaseSpeed;
    public float currentSpeed;
    public Vector3 faceDir;

    [Header("check")]
    public Vector2 centerOffset;
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attackLayer;

    private BaseState currentState;
    protected BaseState patrolState;
    protected BaseState chaseState;

    [Header("Timer")]
    public float lostTime;
    public float lostTimeCounter;
  


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = normalSpeed;
        physikCheck = GetComponent<PhysikCheck>();
    }

    private void OnEnable()
    {
        patrolState = new BoarPatrolState(); // Ensure these states are properly instantiated
        chaseState = new BoarChaseState();
        currentState = patrolState;
        currentState.OnEnter(this);
    }

    private void Update()
    {
        faceDir = new Vector3(-transform.localScale.x, 0, 0);

        currentState.LogicUpdate();
        TimeCounter(); // Ensure TimeCounter is called here
    }

    private void FixedUpdate()
    {
        Move();

        currentState.PhysicsUpdate();
    }

    public void OnDisabler()
    {
        currentState.OnExit();
    }

    public virtual void Move()
    {
        rb.velocity = new Vector2(currentSpeed * faceDir.x * Time.deltaTime, rb.velocity.y);
    }

    public bool FoundPlayer()
    {
        return Physics2D.BoxCast(transform.position + (Vector3)centerOffset, checkSize, 0, faceDir, checkDistance, attackLayer);
    }

    public void SwitchState(NPCState state)
    {
        var newState = state switch
        {
            NPCState.Patrol => patrolState,
            NPCState.Chase => chaseState,
            _ => null

        };

        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)centerOffset+ new Vector3(checkDistance * -transform.localScale.x , 0), 0.2f);
    }

    public void TimeCounter()
    {
        if (!FoundPlayer() && lostTimeCounter > 0)
        {
            lostTimeCounter -= Time.deltaTime;
        }
        else if (FoundPlayer())
        {
            lostTimeCounter = lostTime; // Reset the counter when player is found
        }

    }

}
