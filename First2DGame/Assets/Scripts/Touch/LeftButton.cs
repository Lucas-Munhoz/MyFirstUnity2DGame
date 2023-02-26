using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    private bool isLeft;
    private Player player;

    public float movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isLeft == true){
            movement -= Time.deltaTime * 2f;
            if(movement < -1f){
                movement = -1f;
            }
            player.movement = movement;
        }
    }

//Called when UI elements are clicked (work with touch too).
    public void OnPointerDown(PointerEventData eventData){
        isLeft = true;
    }

//Called when UI elements are dropped (work with touch too).
    public void OnPointerUp(PointerEventData eventData){
        isLeft = false;
        movement = 0f;
        player.movement = movement;
    }
}