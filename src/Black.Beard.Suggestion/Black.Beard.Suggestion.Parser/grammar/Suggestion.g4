/** Grammar definition for suggestion language 
version 1.0
*/
grammar Suggestion;

options
{
    // caseSensitive=false;
}

AND: '&';
ANDALSO: '&&';
OR: '|';
XOR: '||';
NOT: '!';

K_ALL: A L L;
DIGIT: [0-9];

IDENTIFIER
    : '{' [a-zA-Z_] [a-zA-Z_0-9]* '}'
    | [a-zA-Z_] [a-zA-Z_0-9]*
 ;

COMMENT_INPUT
    : '/*' .*? '*/' -> channel(HIDDEN);

LINE_COMMENT:
    (
        ('-- ' | '#') ~[\r\n]* ('\r'? '\n' | EOF) 
        | '--' ('\r'? '\n' | EOF) 
    ) -> channel(HIDDEN);


/*
 ################## LEXER RULES ################## 
 */

stmt_list
    : ';'* stmt_line ( ';'+ stmt_line )* ';'*
 ;

stmt_line
    : stmt_show_methods
    | select_stmt
    | stmt_Set_globalParameter
    | stmt_Get_globalParameter
    | stmt_Del_globalParameter
;

/*
 ################## Show ################## 
 */

stmt_show_methods
    : 'SHOW' 'METHODS'
    | 'SHOW' 'METHOD' function_name
;

/*
 ################## Parameters ################## 
 */

stmt_Set_globalParameter
    : 'SET' IDENTIFIER '=' literal
;

stmt_Get_globalParameter
    : 'GET' IDENTIFIER
;

stmt_Del_globalParameter
    : 'DEL' IDENTIFIER
;

/*
 ################## SELECT RULES ################## 
 */

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
 : ':' IDENTIFIER
 ;

constant
: '$' IDENTIFIER
;

variable
: '$' IDENTIFIER
;

char_literal
    : '\'' ( ~'\'' | '\'\'' ) '\''
 ;

string_literal
    : '"' ( ~'"' | '""' )* '"'
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
    | char_literal
    | constant
    | variable
    | array_expr
    | bind_parameter
    | sub_expr
    | unary_operator_expr
    | expr binary_operator expr
    | function_stmt
 ;

sub_expr
    : '(' expr ')'
;

unary_operator_expr
    : unary_operator expr
;

array_expr
    : '[' literal? ( ',' literal )* ']'
;
numeric_literal_expr
    : numeric_literal
    | numeric_literal numeric_binary_operator numeric_literal
;

literal
    : numeric_literal
    | string_literal
    | char_literal
    | datetime_expr
    | constant
    | variable
;

string_literal_expr
    : string_literal
    | string_literal ( '+' string_literal )?
;
 
 function_name
 : any_name
 ;

 any_name
 : IDENTIFIER 
 ;

datetime_expr
    : date_expr + time_expr? string_literal?
    | time_expr
;

date_expr
    : date_sub_expr (date_sep date_sub_expr)* string_literal?
;

time_expr
    : DIGIT DIGIT ':' DIGIT DIGIT ':' DIGIT DIGIT '.' DIGIT DIGIT*
;
date_sub_expr
    : DIGIT DIGIT*
;

date_sep
    : '\\' | '-' '//'
;

fragment A: [aA];
fragment B: [bB];
fragment C: [cC];
fragment D: [dD];
fragment E: [eE];
fragment F: [fF];
fragment G: [gG];
fragment H: [hH];
fragment I: [iI];
fragment J: [jJ];
fragment K: [kK];
fragment L: [lL];
fragment M: [mM];
fragment N: [nN];
fragment O: [oO];
fragment P: [pP];
fragment Q: [qQ];
fragment R: [rR];
fragment S: [sS];
fragment T: [tT];
fragment U: [uU];
fragment V: [vV];
fragment W: [wW];
fragment X: [xX];
fragment Y: [yY];
fragment Z: [zZ];
