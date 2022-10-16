/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public float bulletForce = 3.5f;

    public Rigidbody2D rigidBody;
    public Camera cam;

    Vector2 mousePos;
    Vector2 lookDir;

    Vector3 aimDirection;

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
        // public Vector3 shellPosition;
    }

    // private PlayerLookAt playerLookAt;
    private Transform aimTransform;
    private Transform muzzleFlash;
    private Transform aimGunEndPointTransform;
    // private Transform aimShellPositionTransform;
    private Animator aimAnimator;

    private void Awake() {
        // playerLookAt = GetComponent<PlayerLookAt>();
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
        muzzleFlash = aimTransform.Find("MuzzleFlash");
        // aimShellPositionTransform = aimTransform.Find("ShellPosition");
    }

    private void Update() {
        HandleAiming();
        HandleShooting();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){
        lookDir = mousePos - rigidBody.position;
        lookDir.Normalize();
    }

    private void HandleAiming() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        // Vector3 aimLocalScale = Vector3.one;
        // if (angle > 90 || angle < -90) {
        //     aimLocalScale.y = -1f;
        // } else {
        //     aimLocalScale.y = +1f;
        // }
        // aimTransform.localScale = aimLocalScale;

        // playerLookAt.SetLookAtPosition(mousePosition);
    }

    private void HandleShooting() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            GameObject bullet = Instantiate(bulletPrefab, aimGunEndPointTransform.position, aimGunEndPointTransform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // rb.AddForce(lookDir * 300f);
            rb.AddForce(lookDir * bulletForce, ForceMode2D.Impulse);

            aimAnimator.SetTrigger("Shoot");

            // Debug.Log(aimGunEndPointTransform.position);
            // Debug.Log(mousePosition);

            OnShoot?.Invoke(this, new OnShootEventArgs { 
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
                // shellPosition = aimShellPositionTransform.position,
            });
        }
    }

}
