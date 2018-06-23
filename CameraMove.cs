using UnityEngine;

using System.Collections;



public class CameraMove : MonoBehaviour {



    private Vector2 velocity;



    private float smoothTimeX;

    private float smoothTimeY;



    public GameObject player;



   // public bool bounds;

   // public Vector3 minCameraPos;

  //  public Vector3 maxCameraPos;



 void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

 }



    void FixedUpdate()

    {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);



        transform.position = new Vector3(posX, posY, transform.position.z);



       // if (bounds)

        //{

            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),

             //   Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y)
                

                //,Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z) 카메라가 z축으로도 따라감
//);}

        }

    }



 

//위 스크립트를 Main Camera에 적용하여 카메라가 Tag Player 대상을 따라오게 한다.

//거기에 min, max CameraPos를 줘서 

//bounds가 켜져있을때 현 스크립트의 지정 오브젝트를 min, max 안에서만 움직이게 한다.



//응용하면 카메라 뿐만 아니라 다른 플레이어를 어느정도 범위까지 따라다녀야하는 오브젝트를 만들 수 있을 것이다.





  //float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

  //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
