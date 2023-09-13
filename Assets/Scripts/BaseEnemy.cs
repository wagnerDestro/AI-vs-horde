using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public Collider2D target;
    private new Rigidbody2D rigidbody2D;

    private float speed;

    public bool onScreen { get; set; } = false;

    public bool canShoot { get; set; }

    private int directionMultiplier;

    public int life {get; set;} = 10;


    // Start is called before the first frame update
    void Start()
    {
        directionMultiplier = 2;
        speed = Time.deltaTime;
        rigidbody2D = GetComponent<Rigidbody2D>();
        LayerMask playerMask = LayerMask.GetMask("playerCharacter");
        target = Physics2D.OverlapCircle(transform.position, 999, playerMask);
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

        if (life <= 0){
            Destroy(gameObject);
        }
    }

}
