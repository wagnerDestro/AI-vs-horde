using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character1 : MonoBehaviour
{

    // Update is called once per frame
    private float time = 2f;


    public GameObject floor; 
    public GameObject roof;
    public GameObject rightWall;
    public GameObject leftWall;
    private int directionMultiplier;



    private float speed;
    
    
        // Use this for initialization
    void Start()
    {
        speed = Time.deltaTime/2f;
    }

    void Update()
    {
        if (time <= 0f){
            move();
            time = 2f;
        }

        time -= Time.deltaTime;
    }

    private void move(){
        int direction = Random.Range(0, 4);
        float smoothMovement = 0.5f;
        directionMultiplier = 2;

        direction = 0;
        switch(direction){
            case 0:
            if (canGoDown()){
                while(smoothMovement >= 0f){
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.down * directionMultiplier, speed);
                    smoothMovement -= Time.deltaTime;
                }
            }
            break;

            case 1:
            if (canGoUp()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.up * directionMultiplier, speed);
                }
            }
            break;

            case 2:
            if (canGoRight()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.right * directionMultiplier, speed);
                }
            }
            break;

            case 3:
            if (canGoLeft()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.left * directionMultiplier, speed);
                }
            }
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("colidiu com o " + col.gameObject.name);
    }

    private bool canGoDown(){
        return transform.position.y - directionMultiplier > floor.transform.position.y;
    }

    private bool canGoUp(){
        return transform.position.y + directionMultiplier < roof.transform.position.y;
    }

    private bool canGoRight(){
        return transform.position.x + directionMultiplier < rightWall.transform.position.x;
    }

    private bool canGoLeft(){
        return transform.position.x - directionMultiplier > leftWall.transform.position.x;
    }

}
