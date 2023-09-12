using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject bullet;

    private float waitTime = 1f;

    private bool wait = false;
    
    private float timeCurrentWaiting = 0f;

    public BaseFriendlyCharacter baseFriendlyCharacter;


    // Start is called before the first frame update
    void Start()
    {
        baseFriendlyCharacter = transform.parent.GetComponent<BaseFriendlyCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait && baseFriendlyCharacter.state == baseFriendlyCharacter.SHOOTING){
            Instantiate(bullet, transform.position, Quaternion.identity, transform);
            wait = true;
        }else{
            timeCurrentWaiting += Time.deltaTime;
            if (timeCurrentWaiting >= waitTime){
                wait = false;
                timeCurrentWaiting = 0f;
            }
        }
    }
}
