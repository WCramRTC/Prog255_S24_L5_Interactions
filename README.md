**1. Picking Up and Carrying:**

* **Example:** Link lifting a rock to uncover a hidden item in the Legend of Zelda series.
* **Benefits:** Allows exploration of the environment and the potential for puzzle solving.

**2. Pushing and Pulling:**

* **Example:** Moving crates to create pathways or reach higher platforms in games like Uncharted or Tomb Raider.
* **Benefits:** Adds a layer of physicality and environmental problem-solving. 

**3. Using:**

* **Example:**  Using a key to unlock a door, or a potion to heal in an RPG (role-playing game).
* **Benefits:** Expands item functionality and adds elements of resource management.

**4. Activating:**

* **Example:**  Pressing buttons, flipping switches, or pulling levers to trigger events or changes in the environment.
* **Benefits:** Offers cause-and-effect mechanics for puzzles and unlocking new areas.

**5. Examining:**

* **Example:** Closely inspecting objects to discover details, lore, or clues to progress in detective or investigation games.
* **Benefits:**  Encourages player observation and deepens the sense of immersion in the game world. 

**6. Talking:**

* **Example:** Engaging in dialogue with non-player characters (NPCs) to receive quests, information, or learn about the world.
* **Benefits:** Drives narrative, builds relationships with characters, and allows players to influence the game's story.

**7.  Attacking:**

* **Example:** Using weapons or abilities to damage enemies, break down obstacles, or destroy objects.
* **Benefits:** The core of combat systems and a satisfying way to overcome challenges.

**8. Transforming:**

* **Example:** Using objects to change the character's form or abilities, such as Mario gaining powers from mushrooms.
* **Benefits:** Provides new gameplay mechanics and a sense of progression and discovery.

**9. Combining:**

* **Example:**  Crafting new items or tools from multiple objects, frequently seen in survival or adventure games.
* **Benefits:**  Encourages experimentation, resource gathering, and a sense of accomplishment.

**10. Environmental Interaction**

* **Example:**  Causing chain reactions in the world such as a physics-based object toppling over another, or fire spreading through flammable materials.
* **Benefits:** Creates dynamic gameplay scenarios and rewards player creativity. 


---

## Movement

## Interactions

### File Formats for 3d Modeling and Importing
.gltf
.glb

[GLTF vs GLB](https://ikarus3d.com/media/3d-blog/glb-and-gltf-files-purpose-difference-and-area-of-application-in-3d-modeling-services/#:~:text=Key%20Difference%3A%20GLB%20vs%20GLTF&text=GLTF%20is%20a%20text%2Dbased,into%20a%20single%20binary%20file.)

 ---
- [ ] UV Mapping and Texture Wrapping in Blender

---
## Adding scripts to an object in unity

Absolutely, here's how to attach scripts to game objects in Unity.

**Understanding Scripts in Unity**

- **Scripts as Components:** Scripts in Unity function as components. Components define the behavior and properties of your game objects.
- **Creating Scripts:** You can create C# scripts directly within Unity for this purpose.

**Methods for Attaching Scripts**

There are a few ways to attach scripts to GameObjects in Unity:

**1. Drag and Drop**

- **Project View:** Find the script you want to attach in the Project View. Drag it directly onto your GameObject in the Hierarchy View or the Scene View.
- **Inspector View:** With the GameObject selected, drag the script from the Project View into the Inspector View onto the "Add Component" area.

**2. "Add Component" Button**

1. Select the GameObject in either the Hierarchy or Scene View.
2. In the Inspector View, click the "Add Component" button.
3. Search for your script's name (or browse the categories) and click on it to add it.

**3. Adding Scripts at Runtime (Coding)**

You can dynamically add scripts to GameObjects during gameplay using the `AddComponent()` method:

C#

```
MyClass myObject = gameObject.AddComponent<MyClass>(); 
// Now the GameObject will run the Awake and Start methods from MyClass
```

**Important Notes:**

- The script file's name needs to match the class name defined within the script for it to work properly.
- Unity predominantly uses C# for scripting.
- Attached scripts appear as components in the Inspector View of the GameObject.

**Example: Creating a Movement Script and Attaching**

1. **Create a Script:**
    
    - Right-click in your Project View -> "Create" -> "C# Script".
    - Name it something like "PlayerMovement".
2. **Write the Script:**
    
    C#
    
    ```
    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f;
    
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
    }
    ```
    
3. **Attaching (Choose One):**
    
    - Drag the "PlayerMovement" script onto your player GameObject.
    - Or, use the "Add Component" button on the player GameObject.

Now your player object should move horizontally based on the arrow keys!

---

### Time.deltaTime

In Unity, `Time.deltaTime` is a crucial concept for making your game framerate independent. Here's a breakdown of what it is and why it matters:

**What is Time.deltaTime?**

- **Time between frames:** `Time.deltaTime` represents the amount of time, in seconds, that it took to complete the previous frame. This value is essential because frame durations can fluctuate on different hardware and under varying game conditions.

**Why does it matter?**

1. **Frame-independent movement:** If you want objects to move at a consistent speed regardless of the framerate, you need `Time.deltaTime`. For instance:
    
    C#
    
    ```
    transform.position += Vector3.right * speed * Time.deltaTime;
    ```
    
    This code ensures smooth movement because the distance moved each frame is scaled based on how much real-world time has passed.
    
2. **Consistent physics:** Some physics calculations might also depend on frame duration for accuracy. `Time.deltaTime` becomes useful here, too.
    
3. **Time-based actions:** If you want to create timers, countdowns, or anything that occurs over a duration, `Time.deltaTime` lets you track progress in a framerate-independent way.
    

**Example:**

Imagine a game with two computers:

- **Computer A:** Runs the game at 120 frames per second (FPS).
- **Computer B:** Runs the game at 30 FPS.

Without `Time.deltaTime`, an object moving at a "speed" of 1 unit per frame would travel 120 units per second on Computer A, but only 30 units per second on Computer B. This creates inconsistent experiences for players.

**Key Points**

- `Time.deltaTime` is usually a small fractional number (e.g., 0.016 for 60 FPS).
- It's generally used within the `Update()` function, which is called once per frame.

---

### Collisions and RigidBody


**1. Colliders: The Foundation**

- **Invisible Shapes:** Colliders are components that define the physical shape of an object for collision detection. They don't have to match the object's visual mesh perfectly—you can optimize using simpler shapes.
- **Types:** Unity offers several collider types:
    - Primitive Colliders (Box, Sphere, Capsule)
    - Mesh Colliders (Using the object's actual mesh for more complex shapes)
    - 2D Specific Colliders for 2D physics scenarios.

**2. Rigidbodies: For Physics Interaction**

- **Gravity and Forces:** To have objects physically react to collisions (bounce, fall due to gravity), at least one of the colliding objects needs a Rigidbody component attached.
- **Kinematic Rigidbodies:** A specific type of Rigidbody that won't be affected by forces, but can still trigger collisions and be moved manually.

**3. The Collision Process**

1. **Continuous Collision Detection:** Unity's physics engine continuously checks for potential collisions within the scene.
2. **Overlap:** When colliders overlap, a collision occurs.
3. **Collision Messages:** Unity generates callback functions:
    - `OnCollisionEnter`: Called the moment a collision begins.
    - `OnCollisionStay`: Called repeatedly while objects are touching.
    - `OnCollisionExit`: Called when the collision ends.

**4. Triggers: Detection Without Physical Response**

- **Is Trigger:** A checkbox on colliders turns them into triggers. Triggers detect when other colliders pass through them, but they don't cause physical reactions like bouncing.
- **Use Cases:**
    - Creating pickup zones
    - Starting events when a player enters an area

**5. Collision Handling (Your Scripts)**

- **Inside Collision Functions:** Within the `OnCollisionEnter/Stay/Exit` functions, you write your C# code that dictates how your game should respond to the collision:
    - Applying forces
    - Changing scores
    - Making objects disappear
    - Playing sounds

**Example:**

C#

```
void OnCollisionEnter(Collision collision) 
{
    if (collision.gameObject.tag == "Enemy") 
    {
        Destroy(gameObject);  // Destroy the player if it hits an "Enemy"
    }
}
```

**Important Notes:**

- **Layers:** You can use layers within Unity to control which objects can collide with each other
- **Optimization:** Complex mesh colliders can be performance-heavy. Use primitive shapes where possible for efficiency.


---

## What are rigid bodies

**Key Functions of a Rigidbody:**

1. **Gravity:** Rigidbodies automatically respond to gravity, making objects fall realistically unless other forces are applied.
    
2. **Forces and Torque:** You can apply forces (pushes and pulls) and torque (rotational forces) to Rigidbodies using code or physics forces in your scene. This is how you make objects move and spin in a physically realistic manner.
    
3. **Collisions:** When objects with Rigidbodies (and appropriate colliders) collide, the physics engine handles realistic physical reactions like bouncing, sliding, etc., based on the objects' properties.
    
4. **Kinematic Rigidbodies:** A special type of Rigidbody exists that doesn't automatically respond to forces. These are useful for objects you want to move manually through code while still having them participate in collision detection.
    

**Why Do You Need Rigidbodies?**

- **Realistic Physics Behavior:** If you want objects to behave in ways that resemble the real world (falling, bouncing, being pushed by explosions, etc.), you need Rigidbodies.
- **Game Mechanics:** Many game mechanics rely on physics. Think of launching projectiles, platformer jumping, or ragdoll effects—these all depend on the Rigidbody component.

**How to Use a Rigidbody**

1. **Add the Component:** Select your GameObject in the Hierarchy View. In the Inspector View, click "Add Component" and then search for "Rigidbody".
2. **Properties:** The Rigidbody component has properties you can adjust:
    - **Mass:** Influences how the object reacts to forces.
    - **Drag:** Simulates air resistance or friction.
    - **Angular Drag:** Simulates rotational friction.
    - **Constraints:** You can freeze position or rotation on specific axes if needed.

**Example Scenario:**

Imagine you want to create a crate that can be pushed around by the player.

1. Add a box collider to the crate GameObject.
2. Add a Rigidbody component to the crate GameObject.
3. Write a script for the player to apply forces on the crate when they collide with it.

**Important:**

- Only one of the colliding objects needs a Rigidbody for basic collision detection.
- Use Rigidbodies wisely; while they enable realistic physics, they can also add processing overhead, so use them strategically.

---

### Current object Rigidbody vs External object Rigidbody


**1. Getting the Rigidbody Component**

You need a reference to the Rigidbody component attached to your current GameObject. Here's how you typically get it:

C#

```
Rigidbody myRigidbody;

void Start()
{
    myRigidbody = GetComponent<Rigidbody>();
}
```

In this code:

- We declare a variable `myRigidbody` of type `Rigidbody`
- Inside the `Start()` function, which runs once when the object enters the scene, we use `GetComponent<Rigidbody>()` to fetch the Rigidbody component attached to the same GameObject as this script.

**2. Interacting with the Rigidbody**

Now that you have the `myRigidbody` reference, you can do several things:

- **Applying Forces:**
    
    C#
    
    ```
    myRigidbody.AddForce(Vector3.up * 100); // Add an upward force
    ```
    
- **Changing Velocity:**
    
    C#
    
    ```
    myRigidbody.velocity = new Vector3(5, 0, 0); // Set velocity to move right
    ```
    
- **Modifying Properties:**
    
    C#
    
    ```
    myRigidbody.mass = 2.0f;  // Change the object's mass
    myRigidbody.useGravity = false;  // Disable gravity for this object
    ```
    

**Complete Example: Making an Object Jump**

C#

```
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
```

**Important Notes**

- Ensure your GameObject has a Rigidbody component attached for this to work.
- It's generally good practice to cache the Rigidbody reference in the `Start()` function, as getting components frequently can impact performance.

---
### Serialized Field

**1. Exposing Private Fields to the Editor:**

- **The Problem:** Unity can only serialize and save public fields by default. This restricts you if you want to control access to a variable while still being able to tweak its values in the Inspector.
- **The Solution:** The `[SerializeField]` attribute lets you make private fields visible and editable within Unity's Inspector window.

**2. Saving and Loading Data**

- **Serialization:** Unity's serialization system converts the data in your scripts into a format it can save and reload when your project isn't running.
- **Serialized Fields:** When you mark a field with `[SerializeField]`, you instruct Unity to include it in this saving and loading process. This data is preserved between play sessions.

**Example:**

C#

```
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }
}
```

In this example:

- `maxHealth` is a private variable, so other scripts couldn't directly access it.
- `[SerializeField]` makes `maxHealth` appear in the Inspector, letting you set its initial value.

**Key Points:**

- **Doesn't Affect Code Accessibility:** Serialized fields still follow private/public access rules within your code. Only the Unity editor can see and modify them.
- **Use Cases:**
    - Configuring enemy health
    - Setting starting resources in a strategy game
    - Storing player preferences

