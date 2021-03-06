﻿/* 
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
    public AudioClip shootClip;
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
        public Vector3 shellPosition;
    }

    //private PlayerLookAt playerLookAt;
    private Transform aimTransform;
    private Transform aimGunEndPointTransform;

    private Transform aimGunEndPointTransform2;
    private Transform aimShellPositionTransform;
    private Animator aimAnimator;

    private void Awake() {
        //playerLookAt = GetComponent<PlayerLookAt>();
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");

        aimGunEndPointTransform2 = aimTransform.Find("GunEndPointPosition2");
        aimShellPositionTransform = aimTransform.Find("ShellPosition");
    }

    private void Update() {
        if (Utils.Pause)
        {
            return;
        }
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;

        //playerLookAt.SetLookAtPosition(mousePosition);
    }

    private void HandleShooting() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            aimAnimator.SetTrigger("Shoot");
            GetComponents<AudioSource>()[0].PlayOneShot(shootClip);

            Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(aimGunEndPointTransform2.position, aimDirection);
            if (raycastHit2D.collider != null)
            {
                Enemy_simple enemy = raycastHit2D.collider.GetComponent<Enemy_simple>();
                if (enemy)
                {
                    enemy.Damage(100);



                    if (enemy.GetComponent<AudioSource>())
                    {

                        GetComponents<AudioSource>()[1].PlayOneShot(enemy.GetComponent<AudioSource>().clip);
                    }

                    Utils.MonsterKilled += 1;
                    Utils.MonsterKilledTotal += 1;
                }
            }

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
                shellPosition = aimShellPositionTransform.position,
            });
        }
    }

}
