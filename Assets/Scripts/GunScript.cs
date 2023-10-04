using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 200f;
    public float impactForce = 50f;
    public float fireRate = 10f;

    private float nextBullet = 0f;

    public int maxAmmo = 10;
    private int CurrentAmmo;
    public Camera fpsCam;

    private bool isReloading = false;
    public ParticleSystem muzzleFlash;
    public float ReloadTime = 1f;
    public bool isScoped = false;

    Animator anim;
    private void Start()
    {
        anim=GetComponent<Animator>();
        CurrentAmmo = maxAmmo;
    }
    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (CurrentAmmo <=0 )
        {
            StartCoroutine(Reload());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!isScoped)
            {
                anim.SetBool("Scope", true);
                isScoped = true;
                fpsCam.fieldOfView = 45;
            }
            else
            {
                anim.SetBool("Scope", false);
                isScoped = false;
                fpsCam.fieldOfView = 60;
            }
            
        }
        if (Input.GetButton("Fire1") && Time.time>=nextBullet)
        {
            nextBullet = Time.time+1f/fireRate;
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        Debug.Log("Reloading");
        isReloading = true;
        anim.SetBool("Reloading",true);
        yield return new WaitForSeconds(ReloadTime-0.25f);
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        CurrentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot()
    {
        muzzleFlash.Play();
        CurrentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit,range))
        {
            Debug.Log(hit.transform.name);
            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.GetDamage(damage);
            }
        }
    }
}
