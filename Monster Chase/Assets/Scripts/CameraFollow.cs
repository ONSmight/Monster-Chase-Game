using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Player;

    [SerializeField]
    private float MaxX, MinX;

    private Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        camPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Player)
            return;
        camPos.x = Player.position.x;
        if (camPos.x < MinX)
            camPos.x = MinX;
        if (camPos.x > MaxX)
            camPos.x = MaxX;
        transform.position = camPos;
    }
}
