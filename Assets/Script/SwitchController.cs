using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // enum untuk mengatur state
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    // menyimpan variabel bola sebagai referensi untuk pengecekan
	public Collider bola;
    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;
    // menyimpan state switch apakah nyala atau mati
    private bool isOn;
    // komponen renderer pada object yang akan diubah
    private new Renderer renderer;
    // menggantikan isOn
    private SwitchState state;  
	
    // Start is called before the first frame update
    void Start()
    {
        // ambil renderernya
        renderer = GetComponent<Renderer>();

        // set switch nya mati baik di state, maupun materialnya
        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	private void OnTriggerEnter(Collider other)
	{
		// memastikan yang menabrak adalah bola
        if (other == bola)
        {
            Debug.Log("Kena Bola");
            Toggle();
        }
	}

    // fungsi untuk on off
    private void Toggle()
    {
        // dari on --> off
        if (state == SwitchState.On)
        {
            Set(false);
        }
        // dari off --> on atau blink --> on
        else
        {
            Set(true);
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;

            // hentikan proses blink
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private IEnumerator Blink(int times)
    {
        // set statenya menjadi blink dulu sebelum mulai proses
        state = SwitchState.Blink;

        // mulai proses blink tanpa mengubah state lagi
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
            
        // set menjadi off kembali setelah proses blink
        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }
}
