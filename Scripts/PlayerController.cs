using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Panel del contador.
    public Text countText;
    //Panel de victoria/derrota.
    public Text winText;
    //Contador de puntos.
    private int count;
    void Start ()
    {
        //Establece la puntuacion del contador a 0.
        count = 0;
        //le asigna el texto.
        SetCountText ();
        //Deja en blanco el texto de victoria/derrota.
        winText.text = "";
    }

    void FixedUpdate ()
    {}

    void OnTriggerEnter(Collider otro) 
    {
        //Si se choca contra un golpeador te asigna puntos.
        if (otro.gameObject.CompareTag ("Golpeador"))
        {
            count = count + 1;
            SetCountText ();
        }
        //En caso de llegar al final te hace perder.
        if (otro.gameObject.CompareTag("LineaFinal"))
        {
            gameObject.SetActive(false);
            winText.text="Pierdes";
        }
    }

    void SetCountText ()
    {
        //Texto del contador con tu puntuacion.
        countText.text = "Count: " + count.ToString ();
        //En caso de llegar a la puntuacion maxima te sale la victoria.
        if (count >= 1000)
        {
            winText.text = "Has ganado"; 
        }
        
    }
}
