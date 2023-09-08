using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Problems:
    /// isGrounded geeft vaak false negatives

    public CharacterController Controller;

    public Transform player;

    public float MovementSpeed;
    public float sprintMultiplier;
    public float g;
    public float jumpHeight;
    public float massPlayer;

    public float FOVShiftTime;
    public float FOVSprint;
    public float FOVNormal;

    //private Vector3 jumpMovement;
    private Vector3 verticalMovement;

    public void Update()
    {
        float   x              = Input.GetAxis("Horizontal");
        float   z              = Input.GetAxis("Vertical");
        Vector3 horizontalMove = transform.right * x + transform.forward * z;


        bool isGrounded = GetComponent<CharacterController>().SimpleMove(horizontalMove);
        if (isGrounded)
        {
            verticalMovement.y = 0f; //prevents playerTransform from falling forever
            if (Input.GetButton("Jump"))
            {
                verticalMovement.y = jumpHeight;
                //jumpMovement = horizontalMove;
            } //jumps


            if (Input.GetKey("left shift"))
            {
                horizontalMove = new Vector3(horizontalMove.x * sprintMultiplier, 0,
                    horizontalMove.z * sprintMultiplier);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, FOVSprint, FOVShiftTime);
            } //sprints
            else
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, FOVNormal, FOVShiftTime);
            } //doesn't sprint

        }
        else
        {
            //Debug.Log("ungrounded");
            verticalMovement.y -= g * massPlayer * Time.deltaTime;
            //horizontalMove = jumpMovementduszegmaaraangepastesnelheidomdatjenietkuntversnellenindeluchthaha;
        }

        Controller.Move(horizontalMove * MovementSpeed * Time.deltaTime + verticalMovement * Time.deltaTime);
    }
}