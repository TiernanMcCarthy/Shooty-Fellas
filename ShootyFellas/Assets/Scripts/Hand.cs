using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Camera Main;

    //public GameObject Parent;

    public float OffsetDistance = 1.0f;

    public GameObject handPivot;

    public GameObject currentGun;
    public Animator animator;
    public SpriteRenderer sprite;

    public float directionFacing; //-1 for left, 1 for right
    // Start is called before the first frame update
    void Start()
    {
        Main = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.mousePosition);
        Vector3 Worldpos = Input.mousePosition;

        Worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = new Vector3(Worldpos.x - transform.position.x, Worldpos.y - transform.position.y);
        handPivot.transform.right = aimDirection;
        float clampedRot = Mathf.Clamp(handPivot.transform.rotation.z, -160f, 10f);
        handPivot.transform.rotation = new Quaternion(handPivot.transform.rotation.x, handPivot.transform.rotation.y, clampedRot, handPivot.transform.rotation.w);

        if((handPivot.transform.eulerAngles.z > 90f && handPivot.transform.eulerAngles.z <= 270f))
        {
            //Debug.Log(handPivot.transform.eulerAngles.z);
            currentGun.GetComponent<BaseGun>().gunsprite.flipY = true;
           
        }
        else
        {
            //Debug.Log(handPivot.transform.eulerAngles.z);
            currentGun.GetComponent<BaseGun>().gunsprite.flipY = false;
           
        }

        ChangeSprite();
 
    }

    void ChangeSprite()
    {
        if (handPivot.transform.eulerAngles.z > 10f && handPivot.transform.eulerAngles.z <= 170f)
        {
            animator.SetBool("WalkingDown", false);
        }
        else
        {
            animator.SetBool("WalkingDown", true);
        }

        if (handPivot.transform.eulerAngles.z < 90f || handPivot.transform.eulerAngles.z >= 270f)
        {
            sprite.flipX = true;
            directionFacing = 1;
        }
        else
        {
            sprite.flipX = false;
            directionFacing = -1;
        }

        //if (Input.GetAxisRaw("Horizontal") == 1)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else if (Input.GetAxisRaw("Horizontal") == -1)
        //{
        //    GetComponent<SpriteRenderer>().flipX = false;
        //}
    }
}
