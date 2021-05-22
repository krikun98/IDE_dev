lexer grammar Pascal;

Symbol : Letter | Decimal | Hex;

fragment Letter : [a-zA-Z];
fragment Decimal : [0-9];
fragment Hex : [0-9A-Fa-f];

Comment: SingleLineComment | MultiLineComment;
fragment SingleLineComment : '//' ~[\n\r]*;
fragment MultiLineComment : '{' NestedComment '}' | '(*' NestedComment '*)';
fragment NestedComment : (MultiLineComment | .)*?;

Identifier : (Letter | UNDERSCORE) (Letter | Decimal | UNDERSCORE){0,126};

fragment UNDERSCORE : '_';

Number : Sign? UnsignedNumber;

fragment UnsignedNumber : UnsignedInteger | UnsignedReal;

fragment UnsignedInteger
   : DecimalSequence
   | DOLLAR HexSequence
   | AMPERSAND OctalSequence
   | PERCENT BinarySequence
   ;
   
fragment Sign : PLUS | MINUS;
   
fragment PLUS : '+';
fragment MINUS : '-';
fragment DecimalSequence : Decimal+;
fragment DOLLAR : '$';
fragment HexSequence : Hex+;
fragment AMPERSAND : '&';
fragment OctalSequence : Octal+;
fragment Octal : [0-7];
fragment PERCENT : '%';
fragment BinarySequence : Binary+;
fragment Binary : [0-1];

fragment UnsignedReal : DecimalSequence (Dot DecimalSequence)? ScaleFactor?;
   
fragment Dot : '.';
fragment ScaleFactor : E Sign? DecimalSequence;
fragment E : 'e' | 'E';

CharacterString : (QuotedString | ControlString)+;

fragment QuotedString : QUOTE StringCharacter* QUOTE;
fragment StringCharacter : ~['\n] | QUOTE QUOTE;
fragment QUOTE : '\'';
fragment ControlString : (HASH UnsignedInteger)+;
fragment HASH : '#';