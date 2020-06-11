using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// automatically add raycast manager component if not present
[RequireComponent(typeof(ARRaycastManager))] 

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    // getter and setter for game object want to make
    public GameObject PlacePrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

    private ARRaycastManager arRaycastMgr;
    private ARPlaneManager arPlaneMgr;

    void Awake()
    {
        arRaycastMgr = GetComponent<ARRaycastManager>();
        arPlaneMgr = GetComponent<ARPlaneManager>();
    }

    // if touched screen, check to see if collide with anything
    // if touch and collision return true, also return position of touch
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        // if touch occured
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        // if touch hits already detected plane doing raycast
        if (arRaycastMgr.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if (arPlaneMgr.enabled)
            {
                // new object and position
                hitPose.position.y += 0.05f;
                Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
            
        }
        
    }

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}
