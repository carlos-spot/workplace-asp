try
{
    if( Sys && Sys.Application ){
        Sys.Application.notifyScriptLoaded();
    }
}
catch(ex){}

// this event is fired before the menu is actually shown on the page
// menu - the menu that is being opened
// you can return false to prevent the menu from being displayed, or true to allow the open to continue
function ob_em_OnBeforeMenuOpen(menu)
{
	return true;
}

// this event is fired after the menu has been shown on the page
// menu - the menu that was opened
function ob_em_OnAfterMenuOpen(menu)
{
}

// this event is fired before the menu is closed
// menu - the menu that is being closed
// you can return false to prevent the menu from being closed, or true to allow the closing to continue
function ob_em_OnBeforeMenuClose(menu)
{
	alert('before menu close...')
	return true;
}

// this event is fired after the menu has been closed
// menu - the menu that was closed
function ob_em_OnAfterMenuClose(menu)
{
}

// this event is fired before the click on the item is processed
// item - the menu item that is being clicked
// menu - the menu to which the item belongs to
// element - the target element of this menu
// ev - the event that caused the click
// you can return false to prevent the item from being clicked, or true to allow the clicking to continue
function ob_em_OnBeforeItemClick(item, menu, element, ev)
{
	return true;
}

// this event is fired after the click on the item is processed
// item - the menu item that is being clicked
// menu - the menu to which the item belongs to
// element - the target element of this menu
// ev - the event that caused the click
function ob_em_OnAfterItemClick(item, menu, element, ev)
{
	alert('test');
}