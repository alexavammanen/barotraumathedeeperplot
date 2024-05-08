using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class kivi : MonoBehaviour, IDamageable
{

    private float paino = 3f;
    private Rigidbody2D keho;
    public Transform kotisi;
    public int kotisikoko = 10;
    public int halusikotiin = 10;

    public int kodikestavys = 10;
    public int kotikesti = 2;

    public int kotikatos = 10;

    public int kotiin = 10;

    private float kotikello = 10;

    private bool kotiiiiin = false;


    public int nom = 31;

    private int soi = 0;

    Vector2 loyto;



    // Start is called before the first frame update
    void Awake()
    {

        keho = GetComponent<Rigidbody2D>();
    }

    void OnEnable(){
        soi = nom;

    }

    private void Ammu(){


        if(kotisi == null)
        {

            return;
        }

        if (kotikello > 0){

            kotikello -= Time.fixedDeltaTime;

        }

        

        else if(!kotiiiiin && Vector2.Distance(transform.position, kotisi.position)< kotisikoko){

            StartCoroutine(nopieastkottiin());
            //Debug.Log("eee");
        }



        

        


    }


    //private void OnDisable{



    
    IEnumerator nopieastkottiin(){

            kotiiiiin = true;
            float alota = Time.time;

            while(Time.time < alota * kotikesti){
                keho.velocity = loyto * halusikotiin;
                yield return null;



            }
            keho.velocity = Vector2.zero;
                    

            


            kotiiiiin = false;

            kotikello = halusikotiin;
            
        }

    // Update is called once per frame
    void FixedUpdate(){
        Tippu();
        Ammu();
        
    }


    private void Tippu()
    {
        if(kotisi == null)
        {
            getPlayer();
            return;
        }

        if(kotiiiiin == true){
            return;

        }


        loyto = (kotisi.position - transform.position).normalized;
        keho.MovePosition(keho.position + loyto * paino * Time.fixedDeltaTime);
    }

    void getPlayer(){
        kotisi = GameManager.Instance.getPlayer.transform;

    }

    public void Ilmaista(int vetta)
    {
        soi -=vetta;
        if(soi <= 0){
            KOULE();
        }
    }

    public void KOULE()
    {
        EnemyPoolManager.Instance.ReturnEnemy(gameObject);
    }
    void OnTriggerEnter2D (Collider2D other){



        if(other.CompareTag("Player")&& kotiiiiin){
            other.GetComponent<IDamageable>().Ilmaista(1);

        }





    }
}
