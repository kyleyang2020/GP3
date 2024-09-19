using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

/*
 * Concerning the Player Input System, there are 4 ways to do behavior, Send Message, Broadcast Message, etc.
 * Send Message only looks for the method on the specific GameObject that the Player Input is attached too
 * Broadcast can do the same, but also on its children, besides that it's all the same
 */

public class PlayerController2D : MonoBehaviour
{
    [Header("References")]
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public PlayerControls playerControls;

    [Header("Player Stats")]
    [SerializeField] private float moveSpeed;

    void Start()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private bool IsGrounded()
    {
        return false;
    }

    // ------------------------------Unity Input System Functions------------------------------ //
    private void OnMove(InputValue inputValue)
    {
        rb.velocity = inputValue.Get<Vector2>() * moveSpeed;
    }

    private void OnJump()
    {
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    // --------------------------------Built-In Unity Functions-------------------------------- //
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}











// wukong game
/*
    [SerializeField] private GameObject pole;
    [SerializeField] private Vector3 growPole;
    private Vector3 ogPoleSize = new Vector3((float)0.5, 2, 1);
    private int maxGrow = 6;
    private int currentGrow = 0;

    // when e is pressed, grow pole
    private void OnGrowPole()
    {
        if(currentGrow < maxGrow) 
        {
            pole.transform.localScale += growPole;
            currentGrow++;
        }
    }

    // jumps then resets the pole size
    private void OnJump()
    {
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        pole.transform.localScale = ogPoleSize;
        currentGrow = 0;
        //currentjump = 1;
    }

*/

// climbing 
/*
 * 
 *     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentCliff != null)
        {
            climbing = true;
        }
        if (climbing && currentCliff == null)
        {
            climbing = false;
        }
    }

 *  public void ClimbMove()
    {
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -moveSpeed;
        }
        else
        {
            vel.x = 0;
        }
        rb.velocity = vel;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetClimbing(false);
        }
    }

    public void ClimbMove()
    {
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -moveSpeed;
        }
        else
        {
            vel.x = 0;
        }
        rb.velocity = vel;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetClimbing(false);
        }
    }

//private int jump = 1;
    //private int currentjump = 0;
    public BoxCollider2D currentCliff;
    public bool climbing;

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cliff")
        {
            currentCliff = collision.GetComponent<BoxCollider2D>();
        }
    }
*/

