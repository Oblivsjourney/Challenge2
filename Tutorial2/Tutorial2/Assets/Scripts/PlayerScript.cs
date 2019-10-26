using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
	public Text win;
	public Text lives;
	public Text lose;
    private int scoreValue = 0;
	private int livesValue = 3;
	public AudioClip musicClipOne;
    public AudioSource musicSource;
	


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
		livesValue = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue ++;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

		if (collision.collider.tag == "Enemy")
        {
            livesValue --;
            lives.text = "Lives: " + livesValue.ToString ();
            Destroy(collision.collider.gameObject);
        }

        if (scoreValue >= 4)
		{
			win.text = "You Win! Game Created By: Rickey Barnes";
		    musicSource.clip = musicClipOne;
            musicSource.Play();
			Application.Quit();
		}


		if (livesValue <= 0)
		{
		    lose.text = "You Lose!";
			Destroy (GameObject.FindWithTag("Player"));
			Application.Quit();
		}


    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}