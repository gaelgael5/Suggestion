/** Grammar definition for suggestion language 
version 1.0
*/
grammar Suggestion;

options
{

}

AND: '&';
ANDALSO: '&&';
OR: '|';
XOR: '||';
NOT: '!';

K_ALL: A L L;
K_SHOW: S H O W;
K_WHERE: W H E R E;
K_WITH : W I T H;
K_FACETS : F A C E T S;
K_ORDER : O R D E R;
K_BY : B Y;
DIGIT: [0-9];

IDENTIFIER
    : [a-zA-Z_] [a-zA-Z_0-9]*
 ;

COMMENT_INPUT
    : '/*' .*? '*/' -> channel(HIDDEN);

LINE_COMMENT:
    (
        ( '-- ' | '#') ~[\r\n]* ('\r'? '\n' | EOF) 
        | '--' ('\r'? '\n' | EOF) 
    ) -> channel(HIDDEN);


/*
 ################## LEXER RULES ################## 
 */

stmt_list
    : ';'* stmt_line ( ';'+ stmt_line )* ';'*
 ;

stmt_line
    : stmt_show
    | select_stmt
    | stmt_Set_globalParameter    
    | stmt_Del_globalParameter
;

/*
 ################## Show ################## 
 */

stmt_show
    : K_SHOW any_name any_name?
;

/*
 ################## Parameters ################## 
 */

stmt_Set_globalParameter
    : 'SET' any_name '=' stmt_Set_globalParameter_literal
;

stmt_Set_globalParameter_literal
    : numeric_literal
    | string_literal_expr
    | char_literal_expr
    | datetime_expr
;

stmt_Del_globalParameter
    : 'DEL' any_name
;

/*
 ################## SELECT RULES ################## 
 */

select_stmt
    : where_stmt order_stmt? facet_stmt?
;

where_stmt
    : K_WHERE (expr | K_ALL)
;

order_stmt
    : K_ORDER K_BY identifier_stmt
;

facet_stmt
    : K_WITH K_FACETS IDENTIFIER ( ',' IDENTIFIER )*
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
: '@' IDENTIFIER
;

Char_literal
    : '\'' ( ~'\'' | '\'\'' ) '\''
 ;

String_literal
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

unary_operator 
    : NOT
;

expr
    : literal
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

literal
    : numeric_literal
    | string_literal_expr
    | char_literal_expr
    | datetime_expr
    | constant
    | variable
;

function_name
    : any_name
 ;

any_name
    : IDENTIFIER 
 ;

string_literal_expr 
    : String_literal
;

char_literal_expr
    : Char_literal
;

datetime_expr
    : Datetime (datetime_mask datetime_culture?)?
;

datetime_mask
    : String_literal
;

datetime_culture
    : String_literal
;


Datetime
    : '/' ~'/'* '/'
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
