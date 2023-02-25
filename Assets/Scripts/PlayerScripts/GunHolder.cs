using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private Transform player;

    //camera and mouse
    private Camera mainCam;
    private Vector3 mousePos;
    static public float mousePosMinDistance;
    static public float mousePosDistanceFromPlayer;

    void Start()
    {
        mousePosMinDistance = 10.05241f;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        mousePosDistanceFromPlayer = Vector3.Distance(player.position, mousePos);
    }

    void Update()
    {
        RotationToCursor();
    }

    private void RotationToCursor()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
