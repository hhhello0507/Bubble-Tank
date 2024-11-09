using UnityEngine;

public class TurrentRotate : MonoBehaviour
{
    private const float RotationSpeed = 200f;
    private float _mouseX;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var mouseX = Input.GetAxis("Mouse X");
        
        _mouseX += mouseX * RotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, _mouseX, 0);   
    }
}