--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns messages related to a package execution.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE
    
    --+Required
    @ExecutionId int = 11,

    --+Default=false
    --+Comment=Include only basic logging messages. Excludes validation messages.
    @BasicLogging bit = 0,

    --+Output
    @Count int

--+Parameters

SELECT operation_message_id MessageId
  ,operation_id ExecutionId
  ,message_time CreatedAt
  ,message_type MessageTypeId
  ,CASE message_type 
     WHEN 10 THEN 'Pre-validate'
     WHEN 20 THEN 'Post-validate'
     WHEN 30 THEN 'Pre-execute'
     WHEN 40 THEN 'Post-execute'
     WHEN 50 THEN 'StatusChange'
     WHEN 60 THEN 'Progress'
     WHEN 70 THEN 'Information'
     WHEN 80 THEN 'VariableValueChanged'
     WHEN 90 THEN 'Diagnostic'
     WHEN 100 THEN 'QueryCancel'
     WHEN 110 THEN 'Warning'
     WHEN 120 THEN 'Error'
     WHEN 130 THEN 'TaskFailed'
     WHEN 140 THEN 'DiagnosticEx'
     WHEN 200 THEN 'Custom'
     WHEN 400 THEN 'NonDiagnostic'
     ELSE 'Unknown'
   END MessageTypeName
  ,message_source_type MessageSourceId
  ,CASE message_source_type 
     WHEN 10 THEN 'Entry API'
     WHEN 20 THEN 'External process'
     WHEN 30 THEN 'Package-level object'
     WHEN 40 THEN 'Control Flow task'
     WHEN 50 THEN 'Control Flow container'
     WHEN 60 THEN 'Data Flow task'
     ELSE 'Unknown'
   END MessageSourceName
  ,message Message
FROM catalog.operation_messages om
WHERE operation_id = @ExecutionId
  AND (@BasicLogging = 0 OR message_type > 20)
ORDER BY message_time, operation_message_id;

SET @Count = @@ROWCOUNT;