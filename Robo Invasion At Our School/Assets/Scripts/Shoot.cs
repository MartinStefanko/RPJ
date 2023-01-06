using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireForce;
    [SerializeField]
    private AudioSource gunShotAudio;
    [SerializeField]
    private AudioSource reloadAudio;

    [SerializeField]
    private float fireRate = 1f;

    private float nextFire = 1f;
    public float magSize = 17f;

    private float time = 0f;
    private float timeDelay = 2.5f;

    private bool reloading = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Check if magazine is empty if so reload
        if (magSize == 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (!reloadAudio.isPlaying)
                reloadAudio.Play();

            reloading = true;
            Invoke("Reload", 2.5f);
        }

        if (!GameController.isPaused && !GameController.shopIsOpened && !GameController.isDead)
        {
            // Check if LMB is being pressed and timer to avoid rapid shooting
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire && magSize > 0 && !reloading)
            {
                anim.SetTrigger("Shoot");
                Fire();
                gunShotAudio.Play();
                GameController.instance.UpdateammoTXT();
            }
        }
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;

        magSize--;

        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

    void Reload()
    {

        magSize = 17;
        GameController.instance.UpdateammoTXT();
        reloading = false;

    }
    public void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
