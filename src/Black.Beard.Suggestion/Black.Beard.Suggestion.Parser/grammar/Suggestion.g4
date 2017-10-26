/** Grammar definition for suggestion language 
version 1.0
*/
grammar Suggestion;

DIGIT: [0-9];
AND: '&';
ANDALSO: '&&';
OR: '|';
XOR: '||';
NOT: '!';
K_NULL: 'NULL';
K_CURRENT_TIME: 'CURRENT_TIME';
K_CURRENT_DATE: 'CURRENT_DATE';
K_CURRENT_TIMESTAMP: 'CURRENT_TIMESTAMP';

IDENTIFIER
    : '"' (~'"' | '""')* '"'
    | '`' (~'`' | '``')* '`'
    | '[' ~']'* ']'
    | [a-zA-Z_] [a-zA-Z_0-9]* // TODO check: needs more chars in set
 ;

/*
 ################## LEXER RULES ################## 
 */

sql_stmt_list
    : ';'* sql_stmt ( ';'+ sql_stmt )* ';'*
 ;

sql_stmt
    : select_stmt
;

select_stmt
    : where_stmt
;

where_stmt
    : 'WHERE' + expr
;

expr
    : literal_value
    | '(' expr ')'
    | unary_operator expr
    | expr binary_operator expr
    | function_name '(' ( expr ( ',' expr )* )? ')'
 ;

numeric_literal
    : '-'? DIGIT+ ( '.' DIGIT* )?
 ;

bind_parameter
 : (':') IDENTIFIER
 ;

string_literal
 : '\'' ( ~'\'' | '\'\'' )* '\''
 ;

 function_name
 : any_name
 ;

 any_name
 : IDENTIFIER 
 ;

binary_operator 
    : AND | OR | ANDALSO | XOR
;

unary_operator 
    : NOT
;

literal_value
    : numeric_literal
    | bind_parameter
    | string_literal
    | 'null'
    // | K_CURRENT_TIME
    // | K_CURRENT_DATE
    // | K_CURRENT_TIMESTAMP
 ;
