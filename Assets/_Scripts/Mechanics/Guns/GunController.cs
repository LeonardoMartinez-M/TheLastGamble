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
    [SerializeField] private bool canFire;
    [SerializeField] private bool triggerDown;
    [SerializeField] private bool reloading;

    [Header("Ammo Info")] 
    [SerializeField] private int ammoInMag;
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

    private InputManager _input;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = InputManager.instance;

        _input.FireAction.performed += OnTriggerPulled;
        _input.FireAction.canceled += OnTriggerReleased;
        _input.AimAction.performed += OnAimPressed;
        _input.AimAction.canceled += OnAimReleased;
        
        // initialize the audio source
        // initialize the animator
        
        // cache the original position and rotation to reset to after recoiling/adsing
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;

        aimPosition = data.aimPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // what should happen all the time?
        ResetRecoil();
        HandleSway();
    }
    
    #region Shooting

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
        if(_aimRoutine != null) StopCoroutine(_aimRoutine);
        _aimRoutine = StartCoroutine(AimDownSights());
    }

    private void OnAimReleased(InputAction.CallbackContext obj)
    {
        // opposite of aim pressed.
        _isAiming = false;
        if(_aimRoutine != null) StopCoroutine(_aimRoutine);
        _aimRoutine = StartCoroutine(ReturnSightPosition());
    }

    private IEnumerator AimDownSights()
    {
        while (true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * 8);
            yield return null;
        }
    }

    private IEnumerator ReturnSightPosition()
    {
        while (true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * 8);
            yield return null;
        }
    }
    
    #endregion
    
    #region Sway

    private void HandleSway()
    {
        float x = _input.Look.x;
        float y = _input.Look.y;
        
        // compute adjustment rotations based on sway intensity
        // and input amount. 
        var xAdj = Quaternion.AngleAxis(-data.swayIntensity * x, Vector3.up);
        var yAdj = Quaternion.AngleAxis(data.swayIntensity * y, Vector3.right);
        var zAdj = Quaternion.AngleAxis(-data.swayIntensity * x, Vector3.forward);

        // then create a true target rotation
        var targetRotation = originalRotation * xAdj * yAdj * zAdj;

        // then apply it using a Lerp.
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * data.smoothing);
    }
    
    #endregion
}