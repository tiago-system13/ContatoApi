setlocal enableDelayedExpansion
@echo off
ECHO. > "Execucao.log"
 
for %%G in (*.sql) do (
 
    ECHO -------------------------------------------------------- >> "Execucao.log"
    ECHO !DATE! !TIME! Executando o script "%%G"... >> "Execucao.log"
    ECHO -------------------------------------------------------- >> "Execucao.log"
    ECHO. >> "Execucao.log"
    
    sqlcmd -S db_api_contato_prova_sqlserver -U sa -P "contato@pi10" -d master -o -i"%%G" "C:\bdiProva-senior\db\dataset\saida_exec_sqlcmd.txt" >> "Execucao.log"
    
    ECHO. >> "Execucao.log"
    ECHO Fim da execucao: !DATE! !TIME! >> "Execucao.log"
    ECHO -------------------------------------------------------- >> "Execucao.log"
    ECHO. >> "Execucao.log"
    ECHO. >> "Execucao.log"
    
)
 
PAUSE