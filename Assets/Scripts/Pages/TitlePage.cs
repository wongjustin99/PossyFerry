using UnityEngine;
using System.Collections;
using System;

public class TitlePage : PageContatiner
{
  private FLabel _titlePage;
  private FSprite _background;
  private FButton _backButton;
  private FButton _optionButton;
  private FButton _creditButton;
  private FButton _startButton;
  private FLabel _title;
  public TitlePage ()
  {
    //background and buttons are created
    _background = new FSprite("background_1_blur");
	_title = new FLabel("Franchise", "Shoot 'em");
	_title.scale = 1.5f;
    _title.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
    _optionButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _optionButton.AddLabel("Franchise", "Option", new Color(0.45f,0.25f,0.0f,1.0f));
    _optionButton.scale = 0.5f;
	_creditButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _creditButton.AddLabel("Franchise", "Credits", new Color(0.45f,0.25f,0.0f,1.0f));
    _creditButton.scale = 0.5f;
	_startButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _startButton.AddLabel("Franchise", "START!", new Color(0.45f,0.25f,0.0f,1.0f));
    //positioning the buttons
	_title.y = Futile.screen.halfHeight - 60.0f;
    _optionButton.x = Futile.screen.halfWidth - 120.0f;
	_optionButton.y = -Futile.screen.halfHeight + 80.0f;
    _creditButton.x = Futile.screen.halfWidth - 120.0f;

    _startButton.y = -Futile.screen.halfHeight + 30.0f;
	_startButton.x = Futile.screen.halfWidth - 90.0f;

	//adding to display them on stage
    AddChild(_background);
	AddChild(_title);
    AddChild(_optionButton);
    AddChild(_creditButton);
    AddChild(_startButton);
    //something happens when buttons are pressed
    _optionButton.SignalRelease += HandleOptionButtonRelease;
    _creditButton.SignalRelease += HandleCreditButtonRelease;
    _startButton.SignalRelease += HandleStartButtonRelease;

    // music
    FSoundManager.PlayMusic("title_music", 1.0f);

  }
  private void HandleOptionButtonRelease (FButton button)
  {
    Main.instance.GoToPage(PageType.OptionPage);
  }
  private void HandleCreditButtonRelease (FButton button)
  {
    Main.instance.GoToPage(PageType.CreditPage);
  }
  private void HandleStartButtonRelease (FButton button)
  {
    Main.instance.GoToPage(PageType.GamePage);
  }
}

