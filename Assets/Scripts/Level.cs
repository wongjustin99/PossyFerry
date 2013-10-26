using UnityEngine;
using System.Collections;

public class Level 
{
	protected FSprite _background;
    protected Gamepage _gamepage;
    public Level(Gamepage _gamepage)
    {
        // how about a level takes in a BG string?  -- Level manager (not written) would be able to iterate/dole out "levels"
        // this will be later relegated to subclasses of the interface Level
            // Level could be able to farm out to a text file, but "for now", how about just subclassing `Level` for each one? 
        this._gamepage = _gamepage;
    }
    protected void setBackground( string _background_file ){
        _background = new FSprite( _background_file );
        _gamepage.AddChild(_background);
    }

}