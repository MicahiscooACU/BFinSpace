using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanges : MonoBehaviour
{
	public GameObject GameManagerGO;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
	spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
	{
	animator.SetTrigger("Trigattack");
	}
	else
	{
	animator.SetTrigger("idle");
}

	
    }



}
