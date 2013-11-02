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
	public TitlePage ()
	{
		_background = new FSprite("JungleBlurryBG");
		_optionButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
		_optionButton.AddLabel("Franchise", "Option", new Color(0.45f,0.25f,0.0f,1.0f));
		_creditButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
		_creditButton.AddLabel("Franchise", "Credits", new Color(0.45f,0.25f,0.0f,1.0f));
		_startButton = new FButton("YellowButton_normal", "YellowButton_down", "YellowButton_over", "ClickSound");
		_startButton.AddLabel("Franchise", "START!", new Color(0.45f,0.25f,0.0f,1.0f));
		_optionButton.x = -Futile.screen.halfWidth + 120.0f;
		_creditButton.x = Futile.screen.halfWidth - 120.0f;
		_startButton.y = -Futile.screen.halfHeight + 30.0f;
		AddChild(_background);
		AddChild(_optionButton);
		AddChild(_creditButton);
		AddChild(_startButton);
		_optionButton.SignalRelease += HandleOptionButtonRelease;
		_creditButton.SignalRelease += HandleCreditButtonRelease;
		_startButton.SignalRelease += HandleStartButtonRelease;
		
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

