using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMarioAnimation : MonoBehaviour
{
   SpriteRenderer spriteRenderer;

   public List<Sprite> spriteList = new List<Sprite>();
   public float delay = 1.0f; 
   public float moveSpeed = 1.0f;
   public AnimationCurve curve;

   private void Awake()
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }
   IEnumerator Start()
   {
       yield return new WaitForSeconds(2.0f);
       Debug.Log("Starting!");
       //StartCoroutine(Animate());
       StartCoroutine(EvalCurve());
   }

   IEnumerator Animate()
   {
       int counter = 0; 
       StartCoroutine(Move());

       while (true)
       {
           spriteRenderer.sprite = spriteList[counter];
           yield return new WaitForSeconds(delay);
           counter++;

           if (counter > spriteList.Count - 1)
           {
               counter = 0;
           }
       }
   }

   IEnumerator Move()
   {
       while (true)
       {
           transform.position = new Vector3(transform.position.x - (Time.deltaTime * moveSpeed), transform.position.y, transform.position.z);
           yield return null;

           if (transform.position.x < -10)
           {
               transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
           }
       }
   }

   IEnumerator EvalCurve()
   {
       float t = 0.0f;

       while (true)
       {
           t = 0.0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime; 
                transform.position = new Vector3(curve.Evaluate(t), 0.0f, 0.0f);
                yield return null;
            }

            Debug.Log("We're done!");
            yield return null;
       }

   }

}
