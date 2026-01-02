package org.wikipedia.example {
    import flash.display.Sprite;
    import flash.text.TextField;

    public class Greeter extends Sprite {
        public function Greeter() {
            // Create a new TextField object
            var txtHello: TextField = new TextField();
            // Set the text content
            txtHello.text = "Hello World";
            // Add the TextField to the display list (make it visible on stage)
            this.addChild(txtHello);
        }
    }
}
