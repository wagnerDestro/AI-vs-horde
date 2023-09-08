using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFriendlyCharacter : MonoBehaviour
{
    
    private int directionMultiplier;

    public Vector3 target;

    public bool arrived = false;

    public bool canMove = true;

    public bool collided = false;

    public int direction;
    private float waitTime;
    private float timeCurrentWaiting = 0f;


    private float speed;

    private new Rigidbody2D rigidbody2D;
    
    
    void Start()
    {
        speed = Time.deltaTime/2f;
        directionMultiplier = 2;
        waitTime = Random.Range(1, 4);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (arrived){
            timeCurrentWaiting += Time.deltaTime;
            if (timeCurrentWaiting >= waitTime){
                arrived = false;
                timeCurrentWaiting = 0f;
                waitTime = Random.Range(1, 4); 
            }
        }else{
            move();            
        }
    }

    private void move(){
        if (canMove || collided){
           canMove = false;
           collided = false;
           target = transform.position;
           direction = Random.Range(0, 4);
            
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

        if(checkIfCanMove(direction)){
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }else{
            collided = true;
        }

        if (Vector3.Distance(transform.position, target) == 0f){
            arrived = true;
            canMove = true;
        }
    }

    private bool checkIfCanMove(int direction){
        LayerMask mask = LayerMask.GetMask("playerLimits");
        LayerMask maskChar = LayerMask.GetMask("playerCharacter");
        Vector3 vector3Direction;

        switch (direction){
            case 0: vector3Direction = Vector3.down;
            break;
            case 1: vector3Direction = Vector3.up;
            break;
            case 2: vector3Direction = Vector3.right;
            break;
            default: vector3Direction = Vector3.left;
            break;
        }

        RaycastHit2D hitLimits = Physics2D.Raycast(transform.position, vector3Direction, 1f, mask);

        if (hitLimits.collider != null){
            return false;
        }


        return true;
    }

}
