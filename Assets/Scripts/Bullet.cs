using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float directionMultiplier = 10f;

    public Vector3 target;


    private BaseFriendlyCharacter baseFriendlyCharacter;



    // Start is called before the first frame update
    void Start()
    {
        baseFriendlyCharacter = transform.parent.parent.GetComponent<BaseFriendlyCharacter>();
        target = baseFriendlyCharacter.targetToShoot.transform.position;
        speed = 0.01f;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
     {
         if (gameObject != null){
            transform.position = Vector3.MoveTowards(transform.position, target * directionMultiplier, speed);
            Debug.Log("posicao da bala: " + transform.position);
            Debug.Log("posicao do alvo: " + target);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("enemy")){
            BaseEnemy baseEnemy = collision.gameObject.GetComponent<BaseEnemy>();
            baseEnemy.life--;
            Destroy(gameObject);
        }
    } 
}
