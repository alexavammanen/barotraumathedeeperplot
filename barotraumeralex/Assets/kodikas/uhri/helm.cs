using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class helm : MonoBehaviour
{
    public float paino = 8614f;

    private Rigidbody2D body;

    private Syvyys controls;

    private Vector2 moveInput;

    public Transform luukku;
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

    void Update(){
        pudotus();
        

    }

    private void pudotus()
    {
        if(controls.victim.pudotus.triggered){
            Debug.Log("keventyi");
            GameObject pilotti = allas.Instace.Recall();
            pilotti.transform.position = luukku.position;
            pilotti.transform.position = luukku.position;


        }
    }

    void FixedUpdate(){

     Move();

}

void Move(){
    moveInput = controls.victim.spin.ReadValue<Vector2>();
    Vector2 movement = new Vector2(moveInput.x, moveInput.y) * paino * Time.fixedDeltaTime;
    body.MovePosition(body.position + movement);
   

}




    // Update is called once per frame
    
}
