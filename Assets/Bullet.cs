using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime = 5f;
    public float speed;
    public float directionMultiplier = 2f;

    public Vector3 target;

    private BaseFriendlyCharacter baseFriendlyCharacter;


    // Start is called before the first frame update
    void Start()
    {
        baseFriendlyCharacter = transform.parent.parent.GetComponent<BaseFriendlyCharacter>();
        target = baseFriendlyCharacter.targetToShoot;
        speed = Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
     {
         if (gameObject != null){
            transform.position = Vector3.MoveTowards(transform.position, target * directionMultiplier, speed*2);
        }
    }
}
