using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character1 : MonoBehaviour
{

    // Update is called once per frame
    public float accelerationTime = 2f;
    public float maxSpeed = 2f;
    private Vector2 movement;
    private float time = 2f;

    public float speed = 1;

    public GameObject floor; 
    public GameObject roof;
    public GameObject rightWall;
    public GameObject leftWall;
    
    
        // Use this for initialization
    void Start()
    {

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
        Debug.Log(direction);
        float smoothMovement = 1f;

        switch(direction){
            case 0:
            if (canGoDown()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position += new Vector3(this.transform.position.x, this.transform.position.y - Time.deltaTime, 0f);
                }  
            }
            break;

            case 1:
            if (canGoUp()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position += new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime, 0f);
                }
            }
            break;

            case 2:
            if (canGoRight()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position += new Vector3(this.transform.position.x - Time.deltaTime, this.transform.position.y, 0f);
                }
            }
            break;

            case 3:
            if (canGoLeft()){
                while(smoothMovement >= 0f){
                    smoothMovement -= Time.deltaTime;
                    transform.position += new Vector3(this.transform.position.x + Time.deltaTime, this.transform.position.y, 0f);
                }
            }
            break;
        }
    }
    

    private bool canGoDown(){
        return this.transform.position.y - 1 > floor.transform.position.y;
    }

    private bool canGoUp(){
        return this.transform.position.y + 1 < roof.transform.position.y;
    }

    private bool canGoRight(){
        return this.transform.position.x + 1 > rightWall.transform.position.x;
    }

    private bool canGoLeft(){
        return this.transform.position.x - 1 > leftWall.transform.position.x;
    }

}
