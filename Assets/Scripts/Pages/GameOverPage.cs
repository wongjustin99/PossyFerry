using UnityEngine;
using System.Collections;
using System;

public class GameOverPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  private FLabel _GameOver;
  private FLabel _showScore;
  public GameOverPage ()
  {
    //initialize
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");

	//position back button
    _backButton.x = -Futile.screen.halfWidth + 70.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;
    _backButton.AddLabel("Franchise", "Play Again", new Color(0.45f,0.25f,0.0f,1.0f));
	_backButton.scale = 0.75f;

    _GameOver = new FLabel("Franchise", "Game Over for YOU");
    _GameOver.color = new Color(1.0f,1.0f,1.0f,1.0f);
	_GameOver.scale = 1.5f;
    _GameOver.y = Futile.screen.halfHeight - 60.0f;

	_showScore = new FLabel("Franchise", "Score: 0");
	_showScore.scale = 0.75f;
    _showScore.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
	_showScore.text = "Score: " + Main.instance.score;

    //add to the stage
    AddChild(_background);
    AddChild(_backButton);
    AddChild(_GameOver);
	AddChild(_showScore);
    _backButton.SignalRelease += HandleBackButtonRelease;

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.GamePage);
  }
}


