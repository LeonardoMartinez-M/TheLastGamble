using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] 
    private float horizontalSpeed = 10f;
    [SerializeField] 
    private float verticalSpeed = 10f;
    [SerializeField] 
    private float clampAngle = 80f;
    
    private InputManager _inputManager;
    private Vector3 startingRotation;
    protected override void Awake()
    {
        _inputManager = InputManager._instance;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                // Check if startingRotation has its default value (0, 0, 0)
                if (startingRotation == Vector3.zero)
                {
                    startingRotation = vcam.transform.localRotation.eulerAngles;
                }

                Vector2 deltaInput = _inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}
