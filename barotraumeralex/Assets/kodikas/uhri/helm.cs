
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class helm : MonoBehaviour,IDamageable
{

    public GameObject ei_vitamiineja;

    public int ilmaa = 6;
    public float paino = 8614f;

    private int ilma;

    private Rigidbody2D body;

    private Syvyys controls;

    private Vector2 moveInput;

    public Transform luukku;

    private Vector2 reanimation_protocol;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new Syvyys();
        body = GetComponent<Rigidbody2D>();

    }
    void Start(){
        GameManager.Instance.getPlayer = this;
        ilma = ilmaa;

    }


    void OnEnable(){
        controls.Enable();

    }
    void OnDisable(){
        controls.Disable();

    }

    void Update(){

    
        pudotus();
        Tarahdys();

    }
    private void Tarahdys(){
        reanimation_protocol = controls.victim.reanimation_protocol.ReadValue<Vector2>();
        if(reanimation_protocol.sqrMagnitude > 0.1){
            Vector2 tarahdyssiainti = Vector2.zero;
            if(hirtto()){
                Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                mouseposition.z = 0;
                tarahdyssiainti = mouseposition - luukku.position;
            }
            else{
                tarahdyssiainti = reanimation_protocol;


            }
            float angle = Mathf.Atan2 (tarahdyssiainti.x, -tarahdyssiainti.y) * Mathf.Rad2Deg;
            luukku.rotation = Quaternion.Euler(0,0,angle);
        }
        //Debug.Log(reanimation_protocol);
    }
    private bool hirtto(){
        if(Mouse.current.delta.ReadValue().sqrMagnitude > 0.1){
            return true;
        }

        return false;
    }
    

    private void pudotus()
    {
        if(controls.victim.pudotus.triggered){
            Debug.Log("keventyi");
            GameObject pilotti = allas.Instace.Recall();

            if(pilotti == null){
                return;
            }

            pilotti.transform.position = luukku.position;
            pilotti.transform.rotation = luukku.rotation;


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

public void Ilmaista(int vetta)
{

    ilma -= vetta;
    if (ilma <=0){
        KOULE();
    }
    Debug.Log("vetta");

}
public void KOULE(){
    gameObject.SetActive(false);

    Instantiate(ei_vitamiineja,transform.position, Quaternion.identity);

    Debug.Log("ez");
    GameManager.Instance.vaihdo(GameState.ei_peli);
}




    // Update is called once per frame
    
}
