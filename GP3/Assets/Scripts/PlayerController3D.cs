using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Concerning the Player Input System, there are 4 ways to do behavior, Send Message, Broadcast Message, etc.
 * Send Message only looks for the method on the specific GameObject that the Player Input is attached too
 * Broadcast can do the same, but also on its children, besides that it's all the same
 */

public class PlayerController3D: MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    public List<Collider> ragdollParts = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        SetRagdollParts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // jumps then resets the pole size
    private void OnJump()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void OnMove(InputValue inputValue)
    {
        rb.velocity = inputValue.Get<Vector3>() * moveSpeed;
    }

    private void SetRagdollParts()
    {
        // get all colliders under this gameobject
        Collider[] allColliders = this.gameObject.GetComponentsInChildren<Collider>();

        // make each collider a trigger so it's no longer a physical object, will go through objects
        // will know when other objects touch it
        foreach (Collider collider in allColliders)
        {
            // only gets the ragdoll colliders and not the movement
            if(collider.gameObject != this.gameObject)
            {
                collider.isTrigger = true;
                ragdollParts.Add(collider);
            }
        }
    }

    private void TurnOnRagdoll()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // get all the ragdoll parts, and turn them on
        foreach(Collider c in ragdollParts)
        {
            c.isTrigger = false;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
    }
}
