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
  public OptionPage ()
  {
    //Create background
    _background = new FSprite("background_1_blur");
    //Control label created
    _controlLabel = new FLabel("Franchise", "Controls: ");
    //buttons created
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
    _padControlButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _padControlButton.AddLabel("Franchise", "Buttons", new Color(0.45f,0.25f,0.0f,1.0f));
    _touchControlButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _touchControlButton.AddLabel("Franchise", "Touch", new Color(0.45f,0.25f,0.0f,1.0f));
    //positioning the buttons
    _controlLabel.x = -Futile.screen.halfWidth + 120.0f;
    _controlLabel.color = new Color(1.0f,1.0f,1.0f,1.0f);
    _backButton.x = -Futile.screen.halfWidth + 120.0f;
    _backButton.y = Futile.screen.halfHeight - 60.0f;
    _touchControlButton.x = -Futile.screen.halfWidth + 120.0f;
    _touchControlButton.y = -Futile.screen.halfHeight + 60.0f;
    _padControlButton.x = Futile.screen.halfWidth - 120.0f;
    _padControlButton.y = -Futile.screen.halfHeight + 60.0f;
    //adding to the stage
    AddChild(_background);
    AddChild(_controlLabel);
    AddChild(_backButton);
    AddChild(_touchControlButton);
    AddChild(_padControlButton);
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


