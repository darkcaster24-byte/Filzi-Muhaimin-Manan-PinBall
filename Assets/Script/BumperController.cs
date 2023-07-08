using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BumperController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
	public Collider bola;
    public float multiplier;
    public Color color;
    private new Renderer renderer;
    private Animator animator;
	
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        
        animator = GetComponent<Animator>();
        renderer.material.color = color;
    }

	private void OnCollisionEnter(Collision collision)
	{
		// memastikan yang menabrak adalah bola
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            
            animator.SetTrigger("hit");
        }
	}
    
}
