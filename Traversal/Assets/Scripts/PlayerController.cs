using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Concerning the Player Input System, there are 4 ways to do behavior, Send Message, Broadcast Message, etc.
 * Send Message only looks for the method on the specific GameObject that the Player Input is attached too
 * Broadcast can do the same, but also on its children, besides that it's all the same
 */

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump()
    {
        Debug.Log("jump");
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private void OnMove(InputValue inputValue)
    {
        rb.velocity = inputValue.Get<Vector2>() * moveSpeed;
    }
}
