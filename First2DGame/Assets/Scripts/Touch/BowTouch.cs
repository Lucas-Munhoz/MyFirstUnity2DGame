using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowTouch : MonoBehaviour, IPointerDownHandler
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        player.touchBow = true;
    }

}