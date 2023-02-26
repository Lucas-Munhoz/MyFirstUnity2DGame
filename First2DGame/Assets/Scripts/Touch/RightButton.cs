using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isRight;
    private Player player;

    public float movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isRight == true){
            movement += Time.deltaTime * 2f;
            if(movement > 1f){
                movement = 1f;
            }
            player.movement = movement;
        }
    }

//Called when UI elements are clicked (work with touch too).
    public void OnPointerDown(PointerEventData eventData){
        isRight = true;
    }

//Called when UI elements are dropped (work with touch too).
    public void OnPointerUp(PointerEventData eventData){
        isRight = false;
        movement = 0f;
        player.movement = movement;
    }
}
