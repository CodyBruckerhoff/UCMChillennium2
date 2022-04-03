using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatTheOven : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform target;

    //public static int ovenScore = 0;

    float targetPosition;
    float targetDestination;

    float targetTimer;
    [SerializeField] float timerMultipilcator = 3f;

    float targetSpeed = 5f;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform area;
    float areaPosition;
    [SerializeField] float areaSize = 0.1f;
    [SerializeField] float areaPower = 0.5f;
    public static float areaProgress;
    float areaPullVelocity;
    [SerializeField] float areaPullPower = 0.01f;
    [SerializeField] float areaGravityPower = 0.005f;
    [SerializeField] float areaProgressDegrationPower = 0.1f;

    [SerializeField] private Rigidbody2D areaRB;
    [SerializeField] private float jumpForce;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private Transform progressBarContainer;
    public bool isScoring = false;

    private float lastUpdate;


    // Update is called once per frame
    void Update()
    {
        TargetMovement();
        AreaMovement();
        ProgressCheck();
    }

    void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = areaProgress;
        progressBarContainer.localScale = ls;

        float min = areaPosition - areaSize / 2;
        float max = areaPosition + areaSize / 2;
        if (isScoring)
        {
            areaProgress += areaPower * Time.deltaTime;
        }
        else
        {
            areaProgress -= areaProgressDegrationPower * Time.deltaTime;
        }
        if (areaProgress >= 1f)
        {
            Debug.Log("Full");
        }

        areaProgress = Mathf.Clamp(areaProgress, 0f, 1f);
    }
    public void scoring()
    {
        isScoring = true;
    }

    void AreaMovement()
    {
        /*if (Input.GetMouseButton(0))
        {
            areaPullVelocity += areaPullPower * Time.deltaTime;
        }
        areaPullVelocity -= areaGravityPower * Time.deltaTime;

        areaPosition += areaPullVelocity;
        areaPosition = Mathf.Clamp(areaPosition, areaSize / 2, 1  - areaSize / 2);
        area.position = Vector3.Lerp(bottomPivot.position, topPivot.position, areaPosition);*/

        if (Input.GetMouseButton(0))
        {
            areaRB.velocity = new Vector2(areaRB.velocity.x, jumpForce);
        }


    }
    void TargetMovement()
    {
        targetTimer -= Time.deltaTime;
        if (targetTimer < 0f)
        {
            targetTimer = UnityEngine.Random.value;

            targetDestination = UnityEngine.Random.value;
        }

        targetPosition = Mathf.SmoothDamp(targetPosition, targetDestination, ref targetSpeed, smoothMotion);
        target.position = Vector3.Lerp(bottomPivot.position, topPivot.position, targetPosition);
    }

}