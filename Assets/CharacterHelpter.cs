using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterHelpter : MonoBehaviour
{
    private XRRig xrOrigin;
    //private XROrigin xrOrigin;
    private CharacterController characterController;
    private CharacterControllerDriver driver;
    // Start is called before the first frame update
    void Start()
    {
        //SumScore.ClearHighScore();
        xrOrigin = GetComponent<XRRig>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
        GameTimer.Start();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
        GameTimer.Update();

    }
    /// <summary>
        /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
        /// based on the camera's position.
        /// </summary>
        protected virtual void UpdateCharacterController()
        {
            if (xrOrigin == null || characterController == null)
                return;

            var height = Mathf.Clamp(xrOrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

            Vector3 center = xrOrigin.CameraInOriginSpacePos;
            center.y = height / 2f + characterController.skinWidth;

            characterController.height = height;
            characterController.center = center;
        }
}
