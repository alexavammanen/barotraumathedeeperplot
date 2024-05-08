using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilotti : MonoBehaviour
{
    private float paine = 5f;
    private float ennen_elakeeta = 2.5f;
    private float pommi;

private void OnEnable(){
    pommi = ennen_elakeeta;

}

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * -1 * paine * Time.deltaTime);
        pommi -= Time.deltaTime;
        if(pommi <= 0 ){
            allas.Instace.extraction(gameObject);
        }
        
    }
    void OnTriggerEnter2D (Collider2D other){

        if(other.CompareTag("Player")){
            return;
        }

        IDamageable vuotava = other.GetComponent<IDamageable>();
        if(vuotava != null){
            vuotava.Ilmaista(1);
            allas.Instace.extraction(gameObject);
        }



    }







}
