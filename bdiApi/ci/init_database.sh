for i in `find -name "*.sql"`; do SqlServer -U sa -P -"contato@pi10" db_api_contato_sqlserver <$1; done;