﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : BaseCharacterController
{

    //=== 외부 파라미터(Inspector 표시)============================
    public float initHpMax = 20.0f;
    [Range(0.1f, 100.0f)] public float initSpeed = 12.0f;
    Rigidbody2D rigidbody2D;// 시험중 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //=== 내부 파라미터 ===========================================
    int jumpCount = 0;
    bool breakEnabled = true;
    float graoundFriction = 0.0f;
    private float groundFriction;// 시험중@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //=== 코드 (MonoBehaviour 기본 기능 구현) =====================
    protected override void Awake()
    {
        base.Awake();
        //=== 파라미터 초기화
        speed = initSpeed;
        SetHP(initHpMax, initHpMax);
    }
    protected override void FixedUpdateCharacter()
    {
        // 착지검사
        if (jumped)
        {
            if ((grounded && !groundedPrev) || (grounded && Time.fixedTime > jumpStartTime + 1.0f))
            {
                animator.SetTrigger("Idle");
                jumped = false;
                jumpCount = 0;
            }
        }
        if (!jumped)
        {
            jumpCount = 0;
        }
        // 캐릭터 방향
        transform.localScale = new Vector3(
            basScaleX * dir, transform.localScale.y, transform.localScale.z);
        // 점프 도중에 가로 이동 감속
        if (jumped && !grounded)
        {
            if (breakEnabled)
            {
                breakEnabled = false;
                speedVx *= 0.9f;
            }
        }
        // 이동 정지(감속) 처리
        if (breakEnabled)
        {
            speedVx *= groundFriction;
        }
        // 카메라
        Camera.main.transform.position = transform.position - Vector3.forward;
    }
    // === 코드 (기본액션)=====================================================
    public override void ActionMove(float n)
    {
        if (!activeSts) { return; }
    
    // 초기화
    float dirOld = dir;
    breakEnabled = false;
    // 애니매이션 지정
    float moveSpeed = Mathf.Clamp(Mathf.Abs(n), -1.0f, +1.0f);
    animator.SetFloat("MovSpeed", "moveSpeed");
        // animator.speed = 1.0f + moveSpeed;

    // 이동검사
    if(n !=0.0f) {
        //이동
        dir = Mathf.Sign(n);
        moveSpeed = (moveSpeed< 0.5f) ? (moveSpeed* (1.0f / 0.5f)) : 1.0f;
        speedVx = initSpeed* moveSpeed * dir;
    } else{
//이동정지
breakEnabled = true;
    }
    }
    public void ActionJump()
{
    switch (jumpCount)
    {
        case 0:
            if(grounded)
            {
                animator.SetTrigger("Jump");
                rigidbody2D.velocity = Vector2.up * 30.0f;
                jumpStartTime = Time.fixedTime;
                jumped = true;
                jumpCount++;
            }
            break;
        case 1:
            if(!grounded)
            {
                animator.Play("Player_Jump", 0, 0.0f);
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 20.0f);
                jumped = true;
                jumpCount++;
            }
            break;
    }
} 
        }
  


	