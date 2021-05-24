lexer grammar PascalLexer;

channels { Comments, Spaces }

fragment A : [aA];
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];

SEMICOLON: ';';
LBRC: '(';
RBRC: ')';
DOT: '.';
EQL : '=';
Error: .+?;

Nil: N I L;
Begin: B E G I N;
End: E N D;
Goto: G O T O;
Not: N O T;
Signum: S I G N;
Case: C A S E;
Of: O F;
Else: E L S E;
Otherwise: O T H E R W I S E;
If: I F;
Then: T H E N;
For: F O R;
To: T O;
Downto: D O W N T O;
Do: D O;
Repeat: R E P E A T;
Until: U N T I L;
While: W H I L E;
With: W I T H;

Comparison: LT | LE | GT | GE | EQL | NEQ | In | Is;
fragment LT: '<';
fragment LE: '<=';
fragment GT: '>';
fragment GE: '>=';
fragment NEQ: '<>';
In: I N;
Is: I S;

Addition: PLUS | MINUS | Or | Xor;
Or: O R;
Xor: X O R;

COLON: ':';
LBKT: '[';
RBKT: ']';
COMMA: ',';
DOTS: '..';
AT: '@';

ASSIGN: ':=';
PLUSASSIGN: '+=';
MINUSASSIGN: '-=';
MULTASSIGN: '*=';
DIVASSIGN: '/=';

Multiplication: MULT | DIVIDE | Div | Mod | And | Shl | Shr | As;
fragment MULT: '*';
fragment DIVIDE: '/';
Div: D I V;
Mod: M O D;
And: A N D;
Shl: S H L;
Shr: S H R;
As: A S;

Comment: (SingleLineComment | MultiLineComment) -> channel(Comments);
fragment SingleLineComment : '//' ~[\n\r]*;
fragment MultiLineComment : '{' NestedComment '}' | '(*' NestedComment '*)';
fragment NestedComment : (MultiLineComment | .)*?;

Identifier : (Letter | UNDERSCORE) (Letter | Decimal | UNDERSCORE)*;

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

fragment UnsignedReal : DecimalSequence (DOT DecimalSequence)? ScaleFactor?;
   
fragment ScaleFactor : E Sign? DecimalSequence;

CharacterString : (QuotedString | ControlString)+;

fragment QuotedString : QUOTE StringCharacter* QUOTE;
fragment StringCharacter : ~['\n] | QUOTE QUOTE;
fragment QUOTE : '\'';
fragment ControlString : (HASH UnsignedInteger)+;
fragment HASH : '#';

Symbol : Letter | Decimal | Hex;

fragment Letter : [a-zA-Z];
fragment Decimal : [0-9];
fragment Hex : [0-9A-Fa-f];

Whitespace: [ \n\t\r]+ -> channel(Spaces);
