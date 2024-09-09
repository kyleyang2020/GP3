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
    [SerializeField] private GameObject pole;
    [SerializeField] private Vector3 growPole;
    private Vector3 ogPoleSize = new Vector3((float)0.5,2,1);
    private int maxGrow = 3;
    private int currentGrow = 0;

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

    private bool IsGrounded()
    {
        return false;
    }

    // jumps then resets the pole size
    private void OnJump()
    {
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        pole.transform.localScale = ogPoleSize;
        currentGrow = 0;
    }

    private void OnMove(InputValue inputValue)
    {
        if(currentGrow > 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = inputValue.Get<Vector2>() * moveSpeed;
        }
    }

    private void OnGrowPole()
    {
        if(currentGrow < maxGrow) 
        {
            pole.transform.localScale += growPole;
            currentGrow++;
        }
        
    }
}
