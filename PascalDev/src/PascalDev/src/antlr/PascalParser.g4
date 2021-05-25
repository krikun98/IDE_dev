parser grammar PascalParser;

options { tokenVocab = PascalLexer; }

program : compoundStatement EOF;

identifier: Identifier;

label: UnsignedInteger;

statement
   : label COLON unlabelledStatement
   | unlabelledStatement
   ;

unlabelledStatement
   : simpleStatement
   | structuredStatement
   ;

simpleStatement
   : assignmentStatement
   | procedureStatement
   | gotoStatement
   | emptyStatement
   ;
   
assignmentStatement: variable assignment expression;
assignment: ASSIGN | PLUSASSIGN | MINUSASSIGN | MULTASSIGN | DIVASSIGN;

variable: (AT Identifier | Identifier) 
    (LBKT expression (COMMA expression)* LBKT | 
    LBKT2 expression (COMMA expression)* LBKT2 | 
    DOT Identifier | POINTER)*;
    
expression: simpleExpression (Comparison simpleExpression)?;
    
simpleExpression: term (Addition term)*;    

term: factor (Multiplication factor)*;
factor: LBRC expression RBRC
      | variable
      | functionCall
      | unsignedConstant
      | Not factor
      | Signum factor
      | setConstructor
      | valueTypecast;

      
setConstructor: LBKT element (COMMA element)* RBKT |
    LBKT2 element (COMMA element)* RBKT2 ;
element: expression (DOTS expression)?;

procedureStatement: Identifier actualParameterList?;

functionCall: Identifier actualParameterList?;
actualParameterList: LBRC (expression (COMMA expression)*)? RBRC;

gotoStatement: Goto label;
emptyStatement:;


structuredStatement: compoundStatement | conditionalStatement | repetitiveStatement | withStatement;
compoundStatement: Begin statements End;
statements: statement (SEMICOLON statement)* SEMICOLON?;
conditionalStatement: caseStatement | ifStatement;

ifStatement: If expression Then statement (:Else statement)?;

caseStatement: Case expression Of case (SEMICOLON case)* elsePart? SEMICOLON? End;
case: caseRange (COMMA caseRange)* COLON statement;
caseRange: constant (DOTS constant)?;
constant: Number | CharacterString;
elsePart: SEMICOLON (Else | Otherwise) statements;

repetitiveStatement: forStatement | repeatStatement | whileStatement;

whileStatement: While expression Do statement;
forStatement: For variable ASSIGN expression (To | Downto) expression Do statement
            | For variable In expression Do statement;
repeatStatement: Repeat statements Until expression;

withStatement: With variable (COMMA variable)* Do statement;


unsignedConstant: Number | CharacterString | Nil;

valueTypecast: Identifier LBRC expression RBRC;
