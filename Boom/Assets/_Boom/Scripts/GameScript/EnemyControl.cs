using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Constans;

public class EnemyControl : MonoBehaviour
{
    [Header(" ---------- Compenents ----------- ")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;


    [Header(" ---------- Materials ----------- ")]
    [SerializeField] Material secondMat;

    [Header(" ---------- Values ----------- ")]
    [SerializeField] private bool isDead = false;
    public int id;

    private void Start()
    {
        id = GetInstanceID();
    }

    private void Update()
    {
        if (!isDead)
        {
            _agent.SetDestination(_target.position);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Bullet)
        {
            _collider.enabled = false;
            Destroy(_rigidbody);
            skinnedMeshRenderer.material = secondMat;
            isDead = true;
            EventManager.GamePLayEnemyDead(id);
        }
    }
}
