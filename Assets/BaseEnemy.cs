using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public Collider2D target;
    private new Rigidbody2D rigidbody2D;

    private float speed;

    private bool canShoot;

    public global::System.Boolean CanShoot1 { get => canShoot; set => canShoot = value; }

    private int directionMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        directionMultiplier = 2;
        speed = Time.deltaTime;
        rigidbody2D = GetComponent<Rigidbody2D>();
        LayerMask playerMask = LayerMask.GetMask("playerCharacter");
        Collider2D[] playerObjects = Physics2D.OverlapCircleAll(transform.position, 999, playerMask);
        target = playerObjects[0];
        foreach (Collider2D playerObject in playerObjects){
            if ((rigidbody2D.transform.position - playerObject.transform.position).magnitude < (rigidbody2D.transform.position - target.transform.position).magnitude){
                target = playerObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20){
            canShoot = false;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position * directionMultiplier, speed);
        }else{
            canShoot = true;
        }
    }
}
