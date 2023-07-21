using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BumperController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
	public Collider bola;
    public float multiplier;
    public Color colorOne, colorTwo, colorThree;
    public bool colorOneOn, colorTwoOn, colorThreeOn;

    private new Renderer renderer;
    private Animator animator;
	
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        
        animator = GetComponent<Animator>();
        renderer.material.color = colorOne;
        colorOneOn = true;
    }

	private void OnCollisionEnter(Collision collision)
	{
		// memastikan yang menabrak adalah bola
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            
            animator.SetTrigger("hit");
            ChangeColorBumper();
        }
	}

    private void ChangeColorBumper()
    {
        if (colorOneOn == true)
        {
            colorOneOn = false;
            colorTwoOn = true;
            renderer.material.color = colorTwo;
        }
        else if (colorTwoOn == true)
        {
            colorTwoOn = false;
            colorThreeOn = true;
            renderer.material.color = colorThree;
        }
        else
        {
            colorThreeOn = false;
            colorOneOn = true;
            renderer.material.color = colorOne;
        }
    }
    
}
