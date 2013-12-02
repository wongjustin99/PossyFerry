using UnityEngine;
using System.Collections;
using System;

public class OptionPage: PageContatiner
{
  private FButton _backButton;
  private FButton _padControlButton;
  private FButton _touchControlButton;
  private FSprite _background;
  private FLabel _controlLabel;
  private FLabel _instructions;
  private FLabel _instrSteps;
  public OptionPage ()
  {
    //Create background
    _background = new FSprite("background_1_blur");
    //Control label created
    _controlLabel = new FLabel("Franchise", "Controls: ");
	_instructions = new FLabel("Franchise", "Instructions: ");
	_instructions.scale = 0.7f;
	_instrSteps = new FLabel("Franchise", "you HAVE the control of Mr.spiky, now go help \n" +
										  "him defend himself by avoiding bullets from incoming \n" +
										  "fish and shoot them with your powerful bullets. \n" +
										  "You have three lives to spare, now start shooting!");
    _instrSteps.scale = 0.4f;
	//buttons created
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
    _backButton.scale = 0.5f;
	_padControlButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _padControlButton.AddLabel("Franchise", "Buttons", new Color(0.45f,0.25f,0.0f,1.0f));
    _padControlButton.scale = 0.75f;
	_touchControlButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _touchControlButton.AddLabel("Franchise", "Touch", new Color(0.45f,0.25f,0.0f,1.0f));
    _touchControlButton.scale = 0.75f;
    _controlLabel.x = -Futile.screen.halfWidth + 120.0f;
	_controlLabel.y = -Futile.screen.halfHeight + 60.0f;
    _controlLabel.color = new Color(1.0f,1.0f,1.0f,1.0f);
		
    _backButton.x = -Futile.screen.halfWidth + 120.0f;
    _backButton.y = Futile.screen.halfHeight - 60.0f;
    _touchControlButton.x = -Futile.screen.halfWidth + 120.0f;
    _padControlButton.x = Futile.screen.halfWidth - 120.0f;
    _padControlButton.y = -Futile.screen.halfHeight + 60.0f;

	_instructions.x = Futile.screen.halfWidth - 150.0f;
	_instructions.y = Futile.screen.halfHeight - 30.0f;
	_instrSteps.x = Futile.screen.halfWidth - 150.0f;
	_instrSteps.y = Futile.screen.halfHeight - 90.0f;

	//adding to the stage
    AddChild(_background);
    AddChild(_controlLabel);
    AddChild(_backButton);
    AddChild(_touchControlButton);
    AddChild(_padControlButton);
	AddChild(_instructions);
	AddChild(_instrSteps);
    //something happens when buttons are pressed
    _backButton.SignalRelease += HandleBackButtonRelease;
    _touchControlButton.SignalRelease += HandleTouchControlsRelease;
    _padControlButton.SignalRelease += HandlePadControlsRelease;
  }

  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }

  private void HandleTouchControlsRelease(FButton Btouch)
  {
    Main.instance.controlScheme = new TouchControlScheme();
  }
  private void HandlePadControlsRelease(FButton Bpad)
  {
    Main.instance.controlScheme = new PadControlScheme();
  }
}


