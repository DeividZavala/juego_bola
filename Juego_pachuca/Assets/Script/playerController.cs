using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour {
	//creamos referencias
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	//west: .5 , 2, 20.5, x:-10 east x:10
	//north: 20.5 , .5, 2 z:10 south z-10


	void Start(){
		//obtenemos el objeto al que le vamos a aplicar las fuerzas
		rb = GetComponent <Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){

		//primer tramo del juego
		//estamos tomando los valores de movimieto del las teclas, esto ya es un metodo de unity

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//creamos una variable para añadir los vectores en donde añadiremos
		// las fuerzas que se le aplicaran a nuestro objeto 
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	//funcion que se ejecutara al colisionar los objetos

	void OnTriggerEnter (Collider other){
		
		// vemos si el objeto con el que colisiono player tienen el tag de pick up
		//checar tag en unity y seleccionar casilla de its trigger
		//agregar rigidboydy and its kynetik
		if (other.gameObject.CompareTag ("Pick Up")) {
			 //de ser asi lo escondera

			other.gameObject.SetActive(false);
			count += 1;
			SetCountText ();

		};
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) {
			winText.text = "You Win!";
		}
	}

}
