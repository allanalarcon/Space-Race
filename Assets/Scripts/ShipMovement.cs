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
    public GameObject misil;
    private float angle = 3f;
    private int dir = 0;
    private Animator animState;
    Player player;
    public Slider weapon;
    private bool misilAvailable = false;
    private float timeMisilLoad = 1f;
    private Image misilIndicator;
    private AudioSource impactSound;

    void Start () {
		rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        misilIndicator = GameObject.Find("misilIndicator").GetComponent<Image>();
        impactSound = transform.GetChild(2).GetComponent<AudioSource>();
        animState = transform.GetChild(2).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool bup = Input.GetKey(KeyCode.UpArrow);
        bool bdown = Input.GetKey(KeyCode.DownArrow);
        bool dispara = Input.GetKeyDown(KeyCode.Space) && InfoPlayer.getMode()!=3 && weapon.value < 0.95f;
        bool disparoEspecial;
        Mov = new Vector2(Input.GetAxis("Horizontal"),
                          Input.GetAxis("Vertical"));
        timeMisilLoad += Time.deltaTime;
        misilAvailable = misilAvailable || (int)timeMisilLoad % 15 == 0;
        
        if (misilAvailable && InfoPlayer.getMode()!=3) {
            misilIndicator.color = new Color(3, 252, 244);
        } else {
            misilIndicator.color = new Color(6, 24, 36);
        }

        disparoEspecial = Input.GetKeyDown(KeyCode.Z) && misilAvailable;
        anim.SetBool("disparando", dispara);
        anim.SetBool("disparoEspecial", disparoEspecial);
        if (disparoEspecial) {
            GameObject bazuca = transform.GetChild(5).gameObject;
            Instantiate(misil, bazuca.transform.position, misil.transform.rotation,bazuca.transform);
            bazuca.GetComponent<AudioSource>().Play();
            timeMisilLoad = 1f;
            misilAvailable = false;
        }

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

    private void OnCollisionEnter2D(Collision2D collision) {        
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

            } else if (player.getShieldPower() == 0 && player.getLifes() < 3) {
                animState.Play("impacto");
                impactSound.Play();                
            }


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