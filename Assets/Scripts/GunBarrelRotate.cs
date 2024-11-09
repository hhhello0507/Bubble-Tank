using UnityEngine;

public class GunBarrelRotate : MonoBehaviour
{
    private const float RotateSpeed = 200f;
    private float _my;

    private void Update()
    {
        var mouseY = Input.GetAxisRaw("Mouse Y");

        _my += mouseY * RotateSpeed * Time.deltaTime;
        _my = Mathf.Clamp(_my, -5, 45f);
        
        transform.eulerAngles = new Vector3(-_my, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
