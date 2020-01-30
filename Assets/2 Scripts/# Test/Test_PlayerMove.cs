using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        InputController.moveEvent += OnMoveEvent;
    }

    void OnDisable()
    {
        InputController.moveEvent -= OnMoveEvent;
    }

    public int moveSpeed = 50;
    private Point point;
    private bool moved = false;

    // Update is called once per frame
    void Update()
    {
        if (moved)
        {
            this.gameObject.transform.position = new Vector3(
                this.gameObject.transform.position.x + (point.x * moveSpeed * Time.deltaTime),
                this.gameObject.transform.position.y + (point.y * moveSpeed * Time.deltaTime),
                this.gameObject.transform.position.z
                );
            moved = false;
        }
    }

    void OnMoveEvent(object sender, InfoEventArgs<Point> e)
    {
        point = e.info;
        moved = true;
    }
}
