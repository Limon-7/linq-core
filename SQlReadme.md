## SQl Server

- Database Engine(DE):
- Analysis Service(SSAS)
- Reporting Service(SSRS):
- Integration Service(SSIS):

#### #1# Database & Table & Column

**Databse:**

- CREATE Database DatabaseName
- ALTER DATABSE OldDatabaseName Modify Name=newDtabaseName
- EXECUTE sp_renameDB 'OldDatabaseName','newDatabaseName'
- DROP Database DatabaseNameToDelete

**Table**

- CRETAE TABLE tableName
- ALTER TABLE oldTableName Modify Name=newTableName
- excute sp_rename 'oldTableName','newTableName'

**Column**

- ALTER TABLE tableName ALTER COLUMN columnName type not null,
- ALTER TABLE tableName ADD COLUMN columnName type not null,
- ALTER TABLE tableName DROP COLUMN columnName

#### #2# Constraint:

- ALTER TABLE tableName ADD CONSTRAINT constarintName CONSTRAINTTYPE(columnName)
- ALTER TABLE tableName DROP CONSTRAINT constarintName

#### SQL SERVER CLUASE

- From:
