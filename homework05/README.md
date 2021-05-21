# CSHP320A

homework05

The object is to get three in a row.

Rules:

    Allow placement only on empty spots.
    X goes first, then O
    When you get three in a row, you declare a winner.


When a winner is declared, you disable any further development.

The menu has File | New Game and File | Exit.

New Game will erase the board and start with X again.

HINT: Notice the Tag and that you ONLY have the Button_Click event. The tag gives you the row and column. The tag is also an object but as you can see it is actually a string (unbox it or call ToString). Then you can parse the string into row and column. 

Remember the Button_Click event has an object sender parameter. That sender object is a Button, so cast it to a Button and get the Tag object.