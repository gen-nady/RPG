using UnityEngine;

public class RoundCamera : MonoBehaviour
{
    [SerializeField] private float _rotateSpeedModifer;
    private Touch _touch;
    private Vector2 _touchPosition;
    private Quaternion _rotation;
    private bool isCanRotate;
    private bool isZero;
    private void Update ()
    {
        if (isCanRotate)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(Input.touchCount-1);
                if (_touch.phase == TouchPhase.Moved)
                {
                    var rotatio = new Vector3(-_touch.deltaPosition.y * _rotateSpeedModifer,
                        -_touch.deltaPosition.x * _rotateSpeedModifer, 0f);
                    transform.eulerAngles += rotatio;
                    isZero = false;
                }
            }
        }
        else
        {
            if(isZero) return;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * 10f );
            if (transform.eulerAngles == Vector3.zero)
                isZero = true;
        }
    }

    public void CanRotate(bool isTouch)
    {
        isCanRotate = isTouch;
    }
}
