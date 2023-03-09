using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isLeft;
    private Player player;

    private float movement;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isLeft){
            movement -= (Time.deltaTime * 1.4f);

            if(movement < -1f){
                movement = -1f;
            }
            player.movement = movement;
        }
    }

//Called when a UI element is clicked (work with touch)
    public void OnPointerDown(PointerEventData eventData)
    {
        isLeft = true;
    }

//Called when a UI element is dropped (work with touch)
    public void OnPointerUp(PointerEventData eventData)
    {
        isLeft = false;
        movement = 0f;
        player.movement = movement;
    }
}
