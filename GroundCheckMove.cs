using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckMove : MonoBehaviour {

    private Vector2 velocity;



    private float smoothTimeX;

    private float smoothTimeY;



    public GameObject player;



    //public bool bounds;

   // public Vector3 minCameraPos;

   // public Vector3 maxCameraPos;



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }



    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);



        transform.position = new Vector3(posX, posY-1, transform.position.z);//플레이어 기준 위치조정은 여기서



       // if (bounds)
     //   {

       //     transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),

       //         Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y)


                //,Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z) 카메라가 z축으로도 따라감
       //         );}

        }

    }


