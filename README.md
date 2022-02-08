# VR Keyboard 

[![openupm](https://img.shields.io/npm/v/com.virgis.vr-keyboard?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.virgis.vr-keyboard/)
 
 VR Keyboard is an Out of the Box World Space VR / XR Keyboard for Unity.
 
 The background is that I was looking for a simple solution to adding a keyboard into an application - to allow passwords to be entered. When I could not find one I created one.
 
 <a href="http://www.youtube.com/watch?feature=player_embedded&v=ijGji97zGOw
" target="_blank"><img src="http://img.youtube.com/vi/ijGji97zGOw/0.jpg" 
alt="Video of VR Keyboard" width="480" height="360" border="10" /></a>
 

## Installation

VR Keyboard can be installed as a UPM package - either directly from this repository or from [OpenUPM](https://openupm.com/packages/com.virgis.vr-keyboard/).

There is a sample project, also used for testing, included as a zip file in [the release package](https://github.com/ViRGIS-Team/VR-Keyboard/releases/tag/0.9.0)

## Dependencies

The package is build upon the following (which are included as dependencies in the UPM package):

- Unity UI (also known as UGUI)
- Unity XR Interaction Toolkit

The buttons are build using Unity UI and the XRIT is needed to create Interactors. This is discussed in more detail below.

These packages need to be installed and functional and set up to allow XRIT to interact with the UI system as described [in the documenation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html#ui-interaction-setup) - particularly the EventSystem since the UI canvas is already included in the keyboard.

## Usage

The package inlcudes a Keyboard prefab. Include this in your scene. The Keyboard includes a Canvas GameObject - the Canvas component on this GameObject requires a link to the active camera in the scene.

The Keyboard component creates the following events:

- **Key Pressed** triggers whenever a key is pressed. The payload is the character pressed,
- **Enter Pressed** triggers whenever `Enter` is pressed,
- **Backspace Pressed** triggers whenever `Backspace` is pressed, and
- **Status** triggered when the keyboard changes from normal to caps to symbols. You do not need to keep track of this change since the keyboard will send the correct character on **Key Pressed**.

## Output

This package does NOT do anything apart from provide the events. Particularly it does not provide anyway to display what is typed - this is your job.

This is a design feature.

For a reasonably comprehensive example of integration to an InputField see [the LiSe Client](https://github.com/LiSe-Team/LiSe-Unity-Client/blob/main/Runtime/Scripts/LiSeInputField.cs)

## Interactors

Obviously - you need a way to interact with the keyboard.

The design decision is to allow you to have flexibility in the Interactor. The XR Interaction Toolkit provides a well documented way of creating World Space interactors that can interact with UGUI components and this is the chosen mechanism.

However ...

Out of the Box, the only XRIT Interactors that interact with UGUI are the Ray Interactors. This is not ideal. As shown in the video above - the more natural way to use a keyboard is a Direct Interactor (i.e. a contained shape that can be used to touch the keyboard) especially in a "Xylophone action".

To allow this - the package includes an extended version of Direct Interactor - `KeyboardDirectInteractor.cs` and a Simple Interactor Prefab. This is not ideal but it creates a Ray from the extent of the Z axis of the collider component on the Interactor. To make this work - you should make sure that the long axis of the collider is the Z axis.
