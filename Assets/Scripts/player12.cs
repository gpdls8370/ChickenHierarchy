using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class player12 : MonoBehaviour
{
    public int MaxCount1 = 8;
    public int TargetCount = 0;
    public float movePower = 1f;
    public float jumpPower = 1f;

    Vector3 position;
    public float Speed = 5;
    

    void Start()
    {
        position = transform.position;
    }



    // Update is called once per frame

    void Update()
    {

    }


    void FixedUpdate()
    {
        Move();
        target1Result();

    }


    void Move()        //상하좌우 이동 
    {

        position.x += Speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        position.y += Speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.position = position;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "target1")
        {
            Destroy(collision.gameObject);                  //타겟1이랑 잘 부딪히면 타켓 없애고 카운트 올리고 점수 1추가
            TargetCount++;
            GameManager.instance.AddScore(1);
        }

        if(collision.gameObject.tag != "target1")
        {
            Destroy(this.gameObject);                        //타켓1말고 다른애랑 잘못 부딪히면 플레이어 없애고 실패화면으로
            GameManager.instance.Result("fail", "3round");

        }
    }
    
    void target1Result()                                 //애들 다 잡으면(맥스카운트 되면) main1없애고 main2 소환
    {
        if(TargetCount == MaxCount1)
        {
            Instantiate(Resources.Load("main22"), position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
   

}
