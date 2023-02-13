using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackPoint : MonoBehaviour
{
    // Cache
    Animator atacAnim;

    // Start is called before the first frame update
    void Start()
    {
        atacAnim = GetComponent<Animator>();
    }

    public void AttackIdle()
    {
        atacAnim.SetTrigger("WeaponIdle");
    }

    public void AttackIsGo()
    {
        atacAnim.SetTrigger("WeaponAttack");
    }
}
