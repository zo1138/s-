
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rigid2D;

    //float JumpForce = 680.0f;
    float WalkFaorce = 80.0f;
    float MaxWalkSpeed = 4.0f;
   // public float jumpPower;
    //float DashMaxWalkSpeed = 4.0f; 대쉬최고속도
    //그라운드체크
   // public Transform groundCheck;
    
  //  public float groundCheckRadius;

   // public LayerMask whatIsGround;
   // private bool grounded;
    Animator animator;
 //public void Jump()
    //{

     //   GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpPower,2);

        //  ani.SetBool("Jump", true);

   // }
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

    }
  

    void FixedUpdate()
    {
       // grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //좌우이동 

       // if (Input.GetKeyDown(KeyCode.C) && grounded)
       // {

        //    Jump();
        //}
        int absolute = 0;
            if (Input.GetKey(KeyCode.RightArrow)) absolute = 2;//케릭터 크기와 동기화시키자!!
            if (Input.GetKey(KeyCode.LeftArrow)) absolute = -2;
            // if (Input.GetKeyDown(KeyCode.RightArrow)) this.animator.SetTrigger("RunTrigger");//좌우 방향키가 running애니매이션 트리거
 // if (Input.GetKeyDown(KeyCode.LeftArrow)) this.animator.SetTrigger("RunTrigger");
            if (absolute != 0)
            {
                transform.localScale = new Vector3(absolute, 2, 2);
            }//케릭터 크기와 동기화기키자!! 
                   if (absolute != 0) this.animator.SetTrigger("RunTrigger");

            
                   if (absolute == 0 ) this.animator.SetTrigger("StandingTrigger");
            
            //if (Input.GetKeyUp(KeyCode.RightArrow)) this.animator.SetTrigger("StandingTrigger");//방향키에서 손 떼면 스텐딩 애니로
            // if (Input.GetKeyUp(KeyCode.LeftArrow)) this.animator.SetTrigger("StandingTrigger");

            //플레이어 속도
            //평상시
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);
           // float speedy = (this.rigid2D.velocity.y);
           // if (speedy > 0 && !grounded) this.animator.SetTrigger("JumpUpTrigger");
            //플레이어 최고속도 제한 - 땅 위에서만 가속
            if (speedx < this.MaxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * absolute * this.WalkFaorce);
            }
            //if (speedx*1.0f>0) this.animator.SetTrigger("RunTrigger");
            // if (speedx*1.0f == 0) this.animator.SetTrigger("StandingTrigger");
            //대쉬에 관한 함수 추가해야됨 (추가했다고 치고)
            //if (speedx < this.DashMaxWalkSpeed)
            //{
            //    this.rigid2D.AddForce(transform.right * absolute * 2 * this.WalkFaorce);
            //}
           

            // C버튼을 눌렀을때-점프기능 독립
            // if (Input.GetKeyDown(KeyCode.C))
            // {
            //     this.rigid2D.AddForce(transform.up * this.JumpForce);//점프한다.
            //  }
            //플레이어 속도에 따라 애니매이션 속도를 바꾼다.
            // this.animator.speed = speedx*100 / 0.1f;
            //움직이는 방향에따라 이미지 반전 
           // if (absolute != 0)
            //{
            //    transform.localScale = new Vector3(absolute, 2, 2);//케릭터 크기와 동기화기키자!!
           // }

        }
    }

