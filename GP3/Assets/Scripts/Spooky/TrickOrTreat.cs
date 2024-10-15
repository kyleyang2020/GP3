using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrickOrTreat : MonoBehaviour
{
    public Animator anim;
    public GameObject Canvas;
    public GameObject Anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        Debug.Log("button");
        Canvas.SetActive(false);
        Anim.SetActive(true);
        if (anim != null)
        {
            anim.SetTrigger("Roll");
        }
    }
}
