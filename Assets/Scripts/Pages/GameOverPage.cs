using UnityEngine;
using System.Collections;
using System;

public class GameOverPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  private FLabel _GameOver;
  public GameOverPage ()
  {
    //initialize
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
    _GameOver = new FLabel("Franchise", "Game Over for YOU");
    _GameOver.color = new Color(0.45f,0.25f,0.0f,1.0f);
    //position back button
    _backButton.x = Futile.screen.halfWidth - 30.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;

    //add to the stage
    AddChild(_background);
    AddChild(_backButton);
    AddChild(_GameOver);
    _backButton.SignalRelease += HandleBackButtonRelease;

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }
}


