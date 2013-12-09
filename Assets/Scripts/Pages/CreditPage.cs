using UnityEngine;
using System.Collections;
using System;

public class CreditPage: PageContatiner
{
  private FButton _backButton;
  private FSprite _background;
  private FLabel _developers;
  private FLabel _credits2;
  public CreditPage ()
  {
    _background = new FSprite("background_1_blur");
    _backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
    _backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
    _backButton.x = -Futile.screen.halfWidth + 70.0f;
    _backButton.y = Futile.screen.halfHeight - 30.0f;

    _developers = new FLabel("Franchise", "Developers: \n" +
        "Kevin Nieman \n" +
        "Justin Wong \n" +
        "Michelle Hui Zhang \n\n" +
        "Senior Project Coordinator: \n" +
        "Dr. Mark S. Schmalz \n\n");

    _credits2 = new FLabel("Franchise",  "Senior Project Advisor: \n" +
        "Dr. Doug D. Dankel \n\n" +
        "Music: \n" +
        "Megalant");

    _developers.y = Futile.screen.halfHeight - 130.0f;
    _credits2.y = -Futile.screen.halfHeight + 85.0f;
    _developers.scale = 0.65f;
    _credits2.scale = 0.65f;

    AddChild(_background);
    AddChild(_backButton);
    AddChild(_developers);
    AddChild(_credits2);	
    _backButton.SignalRelease += HandleBackButtonRelease;

    // music
    FSoundManager.PlayMusic("credit_music", 1.0f);

  }
  private void HandleBackButtonRelease(FButton fbutton)
  {
    Main.instance.GoToPage(PageType.TitlePage);
  }
}


