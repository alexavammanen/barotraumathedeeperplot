using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class helm : MonoBehaviour
{
    public float paino = 8614f;

    private Rigidbody2D body;

    private Syvyys controls;

    private Vector2 moveInput;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Syvyys();
        body = GetComponent<Rigidbody2D>();

    }


    void OnEnable(){
        controls.Enable();

    }
    void OnDisable(){
        controls.Disable();

    }































void FixedUpdate(){

     Move();

}

void Move(){
    moveInput = controls.uhri.spin.ReadValue<Vector2>();
    Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
    body.MovePosition(body.position + movement);
   

}




    // Update is called once per frame
    void Update()
    {
        
    }
}
