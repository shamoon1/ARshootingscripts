using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimation : MonoBehaviour
{
    public Animation anim;
   
    public ParticleSystem particals,smoke,bulet;
    // Start is called before the first frame update
    void Start()
    {
      
        
           anim = gameObject.GetComponent<Animation>();
       // Invoke("drawAnim", 1f);
    }
    void drawAnim()
    {
        anim.CrossFade("draw");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
  
   
}
