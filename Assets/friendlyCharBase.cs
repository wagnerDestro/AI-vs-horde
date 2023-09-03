using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character1 : MonoBehaviour
{

    // Update is called once per frame


    public GameObject floor; 
    public GameObject roof;
    public GameObject rightWall;
    public GameObject leftWall;
    private int directionMultiplier;

    public Vector3 target;

    public bool moving = false;
    public bool arrived = false;

    public bool canMove = true;

    public bool collided = false;

    public int direction;
    private float waitTime = 2.0f;
    private float timeCurrentWaiting = 0f;


    private float speed;
    
    
    void Start()
    {
        speed = Time.deltaTime/2f;
        directionMultiplier = 2;
    }

    void Update()
    {
        if (arrived){
            timeCurrentWaiting += Time.deltaTime;
            if (timeCurrentWaiting >= waitTime){
                arrived = false;
                timeCurrentWaiting = 0f;
            }
        }else{
            move();            
        }
    }

    private void move(){
        if (canMove || collided){
           canMove = false;
           collided = false;
           direction = Random.Range(0, 4);
           target = transform.position;
           
           switch(direction){
            case 0:
                target += Vector3.down * directionMultiplier;
            break;

            case 1:
                target += Vector3.up * directionMultiplier;
            break;
            
            case 2:
                target += Vector3.right * directionMultiplier;
            break;
            
            case 3:
                target += Vector3.left * directionMultiplier;
            break;
           }
        }

        switch(direction){
            case 0:
            if (canGoDown()){
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            }
            break;

            case 1:
            if (canGoUp()){
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            }
            break;

            case 2:
            if (canGoRight()){
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            }
            break;

            case 3:
            if (canGoLeft()){
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            }
            break;
        }

        if (Vector3.Distance(transform.position, target) == 0f){
            arrived = true;
            canMove = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("colidiu com o " + col.gameObject.name);
    }

    private bool canGoDown(){
        if (transform.position.y - directionMultiplier > floor.transform.position.y){
            return true;
        }else{
            collided = true;
            return false;
        }

    }

    private bool canGoUp(){
        if(transform.position.y + directionMultiplier < roof.transform.position.y){
            return true;
        }else{
            collided = true;
            return false;
        }
    }

    private bool canGoRight(){
        if(transform.position.x + directionMultiplier < rightWall.transform.position.x){
            return true;
        }else{
            collided = true;
            return false;
        }
    }

    private bool canGoLeft(){
        if(transform.position.x - directionMultiplier > leftWall.transform.position.x){
                    return true;
        }else{
            collided = true;
            return false;
        }
    }

}
