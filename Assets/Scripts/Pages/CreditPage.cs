using UnityEngine;
using System.Collections;
using System;

public class CreditPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  public CreditPage ()
  {
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
    _backButton.x = -Futile.screen.halfWidth + 70.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;
    AddChild(_background);
    AddChild(_backButton);
    _backButton.SignalRelease += HandleBackButtonRelease;

    // music
    FSoundManager.PlayMusic("credit_music", 1.0f);

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }
}


