using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    private Transform player;
    private float smooth = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.position.x > -1.5 && player.position.x < 22){
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
        
    }

    
}
