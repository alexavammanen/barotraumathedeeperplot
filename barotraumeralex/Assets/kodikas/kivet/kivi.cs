using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kivi : MonoBehaviour, IDamageable
{

    private float paino = 3f;
    private Rigidbody2D keho;
    public Transform kotisi;
    public int kotisikoko = 1;
    public int halusikotiin = 1;

    public int kodikestavys = 1;
    public int kotikesti = 1;

    public int kotikatos = 1;

    public int kotiin = 1;

    private float kotikello = 1;


    public int nom = 31;

    private int soi = 0;




    // Start is called before the first frame update
    void Awake()
    {

        keho = GetComponent<Rigidbody2D>();
    }

    void OnEnable(){
        soi = nom;

    }

    // Update is called once per frame
    void FixedUpdate(){
        Tippu();
    }

    private void Tippu()
    {
        if(kotisi == null)
        {
            getPlayer();
            return;
        }
        Vector2 loyto = (kotisi.position - transform.position).normalized;
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
}
