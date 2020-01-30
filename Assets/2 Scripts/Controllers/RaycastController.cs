using UnityEngine;
using System;
using System.Collections;

public class RaycastController : MonoBehaviour
{

    bool raycast;
    //public static event EventHandler<InfoEventArgs<int>> raycastTargets;
    public const string raycastRequest = "RaycastController.RequestForRaycast";
    public const string raycastOff = "RaycastController.Off";
    public const string raycastResponse = "RaycastController.Response";

    private void OnEnable()
    {
        this.AddObserver(processRequest, raycastRequest);
        this.AddObserver(processOff, raycastOff);
        InputController.fireEvent += ShootRaycast;
    }

    private void OnDisable()
    {
        this.RemoveObserver(processRequest, raycastRequest);
        this.RemoveObserver(processOff, raycastOff);
        InputController.fireEvent -= ShootRaycast;
    }

    void processRequest(object sender, object args)
    {
        raycast = true;
    }

    void processOff(object sender, object args)
    {
        raycast = false;
    }

    void ShootRaycast(object sender, InfoEventArgs<int> e)
    {
        if (raycast)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                Debug.Log("Hit " + hit.transform.gameObject.name);
                //Tile t = hit.collider.GetComponent<Tile>();
                //if (t)
                //{
                //    // Do something!
                //    if (Game.instance.debug_raycasting) Debug.Log("Tile: " + t.name);  // Check what happens when there is a UI
                //    //InfoEventArgs<RaycastHit2D> info = new InfoEventArgs<RaycastHit2D>(hit);
                //    Info<RaycastHit2D> info = new Info<RaycastHit2D>(hit);
                //    this.PostNotification(raycastResponse, info);
                //}
            }
        }
    }
}
