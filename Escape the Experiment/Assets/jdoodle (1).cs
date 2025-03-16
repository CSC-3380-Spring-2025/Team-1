using UnityEngine;

class FirstPersonController: MonoBehavior
{
    //public bool can move 
    //private is sprinting 
    //private shoudle jump 
    private bool ShouldCrouch =>Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;
    
    
    //functional options 
    [Header("Functional Options")]
    [SerializeField] private bool canCrouch = true;

    //controllers 
    [Header("Controls")]
    [SerializeField] private Keycode crouchKey= Keycode.LeftControl;
    
    //movement para 
    [Header("Movement Parameters")]
    [SerializeField] private float crouchSpeed=1.5f; 


    //look para 
    //jumping para
    
    
    [Header("Crouch Parameters")]
    //crouch height 
    [SerializeField] private float crouchHeight=0.5f; 
    //stand height 
    [SerializeField] private float standingHeight=2f; 
    //is crouching 
    //is in crouch animation 
    //time to crouch/stand 
    [SerializeField] private float timeToCrouch=0.25f; 
    //standing at center point 
    //crouching center point 
    [SerializeField] private Vector3 crouchingCenter=new Vector3 (0,0.5f,0);
    
    //standing center 
    [SerializeField] private Vector3 standingCenter=new Vector3 (0,0,0);
    
    private bool isCrouching;
    private bool duringCrouchAnimation; 
    
    private Camera playerCamera;
    private CharacterController characterController;
    
   private Vector3 moveDirection; 
   private Vector2 currentInput;
   
   private float rotationX = 0; 

    //void awake 
    
    void Update()
    {
        //
        //if can move
        //{handle movement input 
        //handle mouse look 
        //if can jump 
        
        if(canCrouch)
            HandleCrouch();
            
            //apply final movement here 
        
        }
    }
//handle movement 
//{}

//currentInput = new Vector2 (( isCrouching ? crouchSpeed : isSprinting ? sprint speed..))
//crouch go first 

//handle mouse look
//{}

//private handle jump 
//{}

private void HandleCrouch()
{
    if(ShouldeCrouch)
    StartCoroutine(CrouchStand());
    
}


//apply final movements 
//{}

private IEnumerator CrouchStand()
{
    if(isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up,1f))
    yield break;
    
    
    duringCrouchAnimation = true; 
    
    float timeElapsed =0;
    float targeHeight = isCrouching ? standingHeight : crouchHeight;
    float currentHeight = characterController.height; 
    Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
    Vector3 currentCenter = characterController.center;
    
    while(timeElapsed <timeToCrouch)
    {
       characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
       characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
       timeElapsed += Time.deltaTime;
       yield return null; 
    }
    
    characterController.height = targetHeight; 
    characterController.center = targetCenter;
    
    isCrouching = !isCrouching;
    duringCrouchAnimation = false;
}
 

}
    