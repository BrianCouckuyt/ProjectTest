using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public MyCharacterController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    Animation anim;

    bool isAttacking = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        CheckPlayerInputAndActAccordingly();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

    private void CheckPlayerInputAndActAccordingly()
    {
        if (Mathf.Abs(horizontalMove) > 0.01f && !isAttacking)
            anim.Play("Rogue_walk_01");
        if (Mathf.Abs(horizontalMove) == 0f && !isAttacking)
            anim.Play("Rogue_idle_01");
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            StartCoroutine(AttackZeroOne());
        }
        if (Input.GetButtonDown("Fire2") && !isAttacking)
        {
            StartCoroutine(AttackZeroThree());
        }
    }

    IEnumerator AttackZeroOne()
    {
        isAttacking = true;
        anim.Play("Rogue_attack_01");
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }

    IEnumerator AttackZeroThree()
    {
        isAttacking = true;
        anim.Play("Rogue_attack_03");
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
}
