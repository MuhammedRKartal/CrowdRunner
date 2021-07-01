using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Transform plyr;
    private float movementSpeed = 3f;
    private float newSpeed,oldSpeed;
    float xMov;
    float distx,distz;
    private Vector3 relatedDistance,dist;
    public static bool isEnhanced;
    public static bool isJump = false;

    private float ScreenWidth;
    
    void Start()
    {
        plyr = GameObject.FindWithTag("Player").transform;
        relatedDistance = transform.position - plyr.position;
        ScreenWidth = Screen.width;
        oldSpeed = movementSpeed;
        newSpeed = movementSpeed*Speeding.speedX;
    }

    void Update()
    {
        dist = (transform.position-plyr.position);
        distx = Mathf.Abs(dist.x);
        distz = Mathf.Abs(dist.z);  
        if (isEnhanced){
            movementSpeed=newSpeed;
            StartCoroutine(aRout());
        }
        if(distx < 0.25f && distz < 0.25f){
            if(Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);
                if(touch.position.x > ScreenWidth/2){
                    xMov = 1;
                }
                else{
                    xMov = -1;
                }
            }
            else{
                xMov = 0;
            }
            //xMov = Input.GetAxisRaw("Horizontal");
            if(isJump){
                //Vector3 jumpPos = new Vector3(transform.position.x,20f,transform.position.z)*Time.deltaTime;
                //Vector3 oldPos = new Vector3(transform.position.x,0f,transform.position.z);
                
                //Vector3 smoothedPosition = Vector3.Lerp(transform.position, jumpPos, 0.01f);
		        //= smoothedPosition;
                //transform.position += new Vector3(xMov*movementSpeed,0f,movementSpeed)*Time.deltaTime;
                transform.Translate(new Vector3(xMov*movementSpeed,8f,movementSpeed)*Time.deltaTime);
                if(transform.position.y <= -0.223f){
                    isJump = false;
                }
                
            }
            else{
                transform.position += new Vector3(xMov*movementSpeed,0f,movementSpeed)*Time.deltaTime;
            }
            
            
        }
        else{
            transform.position = plyr.position +relatedDistance;
        }
    }

    IEnumerator aRout()
    {
        yield return new WaitForSeconds(Speeding.seconds);
        isEnhanced = false;
        movementSpeed = oldSpeed;
    }

    
}
