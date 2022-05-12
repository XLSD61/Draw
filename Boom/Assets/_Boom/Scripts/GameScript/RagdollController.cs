using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class RagdollController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] EnemyControl enemyControl;
    [SerializeField] int id;

    private void Start()
    {
        id = enemyControl.id;

        RB(false);
        Col(false);
        Anim(true);
    }

    private void OnEnable()
    {
        EventManager.GameEnemyDead += EnemyDead;
    }
    private void OnDisable()
    {
        EventManager.GameEnemyDead -= EnemyDead;
    }
    void RB(bool value)
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childirenRB in rb)
        {
            childirenRB.isKinematic = value;
        }
    }

    void Col(bool value)
    {
        Collider[] col = GetComponentsInChildren<Collider>();
        foreach (Collider childirenCol in col)
        {
            childirenCol.enabled = value;
        }
    }

    void Anim(bool value)
    {
        anim.enabled = value;
    }

   public void EnemyDead(int ID)
    {
        if (ID == id)
        {
            Anim(false);
            RB(false);
            Col(true);
        }
      
    }
}
