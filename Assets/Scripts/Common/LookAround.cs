using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float sensitivity;
    private float _yRotation;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _yRotation = transform.rotation.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _yRotation -= mouseY;
        _yRotation = Mathf.Clamp(_yRotation, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(_yRotation, Vector3.right);
        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
