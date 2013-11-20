using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePad :  FContainer
{
  private FSprite _shootbutton;
  private FSprite _upbutton;
  private FSprite _downbutton;
  private FSprite _rightbutton;
  private FSprite _leftbutton;

  private FContainer _movepad;

  private Shot _shot;

  public GamePad()
  {	
    _shootbutton = new FSprite("CloseButton_normal");
    _shootbutton.y =  -Futile.screen.halfHeight + 40;
    _shootbutton.x =  Futile.screen.halfWidth - 12.5f;

    _shootbutton.scale = 0.4f;

    AddChild(_shootbutton);

    _upbutton = new FSprite("CloseButton_normal");
    _downbutton = new FSprite("CloseButton_normal");
    _leftbutton = new FSprite("CloseButton_normal");
    _rightbutton = new FSprite("CloseButton_normal");

    // position sprites for d-pad
    // note: these should probably all be one sprite later? 
    _upbutton.x = 0.0f;
    _upbutton.y = 50.0f;
    _upbutton.x = _upbutton.x + -Futile.screen.halfWidth + 37;
    _upbutton.y = _upbutton.y + -Futile.screen.halfHeight + 27;
    _upbutton.scale = 0.4f;

    _downbutton.x = 0.0f;
    _downbutton.y = -50.0f;
    _downbutton.x = _downbutton.x + -Futile.screen.halfWidth + 37;
    _downbutton.y = _downbutton.y + -Futile.screen.halfHeight + 77;
    _downbutton.scale = 0.4f;

    _rightbutton.x = 50.0f;
    _rightbutton.y = 0.0f;
    _rightbutton.x = _rightbutton.x + -Futile.screen.halfWidth + 15;
    _rightbutton.y = _rightbutton.y + -Futile.screen.halfHeight + 52;
    _rightbutton.scale = 0.4f;

    _leftbutton.x = -50.0f;
    _leftbutton.y = 0.0f;
    _leftbutton.x = _leftbutton.x + -Futile.screen.halfWidth + 60;
    _leftbutton.y = _leftbutton.y + -Futile.screen.halfHeight + 52;
    _leftbutton.scale = 0.4f;

    AddChild(_upbutton);
    AddChild(_downbutton);
    AddChild(_rightbutton);
    AddChild(_leftbutton);

  }

  // `Rect`s -- bounding boxes for where the d-pad buttons are
  public Rect up_rect()
  {	
    return _upbutton.GetTextureRectRelativeToContainer();
  }

  public Rect down_rect()
  {	
    return _downbutton.GetTextureRectRelativeToContainer();
  }

  public Rect right_rect()
  {	
    return _rightbutton.GetTextureRectRelativeToContainer();
  }

  public Rect left_rect()
  {	
    return _leftbutton.GetTextureRectRelativeToContainer();
  }

  public Rect shootPress()
  {	
    return _shootbutton.GetTextureRectRelativeToContainer();
  }
}
