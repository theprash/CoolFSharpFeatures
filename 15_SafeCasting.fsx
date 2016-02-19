// Cast up the class hierarchy with the upcast operator.
// This is guaranteed to be safe at compile time.

open System.Xml

new XmlDocument() :> XmlNode

// Let's make a CheckBox and cast it up to Control.

open System.Windows.Forms
let checkboxControl = new Button() :> Control

// Casting it back down into a Checkbox is not safe, so we'll match with the type test pattern.

match checkboxControl with
| :? Button as button -> button.Text
| :? CheckBox as checkbox -> checkbox.Text
| _ -> "No type matches :("
