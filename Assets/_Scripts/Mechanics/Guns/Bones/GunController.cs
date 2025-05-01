using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GunController : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] private GunData data;

    [Header("Shot Origins")] 
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform sight;

    [Header("Operational State")] 
    [SerializeField] private bool abilityActivated;
    [SerializeField] private bool cobained;
    [SerializeField] private bool canFire;
    [SerializeField] private bool triggerDown;
    [SerializeField] private bool reloading;

    [Header("Ammo Info")] 
    [SerializeField] public int ammoInMag;
    [SerializeField] private int reserveAmmo;
    [SerializeField] private float fireRate;

    [Header("Positional Data")] 
    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private Vector3 aimPosition;
    [SerializeField] private Quaternion originalRotation;

    [Header("Aiming")]
    private Coroutine _aimRoutine;
    protected bool _isAiming;

    [Header("FX")] 
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject bulletTrail;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ding;
    private InputManager _input;
    
    // Start is called before the first frame update
    void Start()
    {
       

        
        // initialize the audio source
        // initialize the animator
        
        // cache the original position and rotation to reset to after recoiling/adsing
       //originalPosition = transform.localPosition;
        //originalRotation = transform.localRotation;

        aimPosition = data.aimPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // what should happen all the time?
        ResetRecoil();
      
    }
    
    #region Shooting

    private void onAbilityUsed(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability Used");
    }

    private void OnTriggerPulled(InputAction.CallbackContext obj)
    {
        // can I shoot?
        Debug.Log("Shot");
        // if I can, which mode should I shoot in?
    }

    private void OnTriggerReleased(InputAction.CallbackContext obj)
    {
        Debug.Log("trigger release");
        // stop shooting
    }

    private void ADSShoot()
    {
        // perform hit detection using a raycast
        
        // apply recoil
        
        // apply effects
    }

    private void HipShoot()
    {
        // calculate bloom
        
        // hit detection
        
        // apply recoil
        
        // apply effects
    }

    private void ResetRecoil()
    {
        // undo rotation
        
        // undo position change
        
    }
    
    #endregion
    
    #region Aiming

    private void OnAimPressed(InputAction.CallbackContext obj)
    {
        // interpolate between the original position of the gun and the aim position
        // using the aim coroutine.
        _isAiming = true;
      //  if(_aimRoutine != null) StopCoroutine(_aimRoutine);
      //  _aimRoutine = StartCoroutine(AimDownSights());
    }

    private void OnAimReleased(InputAction.CallbackContext obj)
    {
        // opposite of aim pressed.
        _isAiming = false;
     //   if(_aimRoutine != null) StopCoroutine(_aimRoutine);
     //   _aimRoutine = StartCoroutine(ReturnSightPosition());
    }

    private IEnumerator AimDownSights()
    {
        while (true)
        {
      //      transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * 8);
            yield return null;
        }
    }

    private IEnumerator ReturnSightPosition()
    {
        while (true)
        {
       //     transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * 8);
            yield return null;
        }
    }
    
    #endregion
    
    #region Sway

   
    
    #endregion
}