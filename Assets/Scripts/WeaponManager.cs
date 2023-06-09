using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;

    public float range = 100f;
    // Start is called before the first frame update
    public float damage = 25f;

    public Animator weaponAnimator;

    public ParticleSystem muzzleFlash;

    public GameObject hitParticles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponAnimator.GetBool("isShooting")) {
            weaponAnimator.SetBool("isShooting", false);
        }
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
        
    }
    void Shoot()
    {
    
        muzzleFlash.Play();
        weaponAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range)){
            //Debug.Log("hit");
            EnemyManager enemyManager =  hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null) {
                enemyManager.Hit(damage);
                GameObject  instParticles = Instantiate(hitParticles, hit.point, Quaternion.LookRotation(hit.normal));
                instParticles.transform.parent = hit.transform;

                Destroy(instParticles, 2f);
            }
        }
        
    }
}
