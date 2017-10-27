/** Grammar definition for suggestion language 
version 1.0
*/
grammar Suggestion;

AND: '&';
ANDALSO: '&&';
OR: '|';
XOR: '||';
NOT: '!';

K_ALL: 'ALL';
K_NULL: 'NULL';
K_TRUE: 'TRUE';
K_FALSE: 'FALSE';
K_CURRENT_TIME: 'CURRENT_TIME';
K_CURRENT_DATE: 'CURRENT_DATE';
K_CURRENT_TIMESTAMP: 'CURRENT_TIMESTAMP';

DIGIT: [0-9];
IDENTIFIER
    : '"' (~'"' | '""')* '"'
    | '`' (~'`' | '``')* '`'
    | '[' ~']'* ']'
    | [a-zA-Z_] [a-zA-Z_0-9]* // TODO check: needs more chars in set
 ;

/*
 ################## LEXER RULES ################## 
 */

stmt_list
    : ';'* stmt_line ( ';'+ stmt_line )* ';'*
 ;

stmt_line
    : select_stmt
;

select_stmt
    : where_stmt order_stmt? facet_stmt?
;

where_stmt
    : 'WHERE' (expr | K_ALL)
;

order_stmt
    : 'ORDER BY' identifier_stmt
;

facet_stmt
    : 'WITH FACETS' IDENTIFIER ( ',' IDENTIFIER )*
;

function_stmt
    : function_name '(' function_args_stmt? ')'
;

function_args_stmt
    : expr ( ',' expr )*
;

identifier_stmt
    : IDENTIFIER ('.' IDENTIFIER)*
;

bind_parameter
 : (':') IDENTIFIER
 ;

string_literal
 : '\'' ( ~'\'' | '\'\'' )* '\''
 ;

numeric_literal
    : numeric_double_literal
    | numeric_integer_literal
 ;

numeric_integer_literal
    : '-'? DIGIT+
 ;

numeric_double_literal
    : '-'? DIGIT + '.' DIGIT+
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

numeric_binary_operator
    : '+' | '-' | '/'  | '*'  | '^' | '%'
;

boolean_binary_operator
    : '<' | '>' | '=' | '<=' | '>=' | '<<' | '>>'
;

unary_operator 
    : NOT
;

expr
    : numeric_literal_expr
    | string_literal_expr
    | constant_literal_value
    | bind_parameter
    | '(' expr ')'
    | unary_operator expr
    | expr binary_operator expr
    | function_stmt
 ;

numeric_literal_expr
    : numeric_literal
    | numeric_literal numeric_binary_operator numeric_literal
;

string_literal_expr
    : string_literal
    | string_literal ( '+' string_literal )?
;

constant_literal_value
    : K_NULL
    | K_CURRENT_TIME
    | K_CURRENT_DATE
    | K_CURRENT_TIMESTAMP
    | K_TRUE
    | K_FALSE
 ;