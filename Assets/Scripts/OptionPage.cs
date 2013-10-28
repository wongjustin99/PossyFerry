using UnityEngine;
using System.Collections;
using System;

public class OptionPage: PageContatiner
{
	private FButton _backButton;
	private FSprite _background;
	public OptionPage ()
	{
		_background = new FSprite("JungleBlurryBG");
		_backButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
		_backButton.AddLabel("Franchise", "Back", new Color(0.45f,0.25f,0.0f,1.0f));
		Futile.stage.AddChild(_background);
		Futile.stage.AddChild(_backButton);
		_backButton.SignalRelease += HandleBackButtonRelease;
	}
	
	private void HandleBackButtonRelease(FButton fbutton)
	{
		Main.instance.GoToPage(PageType.TitlePage);
	}
}


