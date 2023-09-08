using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensX; //100
    public float mouseSensY; //60
    private float mouseY;
    public Transform Player;
    public Transform Cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensX * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensY * Time.deltaTime;   //reads PER FRAME how your mouse moved (per frame, hence the +=)
        mouseY = Mathf.Clamp(mouseY, -85.5f, 85.5f); //prevents the playerTransform from breaking his virtual neck

        Player.Rotate(0, mouseX, 0);
        Cam.localEulerAngles = new Vector3(-mouseY, Cam.localEulerAngles.y, Cam.localEulerAngles.z); //rotates the cam and not the playerTransform, because, yeah, you don't move your whole body when looking up. Why *-1? I don't know man.
    }
}