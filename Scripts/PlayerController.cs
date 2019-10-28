using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Text countText;
    public Text winText;
    private int count;
    void Start ()
    {
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {}

    void OnTriggerEnter(Collider otro) 
    {
        if (otro.gameObject.CompareTag ("Golpeador"))
        {
            count = count + 1;
            SetCountText ();
        }
        if (otro.gameObject.CompareTag("LineaFinal"))
        {
            gameObject.SetActive(false);
            winText.text="Pierdes";
        }
    }

    void SetCountText ()
    {
        
        countText.text = "Count: " + count.ToString ();
        if (count >= 1000)
        {
            winText.text = "Has ganado"; 
        }
        
    }
}