using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    float maxSpeed = 10f;
    [SerializeField]
    float acceleration = 10f;
    [SerializeField]
    float horizontalAcceleration = 10f;
    
    [SerializeField]
    float linearDrag = 0.5f;

    [SerializeField]
    List<Sprite> sprites;
    
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    void Start()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.trailRenderer = this.GetComponent<TrailRenderer>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector2 speed = new Vector2(horizontalInput * horizontalAcceleration, acceleration );
        // this.horizontalAcceleration *= 1.00f; 
        // this.acceleration *= 1.001f;

        rigidbody2D.AddForce(speed);

        if( Input.GetAxis("Vertical") < 0){
            rigidbody2D.drag = this.linearDrag + Mathf.Abs(Input.GetAxis("Vertical"));
        } 



        // this.rigidbody2D.AddForce(new Vector2(0, 1 * speed));
        
        // if (Input.GetAxisRaw("Horizontal") > 0){
        //     this.rigidbody2D.AddForce(new Vector2( 1 * speed, 0));
        // }else if (Input.GetAxisRaw("Horizontal") < 0){
        //     this.rigidbody2D.AddForce(new Vector2( -1 * speed, 0));
        // }

    }

    void Update() {
            if(this.rigidbody2D.velocity.x < -0.5f){
                if (this.rigidbody2D.velocity.x < -2.5f){
                    if (this.rigidbody2D.velocity.x < -5f){
                        this.spriteRenderer.sprite = this.sprites[3];
                        return;
                    }
                    this.spriteRenderer.sprite = this.sprites[2];
                    trailRenderer.emitting = true;
                    return;
                }
                this.spriteRenderer.sprite = this.sprites[1];
            }else if(this.rigidbody2D.velocity.x > 0.5f){
                if (this.rigidbody2D.velocity.x > 2.5f){
                    if (this.rigidbody2D.velocity.x > 5f){
                        this.spriteRenderer.sprite = this.sprites[6];
                        return;
                    }
                    this.spriteRenderer.sprite = this.sprites[5];
                    return;
                }
                this.spriteRenderer.sprite = this.sprites[4];
                trailRenderer.emitting = true;
                
            }else {
                this.spriteRenderer.sprite = this.sprites[0];
                trailRenderer.emitting = false;
            }
    }
}
