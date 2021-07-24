using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public float minSize, maxSize;
    public float zoomSensitivity = 10;
    public boolValue isInMap;
    public Animator animator;
    public VectorValue camMin;
    public VectorValue camMax;
    private float scroll;
    private Camera ZoomCamera;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        animator = GetComponent<Animator>();
        ZoomCamera = Camera.main;
    }
    void LateStart()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }

    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.M))
        {
            isInMap.runTimeValue = !isInMap.runTimeValue;
        }
        if (isInMap.runTimeValue)
        {
            scroll = Input.mouseScrollDelta.y;
            if (ZoomCamera.orthographic)
            {
                ZoomCamera.orthographicSize = Mathf.Clamp(ZoomCamera.orthographicSize - scroll * zoomSensitivity, minSize, maxSize);
            }
            else
            {
                ZoomCamera.fieldOfView = Mathf.Clamp(ZoomCamera.fieldOfView - scroll * zoomSensitivity, minSize, maxSize);
            }
        }
    }

    public void beginKick()
    {
        animator.SetBool("kickActive", true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return null;
        animator.SetBool("kickActive", false);
    }
}

