parser grammar PascalParser;

options { tokenVocab = PascalLexer; }

program : compoundStatement EOF;

compoundStatement: Begin statement (SEMICOLON statement)* SEMICOLON? End;

statement: (label COLON)? (simpleStatement | structuredStatement);
body: (statement SEMICOLON? | compoundStatement);

simpleStatement: assigmnentStatement | procedureStatement | gotoStatement;
assigmnentStatement: Identifier assignment expression;
assignment: ASSIGN | PLUSASSIGN | MINUSASSIGN | MULTASSIGN | DIVASSIGN;
procedureStatement: Identifier actualParameterList?;
gotoStatement: Goto label;
label: Number | Identifier;

structuredStatement: compoundStatement | conditionalStatement | repetitiveStatement | withStatement;
conditionalStatement: caseStatement | ifStatement;
repetitiveStatement: forStatement | repeatStatement | whileStatement;

caseStatement: Case expression Of case (SEMICOLON case)* elsePart? SEMICOLON? End;
case: caseRange (COMMA caseRange)* COLON body;
caseRange: constant (DOTS constant)?;
constant: Number | CharacterString;
elsePart: (Else | Otherwise) body;

ifStatement: If expression Then body (Else body)?;

forStatement: For Identifier ASSIGN expression (To | Downto) expression Do body
            | For Identifier In expression Do body;
            
repeatStatement: Repeat statement (SEMICOLON statement)* Until expression;
whileStatement: While expression Do body;
withStatement: With Identifier (COMMA Identifier)* Do body;

// Expressions
expression: simpleExpression (Comparison simpleExpression)?;
simpleExpression: term (Addition term)*;
term: factor (Multiplication factor)*;
factor: LBRC expression RBRC
      | Identifier
      | functionCall
      | unsignedConstant
      | Not factor
      | Signum factor
      | setConstructor
      | valueTypecast
      | addressFactor;
      
functionCall: Identifier actualParameterList?;
actualParameterList: LBRC (expression (COMMA expression)*)? RBRC;

unsignedConstant: Number | CharacterString | Nil;

setConstructor: RBKT setGroup (COMMA setGroup)* RBKT;
setGroup: expression (DOTS expression)?;

valueTypecast: Identifier LBRC expression RBRC;
addressFactor: AT Identifier;
