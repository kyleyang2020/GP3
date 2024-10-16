using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrickOrTreat : MonoBehaviour
{
    private Vector3 targetPos;
    public DropBehavior DropBehavior;
    public Animator anim;
    public GameObject Canvas;
    public GameObject Anim;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check1()
    {
        Debug.Log("button");
        Canvas.SetActive(false);
        Anim.SetActive(true);
        if (anim != null)
        {
            anim.SetTrigger("Roll");
            DropBehavior.InstantiateDrop(targetPos, true);
            StartCoroutine(WaitCoroutine());
        }
        /*
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Hand Idle"))
        {
            Canvas.SetActive(true);
            Anim.SetActive(false);
        }
        */
    }

    public void Check10()
    {
        Debug.Log("button");
        Canvas.SetActive(false);
        Anim.SetActive(true);
        if (anim != null)
        {
            anim.SetTrigger("Roll");
            DropBehavior.InstantiateDrop(targetPos, false);
            StartCoroutine(WaitCoroutine());
        }
        /*
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hand Idle"))
        {
            Canvas.SetActive(true);
            Anim.SetActive(false);
        }
        */
    }

    IEnumerator WaitCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        // turn on canvas 
        Canvas.SetActive(true);
        Anim.SetActive(false);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
