using Bonuses;
using UnityEngine;

public class Pipe : Bonus
{
    [SerializeField] private float rotateSpeed;
    
    private void UpdateRotation()
    {
        if (Input.touchCount > 0)
        {
            transform.Rotate(0, Input.GetTouch(0).deltaPosition.x * rotateSpeed, 0);
        }
        #if UNITY_EDITOR
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime * 300f, 0);
        #endif
    }

    private void Update()
    {
        UpdateRotation();
    }
}
