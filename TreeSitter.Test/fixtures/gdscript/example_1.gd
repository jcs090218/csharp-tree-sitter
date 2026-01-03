extends Sprite # Inherits from the Sprite class

# Member variables declared at the top of the script have script-wide scope
@export var speed := 400.0 # @export makes the variable visible and editable in the Godot Inspector

func _ready():
    # Called when the node enters the scene tree for the first time
    print("Player sprite is ready to move!")
    # Set the initial position to a specific location if desired
    # position = Vector2(500, 500) 

func _process(delta):
    # Called every frame; 'delta' is the elapsed time since the previous frame
    
    # Move the sprite to the right by 'speed' pixels per second
    position.x += speed * delta
    
    # If the sprite goes off-screen (e.g., past x=1200), reset its position
    if position.x > 1200:
        position.x = -100 # Start from the left side again
