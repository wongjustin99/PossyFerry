using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PageType
{
	None,
	TitlePage,
	GamePage,
	OptionPage,
	CreditPage
}

public class Main : MonoBehaviour
{
	public BCharacter character;
	public Gamepage gamePage;
	public static Main instance;
	
	private PageContatiner _currentPage = null;
	private PageType _currentPageType = PageType.None;
	// Use this for initialization
	void Start () {
		instance = this;
		FutileParams fparams = new FutileParams(true,true,false,false);
		fparams.AddResolutionLevel(480.0f,	1.0f,	1.0f,	"_Scale1");
		fparams.origin = new Vector2(0.5f, 0.5f);
		Futile.instance.Init(fparams);
		
		Futile.atlasManager.LoadAtlas("Atlases/BananaLargeAtlas");
		Futile.atlasManager.LoadAtlas("Atlases/BananaGameAtlas");
		
		Futile.atlasManager.LoadFont("Franchise","FranchiseFont"+Futile.resourceSuffix, "Atlases/FranchiseFont"+Futile.resourceSuffix, 0.0f,-4.0f);
		
		GoToPage(PageType.TitlePage);
		//gamePage = new Gamepage();
		//Futile.stage.AddChild(gamePage);
	}
	
	public void GoToPage(PageType pageType)
	{
		if(_currentPageType == pageType) return;
		PageContatiner pageToCreate = null;
		if(pageType == PageType.TitlePage)
		{
			pageToCreate = new TitlePage();
		}
		else if(pageType == PageType.GamePage)
		{
			pageToCreate = new Gamepage();	
		}
		else if(pageType == PageType.OptionPage)
		{
			pageToCreate = new OptionPage();	
		}
		else if(pageType == PageType.CreditPage)
		{
			pageToCreate = new CreditPage();	
		}
		
		if(pageToCreate != null)
		{
			_currentPageType = pageType;
			if(_currentPage != null)
			{
				Futile.stage.RemoveChild(_currentPage);
			}
			
			_currentPage = pageToCreate;
			Futile.stage.AddChild(_currentPage);
			_currentPage.Start ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
