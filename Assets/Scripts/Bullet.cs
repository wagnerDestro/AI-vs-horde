using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 target;

    private BaseFriendlyCharacter baseFriendlyCharacter;



    // Start is called before the first frame update
    void Start()
    {
        baseFriendlyCharacter = transform.parent.parent.GetComponent<BaseFriendlyCharacter>();
        target =  baseFriendlyCharacter.targetToShoot.transform.position - transform.position;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
     {
         if (gameObject != null){
            transform.Translate(target * Time.deltaTime);
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
