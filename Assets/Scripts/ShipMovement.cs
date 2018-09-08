using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour {
    
	Rigidbody2D rb;
    Animator anim;
    Vector2 Mov;
	public float Velocidad = 8f;
    public Vector2 minLimit = new Vector2(-12,-7);
    public Vector2 maxLimit = new Vector2(12,7);
    private float angle = 3f;
    private int dir = 0;
    private Animator animState;
    Player player;
    public Slider weapon;

    void Start () {
		rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        animState = transform.GetChild(2).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool bup = Input.GetKey(KeyCode.UpArrow);
        bool bdown = Input.GetKey(KeyCode.DownArrow);
        bool dispara = Input.GetKeyDown(KeyCode.Space) && InfoPlayer.getMode()!=3 && weapon.value < 0.95f;
        Mov = new Vector2(Input.GetAxis("Horizontal"),
                          Input.GetAxis("Vertical"));
        anim.SetBool("disparando", dispara);

        if (bup) {
            dir = 1;
        } else if (bdown) {
            dir = -1;
        } else {
            dir = 0;
        }
	}

    void FixedUpdate() {
        Vector2 newPosition = rb.position + Mov * Velocidad * Time.deltaTime;
        rb.MovePosition(fixPosition(newPosition));
        rb.MoveRotation(angle * dir);
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision) {        
        if (collision.collider.CompareTag("Obstaculo")) {
            player.impact();
            anim.SetInteger("lifes", player.getLifes());
            if (player.getLifes() == 1) {
                activarHumo();
                rb.gravityScale = 15f;
            }
            
            if (!player.isAlive()){
                transform.GetChild(1).GetComponent<ParticleSystem>().Stop(); // apaga motor
                desactivarHumo();
                GetComponent<AudioSource>().Play();

                yield return new WaitForSeconds(3f);
                player.loadGameOver();
            } else if (player.getShieldPower() == 0 && player.getLifes() < 3) {
                animState.Play("impacto");
                // Sonido de impacto
            }


        } else if (collision.collider.CompareTag("Shield")) {
            Destroy(collision.collider.gameObject);
            GetComponent<Player>().incrementShieldPower();            
        }
    }

    private Vector2 fixPosition(Vector2 position) {
        Vector2 fixedPosition = position;
        
        fixedPosition.y = (fixedPosition.y > maxLimit.y) ? maxLimit.y : fixedPosition.y;
        fixedPosition.y = (fixedPosition.y < minLimit.y) ? minLimit.y : fixedPosition.y;
        fixedPosition.x = (fixedPosition.x > maxLimit.x) ? maxLimit.x : fixedPosition.x;
        fixedPosition.x = (fixedPosition.x < minLimit.x) ? minLimit.x : fixedPosition.x;

        return fixedPosition;
    }

    private void activarHumo() {
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
        transform.GetChild(4).GetComponent<ParticleSystem>().Play();
    }

    private void desactivarHumo() {
        transform.GetChild(3).GetComponent<ParticleSystem>().Stop();
        transform.GetChild(4).GetComponent<ParticleSystem>().Stop();
    }
}