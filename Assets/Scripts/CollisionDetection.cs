using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Script start");
    }
    void OnTriggerEnter(Collider col)
    {
        UnityEngine.Debug.Log(this.gameObject.name + " was triggered by " + col.gameObject.name);
    }
    void OnTriggerExit(Collider col)
    {
        UnityEngine.Debug.Log(this.gameObject.name + " has ended trigger.");
    }
    void OnCollisionEnter(Collision col)
    {
        UnityEngine.Debug.Log(this.gameObject.name + " collided with " + col.gameObject.name);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    void OnCollisionExit(Collision col)
    {
        UnityEngine.Debug.Log(this.gameObject.name + " has ended contact.");
    }
    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0, -1 * Time.deltaTime, 0);
    }
}