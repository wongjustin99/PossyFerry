using UnityEngine;
using System.Collections;
using System;

public class WinPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  private FLabel _winLabel;
  private FLabel _showScore;
  public WinPage ()
  {
    //initialize
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Play Again", new Color(0.25f,0.25f,0.25f,1.0f));
    _winLabel = new FLabel("Franchise", "Win Over for you!!!");
    _winLabel.color = new Color(1.0f,1.0f,1.0f,1.0f);

    //position back button
    _backButton.y = -Futile.screen.halfHeight + 100.0f;
    _backButton.scale = 1.25f;


    _winLabel.scale = 2.0f;
    _winLabel.y = Futile.screen.halfHeight - 100.0f;
    // score 
    _showScore = new FLabel("Franchise", "Score: 0");
    _showScore.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
    _showScore.text = "Score: " + Main.instance.score;

    //add to the stage
    AddChild(_background);
    AddChild(_backButton);
    AddChild(_winLabel);
    AddChild(_showScore);
    _backButton.SignalRelease += HandleBackButtonRelease;

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }
}


